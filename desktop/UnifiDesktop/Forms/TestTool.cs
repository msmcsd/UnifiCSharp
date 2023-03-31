using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using System.Timers;
#if !DEBUG
using Microsoft.Win32;
#endif
using Unifi.Consoles;
using Unifi.Observers.Animation;
using UnifiCommands;
using UnifiCommands.Commands.CodeCommands;
using UnifiCommands.CommandsProvider;
using UnifiCommands.Logging;
using System.Security.Principal;
using UnifiCommands.CommandInfo;
using UnifiDesktop.UserControls;
using UnifiDesktop.UserControls.V2;
using UnifiDesktop.DrawingUtils;
using Unifi.Logging;
using UnifiDesktop.Logging;
//using UnifiCommands.Socket;

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

        private ListBox _lstRollbackPosition = null;

        public TestTool()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _logger = new DesktopLogger(txtConsole);
            //SocketCommandServer.Instance.Start(_logger);

            GetInstallFolderFromRegistry();
            LoadSettings();
            LoadControls();
            AddListeners();
            SetupEventHandlers();
        }

        private void SetupEventHandlers()
        {
            grpConfig.DoubleClick += InstallProduct;
            //grpProduct.DoubleClick += InstallProduct;
            //grpRunMode.DoubleClick += InstallProduct;
            //grpInstallMode.DoubleClick += InstallProduct;
        }

        private void TestTool_FormClosing(object sender, FormClosingEventArgs e)
        {
            RemoveListeners();
            //SocketCommandServer.Instance.Stop();
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
                    case VenueServer.R01:
                        rbR01.Checked = true;
                        break;
                    case VenueServer.R02:
                        rbR02.Checked = true;
                        break;
                    case VenueServer.QA2New:
                        rbQa2New.Checked = true;
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
                    Venue = VenueServer.R01,
                    InstallDirectory = Variables.CylanceDesktopFolder
                };
            }
            
            txtInstallDir.DataBindings.Add("Text", _programSettings, "InstallDirectory", true, DataSourceUpdateMode.OnPropertyChanged);
            chkDebugBuild.DataBindings.Add("Checked", _programSettings, "IsDebugMode", true, DataSourceUpdateMode.OnPropertyChanged);

            _programSettings.PropertyChanged += ProgramProgramSettingsChanged;
        }

        private void Venue_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            if (rb == null) return;

            _programSettings.Venue = rb.Text;
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
            DrawingHelper.SuspendDrawing(this);

            Stopwatch stopwatch= Stopwatch.StartNew();

            //if (!Debugger.IsAttached && File.Exists(Variables.JsonConfigPath))
            {
                _logger.LogInfo($"Copying config file from {Variables.JsonConfigPath} to {Variables.LocalJsonConfigPath}");
                Process p = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = "cmd.exe",
                        // When in VMs, once this file is opened and it will be locked on the shared folder. /j fixes that.
                        Arguments = $"/C xcopy \"{Variables.JsonConfigPath}\" \"{Variables.LocalJsonConfigPath}\" /j /Y",
                        CreateNoWindow = true,
                        UseShellExecute = false
                    }
                };
                p.Start();
                p.WaitForExit();
            }

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

            reportGrid1.DosTasks = _commandsProvider.DosTasks;
            reportGrid1.Logger = _logger;
            _commandsRunner = new CommandsRunner(reportGrid1, false, null, _logger, AppType.Desktop);

            PopulateDosCommandGroups();
            PopulateTaskbarCommands();
            //PopulateDownloadCommands();
            //PopulateRollbackPositions();
            PopulateBatchCommandList();
            PopulateInstallCommands();
            PopulateVersionGrid();
            PopulateServiceStateView();

            InitDownloadCommandGroup();

            ShowFilesVersions(null, null);

            stopwatch.Stop();
            UpdateFormTitle(stopwatch.ElapsedMilliseconds);

            DrawingHelper.ResumeDrawing(this);

        }

        private void UpdateFormTitle(long elapsedMilliseconds)
        {
            Text = $"{Assembly.GetExecutingAssembly().GetName().Name} {new FileInfo(Assembly.GetEntryAssembly().Location).LastWriteTime}";
            Text = $"{Text} {(BaseCommandInfo.ShowCommandOnMachine() == ShowCommandOnMachine.Dev ? "on Dev Machine" : "on Test Machine")}";
            if (IsElevated()) Text += " (Administrator)";
            Text = $"{Text} {elapsedMilliseconds} ms";
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

        private void PopulateServiceStateView()
        {
            serviceStatus1.Initialize(_commandsProvider.TestTasks.FirstOrDefault(t => t.CommandGroup == CommandGroup.ServiceState)?.Commands, new ServiceStatusLogger(txtConsole));
        }

        private void PopulateDosCommandGroups()
        {
            pnlDosCommands.Controls.Clear();
            DosCommandsTabControl tabControl = new DosCommandsTabControl(_programSettings, _commandsRunner, _logger);
            pnlDosCommands.Controls.Add(tabControl);
            tabControl.Dock = DockStyle.Fill;
            tabControl.PopulateDosTasks(_commandsProvider.DosTasks);
            pnlDosCommands.Width = tabControl.ClientWidth;
            tabControl.TabChanged += SetTabControlClientWidth;
        }

        private void SetTabControlClientWidth(object sender, EventArgs e)
        {
            pnlDosCommands.Width = (sender as DosCommandsTabControl).ClientWidth;
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

                if (rbQa2New.Checked) return Variables.QA2TokenNew;

                return Variables.R01Token;
            }
        }

        private string GetConfig
        {
            get
            {

                if (rbR02.Checked)
                    return rbR02.Tag.ToString();
                else if (rbQa2.Checked)
                    return rbQa2.Tag.ToString();
                else if (rbQa2New.Checked)
                    return rbQa2New.Tag.ToString() ;
                else
                    return rbR01.Tag.ToString();
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

        private string GetCylanceUiFullPath
        {
            get
            {
                return Variables.CylanceUiPath;
            }
        }

        //private string GetRollbackLogSaveDirectory
        //{
        //    get
        //    {
        //        string rollbackCategory = GetAmpplRollbackTestCategory(out string rollbackPosition);
        //        string archFolder = Environment.OSVersion.Version.CompareTo(new Version("6.2")) < 0
        //            ? "Win7"
        //            : Environment.Is64BitOperatingSystem ? "x64" : "x86";

        //        FullCommandInfo command = _lstRollbackPosition.SelectedItem as FullCommandInfo;
        //        string rollbackPositionFolder = command == null ? "" : $"{command.Arguments}-{command.DisplayText}";
        //        string saveFolder = Path.Combine(Variables.VmWareSharedFolder, $@"TestTools\Rollback\RollbackTestLogs\{archFolder}\{rollbackCategory}\{rollbackPositionFolder}");

        //        if (!Directory.Exists(saveFolder)) Directory.CreateDirectory(saveFolder);

        //        return saveFolder;
        //    }
        //}

        //private string GetLatestRollbackFile
        //{
        //    get
        //    {
        //        string logFolder = GetRollbackLogSaveDirectory;
        //        _logger.LogInfo($"Log folder is {logFolder}");

        //        var file = new DirectoryInfo(logFolder).GetFiles().OrderByDescending(f => f.LastWriteTime).FirstOrDefault();
        //        if (file == null) {
        //            _logger.LogInfo("No files found in the folder.");
        //            return "";
        //        }

        //        return Path.Combine(logFolder, file.Name);
        //    }
        //}

        //private string GetAmpplRollbackTestCategory(out string rollbackPosition)
        //{
        //    rollbackPosition = "";
        //    if (_lstRollbackPosition.SelectedItem == null ||
        //        _lstRollbackPosition.SelectedIndex <= 0 ||
        //        _lstRollbackPosition.Text.Trim() == "")
        //    {
        //        return "";
        //    }

        //    if (_lstRollbackPosition.Text.Trim().StartsWith(CategoryPrefix))
        //    {
        //        rollbackPosition = Rollback.RollbackCategoryName.None;
        //        if (_lstRollbackPosition.Text.Contains("Add")) return Rollback.RollbackCategoryName.AddAmppl;
        //        if (_lstRollbackPosition.Text.Contains("Remove")) return Rollback.RollbackCategoryName.RemoveAmppl;
        //        if (_lstRollbackPosition.Text.Contains("Update")) return Rollback.RollbackCategoryName.UpdateAmppl;
        //    }

        //    rollbackPosition = _lstRollbackPosition.Text;
        //    for (int i = _lstRollbackPosition.SelectedIndex-1; i >= 0; i--)
        //    {
        //        string currentItemText = _lstRollbackPosition.Items[i].ToString().Trim();
        //        if (currentItemText.StartsWith(CategoryPrefix))
        //        {
        //            if (currentItemText.Contains("Add")) return Rollback.RollbackCategoryName.AddAmppl;
        //            if (currentItemText.Contains("Remove")) return Rollback.RollbackCategoryName.RemoveAmppl;
        //            if (currentItemText.Contains("Update")) return Rollback.RollbackCategoryName.UpdateAmppl;
        //        }
        //    }

        //    return "";
        //}

        private string CompileMode => chkDebugBuild.Checked ? "Debug" : "";

        //private string GetRollbackPosition => _lstRollbackPosition.SelectedItem == null ? Rollback.RollbackCategoryName.None : _lstRollbackPosition.Text;

#endregion

#region Task Population Functions

        private void PopulateTaskbarCommands()
        {
            var tasks = _commandsProvider.TaskBarCommands.ToArray();
            
            pnlTaskBar.Controls.Clear();
            for (int i = tasks.Length - 1; i >= 0; i--)
            {
                FullCommandInfo command = tasks[i];

                TaskButton btn = new TaskButton(command, _logger)
                {
                    Dock = DockStyle.Left,
                    Width = 60,
                };

                pnlTaskBar.Controls.Add(btn);
            }
        }

        private void PopulateInstallCommands()
        {
            var groups = _commandsProvider.TestTasks.Where(t => t.CommandGroup == CommandGroup.Install).ToList();
            lstInstall.DisplayMember = "Name";
            lstInstall.DataSource = groups;

            installOptionsGroup1.SetCommands( _commandsProvider.TestTasks.FirstOrDefault(t => t.CommandGroup == CommandGroup.InstallSetup)?.Commands,
                _commandsProvider.TestTasks.FirstOrDefault(t => t.CommandGroup == CommandGroup.InstallCommand)?.Commands);
            installOptionsGroup1.Logger = _logger;
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

        //private async void lstRollbackPosition_Click(object sender, EventArgs e)
        //{
        //    if (_lstRollbackPosition.Items.Count == 0) return;

        //    if (_lstRollbackPosition.SelectedItem == null)
        //    {
        //        _lstRollbackPosition.SelectedIndex = 0;
        //    }

        //    if (_lstRollbackPosition.Text.Trim().StartsWith(CategoryPrefix))
        //    {
        //        return;
        //    }

        //    string category = GetAmpplRollbackTestCategory(out string position);

        //    await new SetRollbackCommand(category, position, _logger).Execute();
        //}

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
                FullCommandInfo.DisplayCommand(info, _logger, AppType.Desktop);
            }
        }

        private void TestTools_KeyDown(object sender, KeyEventArgs e)
        {
            if (e != null && e.KeyCode == Keys.F5)
            {
                LoadControls();
                return;
            }

            if (e.KeyCode == Keys.Space && e.Modifiers == Keys.Control)
            {
                navBarDrawer1.DrawerVisible = ! navBarDrawer1.DrawerVisible;
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


