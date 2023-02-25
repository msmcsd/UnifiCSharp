using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
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
        private readonly ProgramSettings _programSettings;
        private readonly CommandsRunner _commandsRunner;
        private readonly ILogger _logger;
        private bool _clearingPanels;
        private TabHeader[] _tabNames;
        private TabHeader _preTabHeader = null;

        public DosCommandsTabControl()
        {
            InitializeComponent();
        }

        public DosCommandsTabControl(ProgramSettings programSettings, CommandsRunner commandsRunner, ILogger logger): this()
        {
            _programSettings = programSettings;
            _commandsRunner = commandsRunner;
            _logger = logger;
        }

        public ListBox PopulateDosTasks(List<TestTask> testTasks)
        {
            //tabCommands.Width = 160;
            _clearingPanels = true;
            tabCommands.TabPages.Clear();
            _clearingPanels = false;

            List<TabHeader> lstHeaders = new List<TabHeader>();
            ListBox lstRollbackPosition = null;
            int tabIndex = 0;

            foreach (var tabName in Enum.GetNames(typeof(DosTab)))
            {
                var tasks = testTasks.Where(t => t.Tab.ToString() == tabName).ToList();
                if (tasks.Any())
                {
                    TabPage page = new TabPage(tabName);
                    tabCommands.TabPages.Add(page);
                    AddComandGroupsToTab(page, tasks);

                    TabHeader tabHeader = new TabHeader(tabName, tabIndex);
                    tabHeader.Click += OnHeaderClick;
                    lstHeaders.Add(tabHeader);
                    tabIndex++;

                    if (tabName == DosTab.Rollback.ToString())
                    {
                        lstRollbackPosition = FindRollbackListBox(page);
                    }
                }
            }

            _tabNames = lstHeaders.ToArray();
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
            int top = (pnlHeader.Height - _tabNames[0].Height)/2;

            for (int i = 0; i < _tabNames.Length; i++) {
                pnlHeader.Controls.Add(_tabNames[i]);
                _tabNames[i].Location = new Point(left, top);
                left += _tabNames[i].Width;
            }
        }

        private void AddComandGroupsToTab(TabPage tab, IEnumerable<TestTask> tasks)
        {
            int left = 0;
            int top = 0;
            int columns = 1;
            int controlWidth = 160;

            tab.Controls.Clear();

            foreach (var task in tasks)
            {
                if (task.Commands.Count == 0) continue;

                var card = new DosCommandCard(task, _commandsRunner, _logger) { Width = controlWidth };

                tab.Controls.Add(card);

                if (top + card.Height > tab.Height)
                {
                    left = left + card.Width;
                    top = 0;
                    columns++;

                    if (card.Width * columns > tab.Parent.Width)
                        tab.Parent.Width += card.Width;
                }

                card.Left = left;
                card.Top = top;

                top += card.Height;
            }
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
        }

        private void MoveUnderLine(int endIndex)
        {
            int loops = 10;
            TabHeader endHeader = _tabNames[endIndex];
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
    }
}
