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
using Timer = System.Timers.Timer;

namespace UnifiDesktop.UserControls
{
    public partial class ServiceStatus : UserControl
    {

        private Timer _timer = null;
        private List<FullCommandInfo> _commandInfos;
        private Command[] _commands;

        public List<FullCommandInfo> Commands
        {
            get { return _commandInfos; }
            set
            {
                _commandInfos = value;
                PopulateCommands();
            }

        }
        public ILogger Logger { get; set; }

        public ServiceStatus()
        {
            InitializeComponent();
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

                Command command = CommandFactory.CreateCommand(c, Logger, AppType.Desktop);
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

                Logger?.LogInfo($"Service state checking stopped");
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

            Logger?.LogInfo($"Service state checking interval started with interval {rb.Text}");
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
