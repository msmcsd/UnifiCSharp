using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using System.Timers;
#if !DEBUG
using Microsoft.Win32;
#endif
using ContentAlignment = System.Drawing.ContentAlignment;
using Unifi.Consoles;
using Unifi.Observers.Animation;
using Unifi.UserControls;
using UnifiCommands;
using UnifiCommands.Commands;
using UnifiCommands.Commands.CodeCommands;
using UnifiCommands.CommandsProvider;
using UnifiCommands.Logging;
using System.Security.Principal;
using UnifiCommands.VariableProcessors;
using UnifiCommands.CommandInfo;
using static UnifiCommands.Commands.CodeCommands.DownloadInstallerCommand;

namespace Unifi.Forms
{
    public partial class TestTool : Form
    {
#region Variables for Loading Tasks with JSON

        private ICommandsProvider _commandsProvider;

#endregion

        private const string CategoryPrefix = "--";

        private ProgramSettings _programSettings;
        private CommandsRunner _commandsRunner;

        private DebugListener _debugListerListener;
        private ILogger _logger;

        public TestTool()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GetInstallFolderFromRegistry();
            LoadControls();
            LoadSettings();
            AddListeners();
            SetupEventHandlers();
        }

        private void SetupEventHandlers()
        {
            grpConfig.DoubleClick += InstallProduct;
            grpProduct.DoubleClick += InstallProduct;
            grpRunMode.DoubleClick += InstallProduct;
            grpInstallMode.DoubleClick += InstallProduct;
        }

        private void TestTool_FormClosing(object sender, FormClosingEventArgs e)
        {
            RemoveListeners();
        }
        
        private void AddListeners()
        {
            _debugListerListener = new DebugListener(txtDebugger);
            Debug.Listeners.Add(_debugListerListener);
        }       
        
        private void RemoveListeners()
        {
            Debug.Listeners.Remove(_debugListerListener);
        }

#region Program Settings

        private void LoadSettings()
        {
            if (File.Exists(Variables.ProgramSettingFilePath))
            {
                _programSettings = SettingsHelper.LoadSettings();
                chkDebugBuild.Checked = _programSettings.IsDebugMode;
                txtInstallDir.Text = _programSettings.InstallDirectory;
                Variables.CylanceDesktopFolder = txtInstallDir.Text;

                switch (_programSettings.Venue)
                {
                    case Venue.R01:
                        rbR01.Checked = true;
                        break;
                    case Venue.R02:
                        rbR02.Checked = true;
                        break;
                    default:
                        rbQa2.Checked = true;
                        break;
                }
            }
            else
            {
                _programSettings = new ProgramSettings
                {
                    IsDebugMode = chkDebugBuild.Checked,
                    Venue = Venue.R01,
                    InstallDirectory = Variables.CylanceDesktopFolder
                };
            }

            // txtInstallDir.DataBindings.Add("Text", _bindingSource, "InstallDirectory");
            // chkDebugBuild.DataBindings.Add("Checked", _bindingSource, "IsDebugMode");
            _programSettings.PropertyChanged += ProgramProgramSettingsChanged;
            // _bindingSource.DataSource = _programSettings;
        }

        private void txtInstallDir_TextChanged(object sender, EventArgs e)
        {
            _programSettings.InstallDirectory = txtInstallDir.Text.Trim();
        }

        private void chkDebugBuild_CheckedChanged(object sender, EventArgs e)
        {
            _programSettings.IsDebugMode = chkDebugBuild.Checked;
        }

        private void Venue_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            if (rb == null) return;

            var venue = Enum.GetNames(typeof(Venue))
                .FirstOrDefault(v => v.Equals(rb.Text, StringComparison.InvariantCultureIgnoreCase));

            if (venue != null)
                _programSettings.Venue = (Venue)Enum.Parse(typeof(Venue), venue);
        }

        public void ProgramProgramSettingsChanged(object sender, PropertyChangedEventArgs e)
        {
            ProgramSettings s = sender as ProgramSettings;
            SettingsHelper.SaveSettings(s);
        }

#endregion

        /// <summary>
        /// If Protect is already installed, read the install directory from registry. Otherwise use default.
        /// </summary>
        /// <returns></returns>
        private void GetInstallFolderFromRegistry()
        {
#if DEBUG
            Process p = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "cmd.exe",
                    Arguments = $"/C FOR /F \"tokens=2* skip=2\" %a in ('reg query \"HKLM\\{Variables.RegistryKey}\" /v \"Path\"') do echo %b",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true
                }
            };
            
            p.Start();
            p.WaitForExit();
            
            var results = p.StandardOutput.ReadToEnd().Split(new[] { "\r\n" }, StringSplitOptions.None);
            
            string path = results.Length >= 2 ? results[results.Length - 2] : "";
