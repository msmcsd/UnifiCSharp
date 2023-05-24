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
        private List<FullCommandInfo> _installSetupCommands = new List<FullCommandInfo>();
        private List<FullCommandInfo> _preInstallCommands = new List<FullCommandInfo>();
        private List<FullCommandInfo> _installCommands = new List<FullCommandInfo>();
        private List<FullCommandInfo> _postInstallCommands = new List<FullCommandInfo>();
        private FullCommandInfo _uninstallCommand;

        public void SetCommands(List<TestTask> testTasks)
        {
            _installSetupCommands = testTasks.FirstOrDefault(t => t.CommandGroup == CommandGroup.InstallSetupCommands)?.Commands;
            _preInstallCommands = testTasks.FirstOrDefault(t => t.CommandGroup == CommandGroup.PreInstallCommands)?.Commands;
            _installCommands = testTasks.FirstOrDefault(t => t.CommandGroup == CommandGroup.InstallCommand)?.Commands;
            _postInstallCommands = testTasks.FirstOrDefault(t => t.CommandGroup == CommandGroup.PostInstallCommands)?.Commands;
            _uninstallCommand = testTasks.FirstOrDefault(t => t.CommandGroup == CommandGroup.UninstallCommand)?.Commands[0];

            SetVariableSource(_installSetupCommands);
            SetVariableSource(_preInstallCommands);
            SetVariableSource(_installCommands);
            SetVariableSource(_postInstallCommands);
            _uninstallCommand.VariableValueSource = this;
        }

        private void SetVariableSource(List<FullCommandInfo> commands)
        {
            foreach (var command in commands)
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
                    CompileMode = chkDebugBuild.Checked? "Debug": ""
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
            InstallProduct();
        }

        private void btnUninstall_Click(object sender, EventArgs e)
        {
            UninstallProduct();
        }

        private void UninstallProduct()
        {
            if (_uninstallCommand == null) return;

            RunCommands(new List<FullCommandInfo> { _uninstallCommand });
        }

        private void InstallProduct()
        {
            var commands = GetAllInstallCommands();
            RunCommands(commands);
        }

        private void RunCommands(List<FullCommandInfo> commands)
        {
            if (commands?.Count() == 0) return;

            var b = new BatchCommandExecutor(commands, false, null, Logger, AppType.Desktop);
            b.Execute();
        }

        private List<FullCommandInfo> GetAllInstallCommands()
        {
            if (_preInstallCommands.Count <= 0)
            {
                Logger.LogError("Pre install commands not found");
                return null;
            }

            if (_installCommands.Count <= 0)
            {
                Logger.LogError("Install commands not found");
                return null;
            }

            if (_postInstallCommands.Count <= 0)
            {
                Logger.LogError("Post install commands not found");
                return null;
            }

            List<FullCommandInfo> commands = new List<FullCommandInfo>();
            if (rbMsi.Checked)
            {
                if (!GetInstallerCommand(InstallerType.Msi, out var command)) return null;

                commands.AddRange(_installSetupCommands);
                commands.AddRange(_preInstallCommands);
                commands.Add(command);
            }
            else if (rbBootstrapper.Checked)
            {
                if (!GetInstallerCommand(InstallerType.Bootstrapper, out var command)) return null;

                commands.AddRange(_installSetupCommands);
                commands.AddRange(_preInstallCommands);
                commands.Add(command);
            }
            else
            {
                if (!GetInstallerCommand(InstallerType.CyUpgrade, out var command)) return null;

                commands.AddRange(_preInstallCommands);
                commands.Add(command);
            }

            commands.AddRange(_postInstallCommands);

            return commands;
        }


        private bool GetInstallerCommand(InstallerType installerType, out FullCommandInfo command)
        {
            command = _installCommands.FirstOrDefault(c => c.InstallerType == installerType);
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
                if (sender == btnInstall)
                    DisplayCommand(GetAllInstallCommands());
                else if (sender == btnUninstall)
                    DisplayCommand(new List<FullCommandInfo> { _uninstallCommand });
            }
        }

        private void DisplayCommand(List<FullCommandInfo> commands)
        {
            if (commands?.Count() == 0) return;

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

            txtInstallDir.DataBindings.Add("Text", _programSettings, "InstallDirectory", true, DataSourceUpdateMode.OnPropertyChanged);
            chkDebugBuild.DataBindings.Add("Checked", _programSettings, "IsDebugMode", true, DataSourceUpdateMode.OnPropertyChanged);

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

        private string GetProtectLogFileName => $"{DateTime.Today:yyyy-MM-dd}.log";

        private string ProtectLogPath => Path.Combine(CylanceDesktopFolder, $@"log\{GetProtectLogFileName}");

        #endregion

    }
}
