using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using UnifiCommands;
using UnifiCommands.CommandInfo;
using UnifiCommands.Commands;
using UnifiCommands.Logging;
using UnifiCommands.Socket;
using WebSocketSharp;
using Timer = System.Timers.Timer;

namespace UnifiDesktop.UserControls.StatusUpdate
{
    public partial class UpdateByInterval : UserControl
    {
        private Timer _timer = null;
        private WebSocket _client;
        private List<FullCommandInfo> _commandInfos;
        private Command[] _commands;
        private object _variableSource;

        public UpdateByInterval()
        {
            InitializeComponent();
            SetupListView();
        }

        protected virtual void SetupListView() { }

        protected virtual string ChannelName => "";

        protected ILogger Logger;

        public void Initialize(List<FullCommandInfo> commandInfos, ILogger logger, object variableSource)
        {
            Logger = logger;
            _variableSource = variableSource;
            _commandInfos = commandInfos;
            PopulateCommands();
            OnTimerElapse(null, null);
            Task.Run(SetupSocket);
        }

        private Task SetupSocket()
        {
            if (_client == null)
            {
                _client = new WebSocket($"{SocketCommandServer.SocketUrl}/{ChannelName}");
                _client.OnOpen += (sender, e) =>
                {
                    SocketCommandServer.Instance.LogMessage($"UpdateServiceState control conected to socket channel '{ChannelName}'.");
                };
                _client.OnError += (sender, e) => { Logger.LogError(e.Message); };
                _client.OnMessage += OnReceiveCommand;
                _client.WaitTime = new TimeSpan(1, 0, 0);
                _client.Connect();
            }
            else if (!_client.IsAlive)
            {
                _client.Connect();
            }

            return null;
        }

        private void OnReceiveCommand(object sender, MessageEventArgs e)
        {
            SocketCommandServer.Instance.LogMessage($"Component '{GetType().Name}' recieved data '{e.Data}'.");
            if (!int.TryParse(e.Data, out int seconds)) return;

            Logger.LogInfo($"Component {GetType().Name} recieved command to set interval to {seconds} seconds.");

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

                SetupTimer(seconds);
            }));
        }

        private void TimerInternvalClick(object sender, EventArgs e)
        {
            if (sender == null) return;

            RadioButton rb = (RadioButton)sender;
            SetupTimer(int.Parse(rb.Tag.ToString()));
        }

        private void SetupTimer(int seconds)
        {
            if (seconds <= 0)
            {
                if (_timer != null)
                    _timer.Enabled = false;

                Logger?.LogInfo($"Service state checking stopped");
                return;
            }

            if (_timer == null)
                _timer = new Timer();
            else
                _timer.Enabled = false;

            _timer.Interval = seconds * 1000;
            _timer.Elapsed += OnTimerElapse;
            _timer.Start();

            Logger?.LogInfo($"{GetType().Name} checking started with interval {seconds} seconds.");
        }

        private void PopulateCommands()
        {
            if (_commandInfos == null)
            {
                return;
            }

            lstItems.Items.Clear();
            SetupListView();

            List<Command> commands = new List<Command>();

            foreach (var c in _commandInfos)
            {
                var item = new ListViewItem(new[] { c.DisplayText, "" })
                {
                    UseItemStyleForSubItems = true,
                    Tag = c
                };

                lstItems.Items.Add(item);
                c.VariableValueSource = _variableSource;

                Command command = CommandFactory.CreateCommand(c, Logger, AppType.Desktop);
                commands.Add(command);
            }

            _commands = commands.ToArray();
            
        }


        protected virtual async void OnTimerElapse(object sender, EventArgs e)
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
            lstItems.BeginInvoke(new MethodInvoker(() => UpdateServiceState(rowIndex, result)));
        }

        private void UpdateServiceState(int rowIndex, string state)
        {
            if (rowIndex < lstItems.Items.Count)
                lstItems.Items[rowIndex].SubItems[1].Text = state;
        }
    }
}
