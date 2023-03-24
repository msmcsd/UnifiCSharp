using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using UnifiCommands;
using UnifiCommands.CommandInfo;
using UnifiCommands.Commands;
using UnifiCommands.CommandsProvider;
using UnifiCommands.Logging;
using UnifiDesktop.Socket;
using WebSocketSharp;
using Timer = System.Timers.Timer;

namespace UnifiDesktop.UserControls
{
    public partial class ServiceStatus : UserControl
    {

        private Timer _timer = null;
        private WebSocket _client;
        private ILogger _logger;
        private List<FullCommandInfo> _commandInfos;
        private Command[] _commands;

        public ServiceStatus()
        {
            InitializeComponent();
        }

        public void Initialize(List<FullCommandInfo> commandInfos, ILogger logger)
        {
            _commandInfos = commandInfos;
            _logger = logger;
            PopulateCommands();
            SetupSocket();
        }

        private void SetupSocket()
        {
            if (_client == null)
            {
                _client = new WebSocket(SocketServer.SocketUrl + "/" + UpdateServiceStateBehavior.ChannelName);
                _client.OnMessage += OnReceiveCommand;
                _client.WaitTime = new TimeSpan(1, 0, 0);
                _client.Connect();
                _logger.LogInfo($"ServiceState socket created. IsAlive={_client.IsAlive}");
            }
            else if (!_client.IsAlive)
            {
                _client.Connect();
            }
        }

        private void OnReceiveCommand(object sender, MessageEventArgs e)
        {
            if (!int.TryParse(e.Data, out int seconds)) return;

            _logger.LogInfo($"Recieve command to set interval to {seconds} seconds.");

            BeginInvoke(new MethodInvoker(() =>
            {
                switch (seconds)
                {
                    case 5:
                        rbSeconds5.Checked = true;
                        break;
                    case 60:
                        rbSeconds60.Checked = true;
                        break;
                    default:
                        rbNone.Checked = true;
                        break;
                }
            }));
        }

        private void SetupListView()
        {
            lstService.Columns[0].Width = 50;
            lstService.Columns[1].Width = 105;
        }

        private void PopulateCommands()
        {
            if (_commandInfos == null)
            {
                return;
            }

            lstService.Items.Clear();
            SetupListView();

            List<Command> commands = new List<Command>();

            foreach (var c in _commandInfos)
            {
                var item = new ListViewItem(new[] { c.DisplayText, "" })
                {
                    UseItemStyleForSubItems = true,
                    Tag = c
                };

                lstService.Items.Add(item);

                Command command = CommandFactory.CreateCommand(c, _logger, AppType.Desktop);
                commands.Add(command);
            }

            _commands = commands.ToArray();
            DisplayServiceState(null, null);
        }

        private void TimerInternvalClick(object sender, System.EventArgs e)
        {
            if (sender == null) return;

            RadioButton rb = (RadioButton)sender;
            if (rb == rbNone)
            {
                if (_timer != null)
                    _timer.Enabled = false;

                _logger?.LogInfo($"Service state checking stopped");
                return;
            }

            int interval = int.Parse(rb.Tag.ToString());
            if (_timer == null)
                _timer = new Timer();
            else
                _timer.Enabled = false;

            _timer.Interval = interval * 1000;
            _timer.Elapsed += DisplayServiceState;
            _timer.Start();

            _logger?.LogInfo($"Service state checking interval started with interval {rb.Text}");
        }

        private async void DisplayServiceState(object sender, System.EventArgs e)
        {
            List<Task> tasks = new List<Task>();
            for (int i = 0; i < _commands.Length; i++)
            {
                tasks.Add(RunCommand(_commands[i], i));
            }

            await Task.WhenAll(tasks);
        }

        private async Task RunCommand(Command command, int rowIndex)
        {
            string result = await command.Execute();
            lstService.BeginInvoke(new MethodInvoker(() => UpdateServiceState(rowIndex, result)));
        }

        private void UpdateServiceState(int rowIndex, string state)
        {
            if (rowIndex < lstService.Items.Count)
                lstService.Items[rowIndex].SubItems[1].Text = state;
        }
    }
}
