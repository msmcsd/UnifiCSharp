using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unifi;
using Unifi.Observers.Animation;
using UnifiCommands;
using UnifiCommands.CommandInfo;
using UnifiCommands.CommandsProvider;
using UnifiCommands.Logging;
using UnifiCommands.Socket;
using UnifiCommands.Socket.Behaviors;
using UnifiCommands.Socket.MessageClasses;
using UnifiDesktop.DrawingUtils;
using WebSocketSharp;

namespace UnifiDesktop.UserControls
{
    public partial class InstallOptionsGroup : UserControl
    {
        private List<TestTask> _installSetupTasks;
        private List<TestTask> _preInstallTasks;
        private List<TestTask> _installTasks;
        private List<TestTask> _postInstallCommands;
        private List<TestTask> _uninstallCommand;

        public void SetCommands(List<TestTask> testTasks)
        {
            _installSetupTasks = testTasks.Where(t => t.CommandGroup == CommandGroup.Install && t.InstallCommandType == InstallCommandType.Setup).ToList();
            _preInstallTasks = testTasks.Where(t => t.CommandGroup == CommandGroup.Install && t.InstallCommandType == InstallCommandType.PreInstall).ToList();
            _installTasks = testTasks.Where(t => t.CommandGroup == CommandGroup.Install && t.InstallCommandType == InstallCommandType.Install).ToList();
            _postInstallCommands = testTasks.Where(t => t.CommandGroup == CommandGroup.Install && t.InstallCommandType == InstallCommandType.PostInstall).ToList();
            _uninstallCommand = testTasks.Where(t => t.CommandGroup == CommandGroup.Install && t.InstallCommandType == InstallCommandType.Uninstall).ToList();

            SetVariableSource(_installSetupTasks);
            SetVariableSource(_preInstallTasks);
            SetVariableSource(_installTasks);
            SetVariableSource(_postInstallCommands);
            SetVariableSource(_uninstallCommand);
        }

        private void SetVariableSource(List<TestTask> testTasks)
        {
            foreach(var task in testTasks)
                foreach (var command in task.Commands)
                {
                    command.VariableValueSource = this;
                }
        }

        public ILogger Logger { get; set; }

        public TestTask PrerequisiteTask { get; set; }

        private ProgramSettings _programSettings;
        public ProgramSettings ProgramSettings 
        { 
            get => _programSettings;
            set
            {
                _programSettings = value;
                PopulateSettings();
            }
        }

        public InstallOptionsGroup()
        {
            InitializeComponent();
            Task.Run(SetupSocketClient);
        }

        private WebSocket _client;
        private void SetupSocketClient()
        {
            if (_client == null)
            {
                _client = SocketUtils.CreateSocketClient(RequestInstallParametersBehavior.ChannelName, GetType().Name, OnReceiveCommand,
                                                         (sender, e) => { Logger.LogError(e.Message); });
            }
        }

        private void OnReceiveCommand(object sender, MessageEventArgs e)
        {
            Logger.LogSocketMessage(GetType(), $"Recieved data '{e.Data}'.");
            SocketMessage m = SocketUtils.DeserializeMessage(e.Data);
            if (m != null && m.Type == SocketMessageType.RequestInstallParameters)
            {
                Logger.LogSocketMessage(GetType(), $"Recieved message type {SocketMessageType.RequestInstallParameters} with data '{m.Data}'.");

                InstallParameters p = new InstallParameters
                {
                    CylanceDesktopFolder = CylanceDesktopFolder,
                    GetConfig = GetConfig,
                    GetInstallMode = GetInstallMode,
                    GetToken = GetToken,
                    CompileMode = chkDebugBuild.Checked? "Debug": "",
                    OpticsInstallerName = OpticsInstallerName
                };

                SocketMessage broadcastMessage = new SocketMessage
                {
                    Type = SocketMessageType.BroadcastInstallParameters,
                    Data = JsonConvert.SerializeObject(p)
                };

                SocketUtils.SendCommandToChannel(BroadcastInstallParametersBehavior.ChannelName, 
                                                 JsonConvert.SerializeObject(broadcastMessage), 
                                                 (sender1, evt) => { Logger.LogError(evt.Message); });
            }
        }

        private void btnInstall_Click(object sender, EventArgs e)
        {
            InstallProduct(rbProtect.Checked ? InstallProductType.Protect : InstallProductType.Optics);
        }

        private void btnUninstall_Click(object sender, EventArgs e)
        {
            UninstallProduct(rbProtect.Checked? InstallProductType.Protect : InstallProductType.Optics);
        }

        private void UninstallProduct(InstallProductType product)
        {
            if (_uninstallCommand == null) return;

            var command = _uninstallCommand.FirstOrDefault(t => t.Product == product)?.Commands[0];
            if (command == null)
            {
                MessageBox.Show("Uninstall command not found.");
                return;
            }

            RunCommands(new List<FullCommandInfo> { command });
        }

        private void InstallProduct(InstallProductType product)
        {
            var commands = GetAllInstallCommands(product);
            RunCommands(commands);
        }

        private void RunCommands(List<FullCommandInfo> commands)
        {
            if (commands?.Count() == 0) return;

            var b = new BatchCommandExecutor(commands, false, null, Logger, AppType.Desktop);
            b.Execute();
        }

