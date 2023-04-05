using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using UnifiCommands;
using UnifiCommands.CommandInfo;
using UnifiCommands.Commands;
using UnifiCommands.Logging;
using UnifiCommands.Socket;
using UnifiCommands.Socket.Behaviors;
using WebSocketSharp;
using Timer = System.Timers.Timer;

namespace UnifiDesktop.UserControls.StatusUpdate
{
    public partial class UpdateByInterval : UserControl
    {
        private Timer _timer = null;
        private WebSocket _client;
        protected List<FullCommandInfo> CommandInfos;
        private Command[] Commands;
        private object _variableSource;

        public UpdateByInterval()
        {
            InitializeComponent();
            SetupListView();
        }

        protected virtual void SetupListView() { }

        protected virtual string ChannelName => "";

        protected ILogger Logger;

        private bool _intervalVisible = true;
        public bool IntervalVisible 
        { 
            get => _intervalVisible; 
            set
            {
                _intervalVisible = value;
                pnlInterval.Visible = _intervalVisible;
            } 
        }

        public void Initialize(List<FullCommandInfo> commandInfos, ILogger logger, object variableSource)
        {
            Logger = logger;
            _variableSource = variableSource;
            CommandInfos = commandInfos;
            PopulateCommands();
            Task.Run(() => OnTimerElapse(null, null));
            Task.Run(SetupSocket);
        }

        private Task SetupSocket()
        {
            if (_client == null)
            {
                //_client = new WebSocket($"{SocketCommandServer.SocketUrl}/{ChannelName}");
                //_client.OnOpen += (sender, e) =>
                //{
                //    SocketCommandServer.Instance.LogMessage($"{GetType().Name} control conected to socket channel '{ChannelName}'.");
                //};
                //_client.OnError += (sender, e) => { Logger.LogError(e.Message); };
                //_client.OnMessage += OnReceiveCommand;
                //_client.WaitTime = new TimeSpan(1, 0, 0);
                //_client.Connect();

                _client = SocketUtils.CreateSocketClient(ChannelName, GetType().Name, OnReceiveCommand,
                                                         (sender, e) => { Logger.LogError(e.Message); });
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
            ProcessCommand(e.Data);
        }

        protected virtual void ProcessCommand(string socketData)
        {
            if (!int.TryParse(socketData, out int seconds)) return;

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
            if (CommandInfos == null)
            {
                return;
            }

            lstItems.Items.Clear();
            SetupListView();

            List<Command> commands = new List<Command>();

            foreach (var c in CommandInfos)
            {
                var item = new ListViewItem(ColumnsToShow(c))
                {
                    UseItemStyleForSubItems = true,
                    Tag = c
                };

                lstItems.Items.Add(item);
                c.VariableValueSource = _variableSource;

                Command command = CommandFactory.CreateCommand(c, Logger, AppType.Desktop);
                commands.Add(command);
            }

            Commands = commands.ToArray();
        }

        protected virtual string[] ColumnsToShow(FullCommandInfo c)
        {
            return new[] { c.DisplayText, "" };
        }

        protected virtual async void OnTimerElapse(object sender, EventArgs e)
        {
            List<Task> tasks = new List<Task>();
            for (int i = 0; i < Commands.Length; i++)
            {
                tasks.Add(RunCommand(Commands[i], i));
            }

            await Task.WhenAll(tasks);
        }
         
        private async Task RunCommand(Command command, int rowIndex)
        {
            string result = await command.Execute();
            lstItems.BeginInvoke(new MethodInvoker(() => UpdateGridRow(rowIndex, result)));
        }

        private void UpdateGridRow(int rowIndex, string state)
        {
            if (rowIndex < lstItems.Items.Count)
                lstItems.Items[rowIndex].SubItems[1].Text = state;
        }

        private void lstItems_DoubleClick(object sender, EventArgs e)
        {
            OnTimerElapse(sender, e);
        }
    }
}
