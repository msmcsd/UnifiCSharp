using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using Unifi;
using Unifi.UserControls;
using UnifiCommands.CommandInfo;
using UnifiCommands.CommandsProvider;
using UnifiCommands.Logging;

namespace UnifiDesktop.UserControls.V2
{
    internal partial class DosCommandsTabControl : UserControl
    {
        public event EventHandler TabChanged;

        private readonly ProgramSettings _programSettings;
        private readonly CommandsRunner _commandsRunner;
        private readonly ILogger _logger;
        private bool _clearingPanels;
        private List<TabInfo> _tabInfo = new List<TabInfo>();
        private TabHeaderLabel _preTabHeader = null;

        // Default card size that holds 7 list item each card and three cards per column in card container.
        private const int CardWidth = 160;
        private const int CardHeight = 195;
        private const int DefaultClientWidth = CardWidth + 15; // Leave space to the right of card list container.
        private int _minClientWidth; // Width that ensures all tab header labels are visible if there are only few columns of DosCommandsCard.

        public int ClientWidth => _tabInfo[_preTabHeader.Index].TabClientWidth < _minClientWidth ? _minClientWidth : _tabInfo[_preTabHeader.Index].TabClientWidth;

        public DosCommandsTabControl()
        {
            InitializeComponent();
        }

        private void OnTabChanged(object sender, EventArgs e)
        {
            TabChanged?.Invoke(this, e);
        }

        public DosCommandsTabControl(ProgramSettings programSettings, CommandsRunner commandsRunner, ILogger logger): this()
        {
            _programSettings = programSettings;
            _commandsRunner = commandsRunner;
            _logger = logger;
        }

        public ListBox PopulateDosTasks(List<TestTask> testTasks)
        {
            //Width = _clientWidth;
            _clearingPanels = true;
            tabCommands.TabPages.Clear();
            _clearingPanels = false;

            ListBox lstRollbackPosition = null;
            int tabIndex = 0;

            foreach (var tabName in Enum.GetNames(typeof(DosTab)))
            {
                var tasks = testTasks.Where(t => t.Tab.ToString() == tabName).ToList();
                if (tasks.Any())
                {
                    TabPage page = new TabPage(tabName);
                    tabCommands.TabPages.Add(page);
                    int clientWidth = AddComandGroupsToTab(page, tasks);

                    TabHeaderLabel tabHeader = new TabHeaderLabel(tabName, tabIndex);
                    tabHeader.Click += OnHeaderClick;
                    _tabInfo.Add(new TabInfo { TabHeaderLabel = tabHeader, TabClientWidth = clientWidth});
                    tabIndex++;

                    if (tabName == DosTab.Rollback.ToString())
                    {
                        lstRollbackPosition = FindRollbackListBox(page);
                    }
                }
            }

            PopulateTabNames();

            if (_programSettings != null && _programSettings.Tab >= 0 && _programSettings.Tab <= tabCommands.TabPages.Count - 1)
                tabCommands.SelectedIndex = _programSettings.Tab;
            else
                tabCommands.SelectedIndex = 0;

            MoveUnderLine(tabCommands.SelectedIndex);

            return lstRollbackPosition;
        }

        private void PopulateTabNames()
        {
            int left = 0;
            int top = (pnlHeader.Height - _tabInfo[0].TabHeaderLabel.Height)/2;

            for (int i = 0; i < _tabInfo.Count; i++) {
                pnlHeader.Controls.Add(_tabInfo[i].TabHeaderLabel);
                _tabInfo[i].TabHeaderLabel.Location = new Point(left, top);
                left += _tabInfo[i].TabHeaderLabel.Width;
            }

            _minClientWidth = left;
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

        private ListBox FindRollbackListBox(TabPage page)
        {
            foreach (var ctrl in page.Controls)
            {
                if (ctrl is DosCommandGroup commandGroup)
                {
                    if (commandGroup.ListBox.Items.Count > 0)
                    {
                        foreach (var item in commandGroup.ListBox.Items)
                        {
                            FullCommandInfo command = (FullCommandInfo)item;
                            if (command.Command.Equals("SetRollback", StringComparison.InvariantCultureIgnoreCase))
                            {
                                return commandGroup.ListBox;
                            }
                        }
                    }
                }
            }
            return null;
        }

        private void tabCommands_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_clearingPanels && tabCommands.SelectedIndex >= 0)
            {
                if (_programSettings != null)
                {
                    _programSettings.Tab = tabCommands.SelectedIndex;
                }
            }

            OnTabChanged(this, e);
        }

        private void MoveUnderLine(int endIndex)
        {
            int loops = 10;
            TabHeaderLabel endHeader = _tabInfo[endIndex].TabHeaderLabel;
            int startPosition = lblUnderline.Left;
            int endPosition = endHeader.Left;
            int pixelPerLoopInPosition = (endPosition - startPosition) / loops;
            int pixelPerLoopInWidth = (endHeader.Width - lblUnderline.Width) / loops;

            if (_preTabHeader != null) _preTabHeader.SetInactiveColor();
            endHeader.SetActiveColor();
            _preTabHeader = endHeader;

            for (int i = 0; i < loops; i++)
            {
                lblUnderline.Left += pixelPerLoopInPosition;
                lblUnderline.Width += pixelPerLoopInWidth;
                lblUnderline.Refresh();
                Thread.Sleep(10);
            }

            lblUnderline.Left = endPosition;
            lblUnderline.Width = endHeader.Width;
        }

        private void OnHeaderClick(object sender, EventArgs e)
        {
            int index = (int) (sender as Label).Tag;

            MoveUnderLine(index);
            tabCommands.SelectedIndex = index;
        }

        class TabInfo
        {
            public TabHeaderLabel TabHeaderLabel { get; set; }
            
            public int TabClientWidth { get; set; }
        }
    }
}