#else
            // This requires Visual Studio to run as admin.
            string path = null;
            try
            {
                path = Registry.LocalMachine.OpenSubKey(Variables.RegistryKey, true).GetValue("Path") as string;
            }
            catch (Exception)
            {

            }
#endif
            path = string.IsNullOrEmpty(path) ? Variables.DefaultInstallFolder : path;
            Variables.CylanceDesktopFolder = path;
        }

        private bool IsElevated()
        {
            using(WindowsIdentity identity = WindowsIdentity.GetCurrent())
            {
                WindowsPrincipal principal = new WindowsPrincipal(identity);
                return principal.IsInRole(WindowsBuiltInRole.Administrator);
            }
        }

        private void LoadControls()
        {
            if (!Debugger.IsAttached && File.Exists(Variables.JsonConfigPath))
            {
                Process p = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = "cmd.exe",
                        Arguments = $"/C xcopy \"{Variables.JsonConfigPath}\" \"{Variables.LocalJsonConfigPath}\" /j /Y",
                        CreateNoWindow = true,
                        UseShellExecute = false
                    }
                };
                p.Start();
                p.WaitForExit();
            }

            Text = $"{Assembly.GetExecutingAssembly().GetName().Name} {new FileInfo(Assembly.GetEntryAssembly().Location).LastWriteTime}";

            if (File.Exists(Variables.LocalJsonConfigPath))
            {
                _commandsProvider = new JsonCommandsProvider(this);
                //Text = $@"{Text} Loaded using JSON";
            }
            else
            {
                // _commandsProvider = new DefaultCommandsProvider();
                //Text = $@"{Text} Loaded using defaults";
            }

            _logger = new DesktopLogger(txtConsole);
            // Logging.Initialize(_logger);

            reportGrid1.DosTasks = _commandsProvider.DosTasks;
            reportGrid1.Logger = _logger;
            _commandsRunner = new CommandsRunner(reportGrid1, false, null, _logger, AppType.Desktop);

            PopulateDosCommandGroups();
            PopulateTaskbarCommands();
            //PopulateDownloadCommands();
            PopulateRollbackPositions();
            PopulateBatchCommandList();
            PopulateInstallCommands();
            PopulateVersionGrid();

            InitDownloadCommandGroup();

            Text = $"{Text} {(BaseCommandInfo.ShowCommandOnMachine() == ShowCommandOnMachine.Dev ? "on Dev Machine" : "on Test Machine")}";
            if (IsElevated()) Text += " (Administrator)";

            ShowFilesVersions(null, null);
        }

        private void InitDownloadCommandGroup()
        {
            downloadCommandGroup1.Logger = _logger;
            downloadCommandGroup1.CommandsRunner = _commandsRunner;
        }

        private void PopulateVersionGrid()
        {
            lstVersion.Commands = _commandsProvider.FileVersionTask.Commands;
            lstVersion.PopulateItems();
            lstVersion.FormObject = this;
        }

        private void PopulateDosCommandGroups()
        {
            tabCommands.Width = 160;
            tabCommands.TabPages.Clear();

            foreach(var tabName in Enum.GetNames(typeof(DosTab)))
            {
                var tasks = _commandsProvider.DosTasks.Where(t => t.Tab.ToString() == tabName).ToList();
                if (tasks.Any())
                {
                    TabPage page = new TabPage(tabName);
                    tabCommands.TabPages.Add(page);
                    AddComandGroupsToTab(page, tasks);
                }
            }
        }

        private void AddComandGroupsToTab(TabPage tab, IEnumerable<TestTask> tasks)
        {
            int left = 0;
            int top = 0;
            int columns = 1;
            int controlWidth = 150;

            tab.Controls.Clear();

            foreach (var task in tasks)
            {
                if (task.Commands.Count == 0) continue;

                var ctl = new DosCommandGroup
                {
                    CommandsRunner = _commandsRunner,
                    TestTask = task,
                    Width = controlWidth,
                    Logger = _logger
                };

                tab.Controls.Add(ctl);

                if (top + ctl.Height > tab.Height)
                {
                    left = left + ctl.Width;
                    top = 0;
                    columns++;

                    if (ctl.Width * columns > tab.Parent.Width)
                        tab.Parent.Width += ctl.Width;
                }

                ctl.Left = left;
                ctl.Top = top;

                top += ctl.Height;
            }
        }
        
        private void OutputToConsole(object sender, DataReceivedEventArgs e)
        {
            Trace.WriteLine(e.Data);
        }

