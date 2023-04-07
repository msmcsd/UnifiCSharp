using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Unifi;
using Unifi.UserControls;
using UnifiCommands.CommandsProvider;
using UnifiCommands.Logging;

namespace UnifiDesktop.UserControls
{
    internal partial class DosCommandsTabControlV2 : WebTabControl
    {
        public event EventHandler TabChanged;

        private readonly ProgramSettings _programSettings;
        private readonly CommandsRunner _commandsRunner;
        private readonly ILogger _logger;
        private bool _clearingPanels;
        private Dictionary<TabPage, int> _tabInfo = new Dictionary<TabPage, int>();

        // Default card size that holds 7 list itema each card and three cards per column in card container.
        private const int CardWidth = 160;
        private const int CardHeight = 195;
        private const int DefaultClientWidth = CardWidth + 15; // Leave space to the right of card list container.

        public int ClientWidth => _tabInfo[tabControl.SelectedTab] < MinControlWidth ? MinControlWidth : _tabInfo[tabControl.SelectedTab];

        public DosCommandsTabControlV2()
        {
            InitializeComponent();
        }

        public DosCommandsTabControlV2(ProgramSettings programSettings, CommandsRunner commandsRunner, ILogger logger) : this()
        {
            _programSettings = programSettings;
            _commandsRunner = commandsRunner;
            _logger = logger;
        }

        public void PopulateDosTasks(List<TestTask> testTasks)
        {
            _clearingPanels = true;
            tabControl.TabPages.Clear();
            _clearingPanels = false;

            foreach (var tabName in Enum.GetNames(typeof(DosTab)))
            {
                var tasks = testTasks.Where(t => t.Tab.ToString().Equals(tabName, StringComparison.InvariantCultureIgnoreCase)).ToList();
                if (tasks.Any())
                {
                    TabPage page = new TabPage(tabName);
                    tabControl.TabPages.Add(page);
                    int clientWidth = AddComandGroupsToTab(page, tasks);
                    _tabInfo[page] = clientWidth;
                }
            }

            CreatTabHeaderLabels();

            if (_programSettings != null && _programSettings.Tab >= 0 && _programSettings.Tab <= tabControl.TabPages.Count - 1)
                tabControl.SelectedIndex = _programSettings.Tab;
            else
                tabControl.SelectedIndex = 0;

            MoveUnderLine(tabControl.SelectedIndex);
            OnTabChanged(this, null);
        }

        private int AddComandGroupsToTab(TabPage tab, IEnumerable<TestTask> tasks)
        {
            int left = 0;
            int top = 0;
            int columns = 1;
            int clientWidth = DefaultClientWidth;

            tab.Controls.Clear();

            foreach (var task in tasks)
            {
                if (task.Commands.Count == 0) continue;

                var card = new DosCommandCard(task, _commandsRunner, _logger) { Width = CardWidth };

                tab.Controls.Add(card);

                if (top + card.Height > tab.Height)
                {
                    left = left + card.Width;
                    top = 0;
                    columns++;

                    if (card.Width * columns > clientWidth)
                        clientWidth += card.Width;
                }

                card.Left = left;
                card.Top = top;

                top += card.Height;
            }

            return clientWidth;
        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_clearingPanels && tabControl.SelectedIndex >= 0)
            {
                if (_programSettings != null)
                {
                    _programSettings.Tab = tabControl.SelectedIndex;
                }
            }

            OnTabChanged(this, e);
        }

        private void OnTabChanged(object sender, EventArgs e)
        {
            TabChanged?.Invoke(this, e);
        }
    }
}