        private List<FullCommandInfo> GetAllInstallCommands(InstallProductType product)
        {
            var installSetupCommands = _installSetupTasks.FirstOrDefault(t => t.Product == product)?.Commands;
            var preInstallCommands = _preInstallTasks.FirstOrDefault(t => t.Product == product)?.Commands;

            var installCommands = _installTasks.FirstOrDefault(t => t.Product == product)?.Commands;
            if (_installTasks.Count <= 0)
            {
                Logger.LogError("Install commands not found");
                return null;
            }

            List<FullCommandInfo> commands = new List<FullCommandInfo>();
            if (rbMsi.Checked)
            {
                if (!GetInstallerCommand(product, InstallerType.Msi, out var command)) return null;

                if (installSetupCommands?.Count > 0) commands.AddRange(installSetupCommands);
                if (preInstallCommands?.Count > 0) commands.AddRange(preInstallCommands);
                commands.Add(command);
            }
            else if (rbBootstrapper.Checked)
            {
                if (!GetInstallerCommand(product, InstallerType.Bootstrapper, out var command)) return null;

                if (installSetupCommands?.Count > 0) commands.AddRange(installSetupCommands);
                if (preInstallCommands?.Count > 0) commands.AddRange(preInstallCommands);
                commands.Add(command);
            }
            else
            {
                if (!GetInstallerCommand(product, InstallerType.CyUpgrade, out var command)) return null;

                commands.AddRange(preInstallCommands);
                commands.Add(command);
            }

            var postInstallCommands = _postInstallCommands.FirstOrDefault(t => t.Product == product)?.Commands;
            if (postInstallCommands?.Count > 0)
                commands.AddRange(postInstallCommands);

            return commands;
        }


        private bool GetInstallerCommand(InstallProductType product, InstallerType installerType, out FullCommandInfo command)
        {
            command = _installTasks.FirstOrDefault(t => t.Product == product)?.Commands?.FirstOrDefault(c => c.InstallerType == installerType);
            if (command == null)
            {
                Logger.LogError($"{installerType} install command not found");
                return false;
            }

            return true;
        }


        private void InstallOptionsGroup_Paint(object sender, PaintEventArgs e)
        {
            DrawingHelper.DrawRoundBorder(this, e.Graphics, 3);
        }

        private void btnInstall_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var product = rbProtect.Checked ? InstallProductType.Protect : InstallProductType.Optics;
                if (sender == btnInstall)
                    DisplayCommand(GetAllInstallCommands(product));
                else if (sender == btnUninstall)
                    DisplayCommand(_uninstallCommand.FirstOrDefault(t => t.Product == product)?.Commands);
            }
        }

        private void DisplayCommand(List<FullCommandInfo> commands)
        {
            if (commands == null) return;

            foreach (var command in commands)
                FullCommandInfo.DisplayCommand(command, Logger, AppType.Desktop);
        }

        private void Venue_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            if (rb == null) return;

            _programSettings.Venue = rb.Text;
        }

        private void PopulateSettings()
        {
            if (_programSettings == null) return;

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

            txtInstallDir.DataBindings.Clear();
            chkDebugBuild.DataBindings.Clear();
            txtInstallDir.DataBindings.Add("Text", _programSettings, "InstallDirectory", true, DataSourceUpdateMode.OnPropertyChanged);
            chkDebugBuild.DataBindings.Add("Checked", _programSettings, "IsDebugMode", true, DataSourceUpdateMode.OnPropertyChanged);

            _programSettings.PropertyChanged -= ProgramSettingsChanged;
            _programSettings.PropertyChanged += ProgramSettingsChanged;
        }

        private void ProgramSettingsChanged(object sender, PropertyChangedEventArgs e)
        {
            ProgramSettings s = sender as ProgramSettings;
            SettingsHelper.SaveSettings(s);
        }

        #region Reflection Methods

        private string CylanceDesktopFolder => txtInstallDir.Text;

        private string CompileMode => chkDebugBuild.Checked ? "Debug" : "";

        private string GetConfig
        {
            get
            {
                if (rbR02.Checked)
                    return rbR02.Tag.ToString();
                else if (rbQa2.Checked)
                    return rbQa2.Tag.ToString();
                else if (rbQa2New.Checked)
                    return rbQa2New.Tag.ToString();
                else
                    return rbR01.Tag.ToString();
            }
        }

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

        private string GetInstallMode
        {
            get
            {
                if (rbMsi.Checked)
                {
                    if (rbQuiet.Checked) return "/qb";
                }
                else if (rbBootstrapper.Checked)
                {
                    if (rbQuiet.Checked) return "/q";
                }
                return "";
            }
        }

        private string GetCylanceUiFullPath
        {
            get
            {
                return Variables.CylanceUiPath;
            }
        }

        private string OpticsInstallerName
        {
            get
            {
                return chkOptics2.Checked ? $"OpticsInstaller{Variables.ArchNone}" : $"CylanceOptics_x{Variables.Arch32}";
            }
        }

        //private string GetProtectLogFileName => $"{DateTime.Today:yyyy-MM-dd}.log";

        //private string ProtectLogPath => Path.Combine(CylanceDesktopFolder, $@"log\{GetProtectLogFileName}");

        #endregion

    }
}