#region Methods run using reflection. These return values of these methods depend on the UI.

        private string CylanceDesktopFolder => Variables.CylanceDesktopFolder;

        private string ProtectLogPath => Path.Combine(CylanceDesktopFolder, $@"log\{GetProtectLogFileName}");
        
        private string OpticsLogPath => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), $@"Cylance\Optics\log\{GetOpticsLogFileName}");

        private string GetProtectLogFileName => $"{DateTime.Today:yyyy-MM-dd}.log";

        private string GetOpticsLogFileName => $"Optics-{DateTime.Today:yyyy-MM-dd}.csv";

        private string GetToken
        {
            get
            {
                if (rbR02.Checked) return Variables.R02Token;

                if (rbQa2.Checked) return Variables.QA2Token;

                return Variables.R01Token;
            }
        }

        private string GetConfig
        {
            get
            {

                if (rbR02.Checked)
                    return rbR02.Text;
                else if (rbQa2.Checked)
                    return rbQa2.Text;
                else
                    return rbR01.Text;
            }
        }

        private string GetMsiInstallerPath
        {
            get
            {
                GetMsiPathCommand msiPath = new GetMsiPathCommand(_logger);
                return msiPath.Execute().Result;
            }
        }

        //private string GetInstallerFileName
        //{
        //    get
        //    {
        //        string installer;
        //        if (lstDownload.SelectedItem == null)
        //            installer = Variables.ProtectMsiNameByVmArch;
        //        else
        //        {
        //            if (lstDownload.Text.ToLower().Contains("dtd"))
        //                installer = Variables.DtdInstallerName;
        //            else if (lstDownload.Text.ToLower().Contains("esse"))
        //                installer = Variables.EsseInstallerName;
        //            else
        //                installer = Variables.ProtectMsiNameByVmArch;
        //        }

        //        return installer;
        //    }
        //}

        private string GetBootstrapperFullPath => $@"{Variables.InstallerDownloadFolder}\{Variables.ProtectBootstrapperName}";

        //private string GetCylanceUiFullPath
        //{
        //    get
        //    {
        //        if (lstDownload.SelectedItem == null) return "";
        //        if (lstDownload.Text.ToLower().Contains("dtd")) return Variables.DtdUiPath;
        //        if (!lstDownload.Text.ToLower().Contains("esse")) return Variables.CylanceUiPath;

        //        return "";
        //    }
        //}

        private string GetRollbackLogSaveDirectory
        {
            get
            {
                string rollbackCategory = GetAmpplRollbackTestCategory(out string rollbackPosition);
                string archFolder = Environment.OSVersion.Version.CompareTo(new Version("6.2")) < 0
                    ? "Win7"
                    : Environment.Is64BitOperatingSystem ? "x64" : "x86";

                FullCommandInfo command = lstRollbackPosition.SelectedItem as FullCommandInfo;
                string rollbackPositionFolder = command == null ? "" : $"{command.Arguments}-{command.DisplayText}";
                string saveFolder = Path.Combine(Variables.VmWareSharedFolder, $@"TestTools\Rollback\RollbackTestLogs\{archFolder}\{rollbackCategory}\{rollbackPositionFolder}");

                if (!Directory.Exists(saveFolder)) Directory.CreateDirectory(saveFolder);

                return saveFolder;
            }
        }

        private string GetLatestRollbackFile
        {
            get
            {
                string logFolder = GetRollbackLogSaveDirectory;
                var file = new DirectoryInfo(logFolder).GetFiles().OrderByDescending(f => f.LastWriteTime).FirstOrDefault();
                if (file == null) return "";

                return Path.Combine(logFolder, file.Name);
            }
        }

        private string GetAmpplRollbackTestCategory(out string rollbackPosition)
        {
            rollbackPosition = "";
            if (lstRollbackPosition.SelectedItem == null ||
                lstRollbackPosition.SelectedIndex <= 0 ||
                lstRollbackPosition.Text.Trim() == "")
            {
                return "";
            }

            if (lstRollbackPosition.Text.Trim().StartsWith(CategoryPrefix))
            {
                rollbackPosition = Rollback.RollbackCategoryName.None;
                if (lstRollbackPosition.Text.Contains("Add")) return Rollback.RollbackCategoryName.AddAmppl;
                if (lstRollbackPosition.Text.Contains("Remove")) return Rollback.RollbackCategoryName.RemoveAmppl;
                if (lstRollbackPosition.Text.Contains("Update")) return Rollback.RollbackCategoryName.UpdateAmppl;
            }

            rollbackPosition = lstRollbackPosition.Text;
            for (int i = lstRollbackPosition.SelectedIndex-1; i >= 0; i--)
            {
                string currentItemText = lstRollbackPosition.Items[i].ToString().Trim();
                if (currentItemText.StartsWith(CategoryPrefix))
                {
                    if (currentItemText.Contains("Add")) return Rollback.RollbackCategoryName.AddAmppl;
                    if (currentItemText.Contains("Remove")) return Rollback.RollbackCategoryName.RemoveAmppl;
                    if (currentItemText.Contains("Update")) return Rollback.RollbackCategoryName.UpdateAmppl;
                }
            }

            return "";
        }

        private string CompileMode => chkDebugBuild.Checked ? "Debug" : "";

        private string GetRollbackPosition => lstRollbackPosition.SelectedItem == null ? Rollback.RollbackCategoryName.None : lstRollbackPosition.Text;

