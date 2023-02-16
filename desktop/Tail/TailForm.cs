using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace Tail
{
    public enum TailType
    {
        TailFromStart,      // Filter text from the beginning of the file.
        TailFromCurrent,    // Filter text for new contents from now.
        Filter              // Show filtered results only without tailing.
    }

    public partial class TailForm : Form
    {
        private readonly string _textFile;
        private readonly TailType _tailType;
        private bool _stop;
        private object _errorLineLock = new object();

        private List<int> _errorLines = new List<int>();
        private int _currentErrorLineIndex;

        private string Filter
        {
            get => txtFilter.Text;
            set
            {
                if (!string.IsNullOrWhiteSpace(txtFilter.Text))
                    txtFilter.Text = value;
            }
        }

        public TailForm()
        {
            InitializeComponent();
            _tailType = TailType.TailFromCurrent;
            string installFolder = GetInstallPath();
            if (Directory.Exists(installFolder))
            {
                installFolder = Path.Combine(installFolder, "log");
                _textFile = Path.Combine(installFolder, DateTime.Now.ToString("yyyy-MM-dd") + ".log");
            }
        }

        private string GetInstallPath()
        {
            var path = Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Cylance\Desktop", "Path", string.Empty);
            return path == null ? string.Empty : path.ToString();
        }

        public TailForm(string textFile, TailType tailType, string filter) : this()
        {
            _textFile = textFile;
            _tailType = tailType;
            txtFilter.Text = filter;
        }

        private async void TailForm_Shown(object sender, EventArgs e)
        {
            txtFile.Text = _textFile;
            Text = $"Tail {new FileInfo(Assembly.GetEntryAssembly().Location).LastWriteTime}";
            if (IsElevated()) Text = $"{Text} (Administrator)";

            if (!File.Exists(_textFile) || string.IsNullOrWhiteSpace(Filter))
            {
                btnStop.Enabled = false;
                return;
            }


            btnStop.Enabled = true;
            await StartFollow();
        }

        private bool IsElevated()
        {
            using (WindowsIdentity identity = WindowsIdentity.GetCurrent())
            {
                WindowsPrincipal principal = new WindowsPrincipal(identity);
                return principal.IsInRole(WindowsBuiltInRole.Administrator);
            }
        }

        private async Task StartFollow()
        {
            btnStart.Enabled = false;
            btnStop.Enabled = true;

            chkFollowTail.Checked = true;
            _errorLines.Clear();
            _currentErrorLineIndex = -1;

            if (_tailType == TailType.Filter)
                await Task.Run(FilterFile);
            else
                await Task.Run(Follow);
        }

        public async Task Follow()
        {
            using (StreamReader reader = new StreamReader(new FileStream(_textFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)))
            {
                //start at the end of the file
                long lastMaxOffset = _tailType == TailType.TailFromCurrent ? reader.BaseStream.Length : 0;

                while (true)
                {
                    await Task.Run(() => Thread.Sleep(10));
                    if (_stop)
                    {
                        _stop = false;
                        break;
                    }

                    //if the file size has not changed, idle
                    if (reader.BaseStream.Length == lastMaxOffset)
                        continue;

                    //seek to the last max offset
                    reader.BaseStream.Seek(lastMaxOffset, SeekOrigin.Begin);

                    //read out of the file until the EOF
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (line.IndexOf(Filter, StringComparison.InvariantCultureIgnoreCase) >= 0)
                        {
                            AppendLine(line);
                        }
                    }

                    //update the last max offset
                    lastMaxOffset = reader.BaseStream.Position;
                }
            }
        }

        private async Task FilterFile()
        {
            using (var stream = File.OpenRead(_textFile))
            {
                using (StreamReader reader = new StreamReader(stream, Encoding.UTF8, true, 1024))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (_stop)
                        {
                            _stop = false;
                            break;
                        }

                        if (line.IndexOf(Filter, StringComparison.InvariantCultureIgnoreCase) >= 0)
                        {
                            await Task.Run(() => Thread.Sleep(10));
                            AppendLine(line);
                        }
                    }
                }
            }
        }

        private void AppendLine(string line)
        {
            txtOutput.BeginInvoke(new MethodInvoker(() =>
            {
                int redFontStart = txtOutput.Text.Length;

                txtOutput.AppendText(line + Environment.NewLine);
                if (chkFollowTail.Checked) txtOutput.ScrollToCaret();

                if (line.IndexOf("error", StringComparison.InvariantCultureIgnoreCase) > 0 ||
                    line.IndexOf("exception", StringComparison.InvariantCultureIgnoreCase) > 0)
                {
                    lock (_errorLineLock) {
                        _errorLines.Add(txtOutput.Lines.Length - 1);
                    }
                    lblErrorCount.Text = $@"{_errorLines.Count} Error(s)";

                    txtOutput.Select(redFontStart, line.Length);
                    txtOutput.SelectionFont = new Font(txtOutput.Font, FontStyle.Bold);
                    txtOutput.SelectionColor = Color.Red;
                }
            }));
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtOutput.BeginInvoke(new MethodInvoker( () =>
            {
                txtOutput.Clear();
                lock (_errorLineLock)
                {
                    _errorLines.Clear();
                }
                lblErrorCount.Text = $@"{_errorLines.Count} Error";
            }));
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            _stop = true;
            btnStart.Enabled = true;
            btnStop.Enabled = false;
        }

        private async void btnStart_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Filter))
            {
                return;
            }

            await StartFollow();
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            lblEnterFilter.Visible = string.IsNullOrWhiteSpace(txtFilter.Text);
        }

        private void btnPrevError_Click(object sender, EventArgs e)
        {
            ScrollToLine(false);
        }

        private void btnNextError_Click(object sender, EventArgs e)
        {
            ScrollToLine(true);
        }

        private void ScrollToLine(bool nextLine)
        {
            lock (_errorLineLock)
            {
                if (_errorLines.Count <= 0) return;

                if (nextLine)
                {
                    if (_currentErrorLineIndex + 1 > _errorLines.Count - 1)
                        _currentErrorLineIndex = _errorLines.Count - 1;
                    else if (_currentErrorLineIndex + 1 < 0)
                        _currentErrorLineIndex = 0;
                    else
                        _currentErrorLineIndex++;
                }
                else
                {
                    if (_currentErrorLineIndex - 1 < 0)
                    {
                        _currentErrorLineIndex = 0;
                    }
                    else
                    {
                        _currentErrorLineIndex--;
                    }
                }

                int lineNumber = _errorLines[_currentErrorLineIndex];

                if (lineNumber <= 0 || lineNumber > txtOutput.Lines.Length - 1) return;
                lineNumber--;
                if (lineNumber < 0) lineNumber = 0;

                txtOutput.BeginInvoke(new MethodInvoker(() =>
                {
                    txtOutput.SelectionStart = txtOutput.Find(txtOutput.Lines[lineNumber]);
                    txtOutput.ScrollToCaret();
                    chkFollowTail.Checked = false;
                }));
            }
        }

        private void txtFile_TextChanged(object sender, EventArgs e)
        {
            lblFileNotFound.Visible = !File.Exists(txtFile.Text);
        }
    }
}