#endregion

#region Task Population Functions

        private void PopulateTaskbarCommands()
        {
            var _showOnMachine = BaseCommandInfo.ShowCommandOnMachine();
            var tasks = _commandsProvider.TestTasks.FirstOrDefault(t => t.CommandGroup == CommandGroup.Taskbar)?
                .Commands.Where(c=> (c.ShowOnMachine & _showOnMachine) == _showOnMachine).ToArray();
            
            pnlTaskBar.Controls.Clear();
            for (int i = tasks.Length - 1; i >= 0; i--)
            {
                FullCommandInfo command = tasks[i];

                Button btn = new Button
                {
                    Dock = DockStyle.Left,
                    Text = command.DisplayText,
                    ImageAlign = ContentAlignment.TopCenter,
                    TextAlign = ContentAlignment.BottomCenter,
                    Width = 60,
                    Tag = command
                };

                btn.Click += RunTaskInTaskBar;
                btn.Image = Utils.ExtractIcon(command.IconSourcePath, command.IconIndex)?.ToBitmap();

                pnlTaskBar.Controls.Add(btn);
            }
        }

        private void RunTaskInTaskBar(object sender, EventArgs e)
        {
            if (sender == null) return;

            FullCommandInfo commandInfo = (FullCommandInfo) ((Button) sender).Tag;
            if (commandInfo == null)
            {
                Trace.Fail("Task is null");
                return;
            }

            commandInfo.CreateNewWindow = true;

            RunCommands(new List<FullCommandInfo> { commandInfo });
        }

        private void PopulateInstallCommands()
        {
            var groups = _commandsProvider.TestTasks.Where(t => t.CommandGroup == CommandGroup.Install).ToList();
            lstInstall.DisplayMember = "Name";
            lstInstall.DataSource = groups;
        }

        //private void PopulateDownloadCommands()
        //{
        //    lstDownload.TestTask = _commandsProvider.TestTasks.FirstOrDefault(t => t.CommandGroup == CommandGroup.Download);
        //    lstDownload.CommandsRunner = _commandsRunner;
        //    lstDownload.Logger = _logger;
        //}
        
        private void PopulateRollbackPositions()
        {
            if (BaseCommandInfo.ShowCommandOnMachine() != ShowCommandOnMachine.Test) return;

            lstRollbackPosition.Items.Clear();
            PopulateRollbackPositions(JsonCommandsProvider.TaskGroup.AddAmpplPositions, _commandsProvider.AddAmpplRollbackPositions);
            PopulateRollbackPositions(JsonCommandsProvider.TaskGroup.RemoveAmpplPositions, _commandsProvider.RemoveAmpplRollbackPositions);
            PopulateRollbackPositions(JsonCommandsProvider.TaskGroup.UpdateAmpplPositions,_commandsProvider.UpdateAmpplRollbackPositions);

            Rollback.RollbackPositionsList = new Dictionary<string, List<FullCommandInfo>>
            {
                {Rollback.RollbackCategoryName.AddAmppl,  _commandsProvider.AddAmpplRollbackPositions},
                {Rollback.RollbackCategoryName.RemoveAmppl,  _commandsProvider.RemoveAmpplRollbackPositions},
                {Rollback.RollbackCategoryName.UpdateAmppl,  _commandsProvider.UpdateAmpplRollbackPositions}
            };

            //grpRollback.Visible = lstRollbackPosition.Items.Count > 0;
            TabPage page = new TabPage("Rollback");
            grpRollback.Dock = DockStyle.Left;
            page.Controls.Add(grpRollback);
            tabCommands.TabPages.Add(page);
            grpRollback.Visible = true;
        }

        private void PopulateRollbackPositions(string category, IEnumerable<FullCommandInfo> rollbackPositions)
        {
            var commandInfos = rollbackPositions?.ToList();
            if (commandInfos == null || string.IsNullOrEmpty(category) || commandInfos.Count <= 0) return;

            int i = category.IndexOf("-", StringComparison.Ordinal);
            lstRollbackPosition.Items.Add($"{CategoryPrefix} {category.Substring(i + 1)}");
            foreach (var p in commandInfos)
            {
                lstRollbackPosition.Items.Add(p);
            }
            lstRollbackPosition.Items.Add("");
        }

        private void PopulateBatchCommandList()
        {
            lstBatchCommands.TestTasks = _commandsProvider.BatchTasks;
            lstBatchCommands.Logger = _logger;
        }

        #endregion

        #region Callbacks

        /// <summary>
        /// Updates command list box to show file versions for code command "FileVersion".
        /// Also used during Protect install.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        private void ShowFilesVersions(object source, ElapsedEventArgs e)
        {
            lstVersion.ShowFilesVersions(source, e);
        }

#endregion

#region Control Events

        private async void lstRollbackPosition_Click(object sender, EventArgs e)
        {
            if (lstRollbackPosition.Items.Count == 0) return;

            if (lstRollbackPosition.SelectedItem == null)
            {
                lstRollbackPosition.SelectedIndex = 0;
            }

            if (lstRollbackPosition.Text.Trim().StartsWith(CategoryPrefix))
            {
                return;
            }

            string category = GetAmpplRollbackTestCategory(out string position);

            await new SetRollbackCommand(category, position, _logger).Execute();
        }

        /// <summary>
        /// Main function to run commands.
        /// </summary>
        /// <param name="commandInfos"></param>
        /// <param name="observer"></param>
        /// <param name="checkReturnValue"></param>
        private void RunCommands(List<FullCommandInfo> commandInfos, IObserver observer = null, bool checkReturnValue = false)
        {
            var b = new BatchCommandExecutor(commandInfos, checkReturnValue, reportGrid1, _logger, AppType.Desktop);
            b.RegisterObserver(observer);
            b.Execute();
        }

        /// <summary>
        /// Displays each command and its arguments in the list.
        /// </summary>
        /// <param name="commandInfos"></param>
        private void DisplayCommands(List<FullCommandInfo> commandInfos)
        {
            foreach (var info in commandInfos)
            {
                Command command = CommandFactory.CreateCommand(info, _logger, AppType.Desktop);
                command.LogParameters();
            }
        }
        
        private void ListBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            ListBox listBox = (ListBox)sender;
            if (sender == null || e == null || e.Index < 0) return;

            FullCommandInfo info = (FullCommandInfo)listBox.Items[e.Index];

            Font font = info.DisplayText.StartsWith(CategoryPrefix) ?
                new Font(listBox.Font.FontFamily, listBox.Font.Size, FontStyle.Bold) :
                new Font(listBox.Font.FontFamily, listBox.Font.Size);

            Brush brush = info.Type == CommandType.Code ? Brushes.Green : Brushes.Black;

            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                brush = Brushes.White;
            }
            e.DrawBackground();
            e.Graphics.DrawString(listBox.Items[e.Index].ToString(), font, brush, e.Bounds);
        }

        private async void btnSetFunctionsToRun_Click(object sender, EventArgs e)
        {
            await new SetTestFunctionsCommand(txtFunctionsToRun.Text, _logger).Execute();
        }

        private void TestTools_KeyDown(object sender, KeyEventArgs e)
        {
            if (e != null && e.KeyCode == Keys.F5)
            {
                LoadControls();
            }
        }

        private void tabCommands_DoubleClick(object sender, EventArgs e)
        {
            LoadControls();
        }

        private void lstInstall_DoubleClick(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtInstallDir.Text))
            {
                MessageBox.Show(@"Enter install path.");
                return;
            }

            if (!(lstInstall.SelectedItem is TestTask info)) return;

            Variables.CylanceDesktopFolder = txtInstallDir.Text.Trim();
            
            RunCommands(info.Commands);
        }

        private void lstInstall_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right) return;

            lstInstall.SelectedIndex = lstInstall.IndexFromPoint(e.X, e.Y);

            if (!(lstInstall.SelectedItem is TestTask info)) return;

            DisplayCommands(info.Commands);
        }

        #endregion

        private void InstallProduct(object sender, EventArgs e)
        {
            MessageBox.Show("123");
        }
    }
}


