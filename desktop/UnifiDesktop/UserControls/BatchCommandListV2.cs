using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using UnifiCommands.CommandInfo;
using UnifiCommands.CommandsProvider;
using UnifiDesktop.UserControls.ListBox;

namespace UnifiDesktop.UserControls
{
    public partial class BatchCommandListV2 : WebTabControl
    {
        private List<TestTask> _testTasks= new List<TestTask>();

        public List<TestTask> TestTasks 
        { 
            set
            {
                _testTasks = value;
                PopulateTestTasks();
            } 
        }

        public BatchCommandListV2()
        {
            InitializeComponent();
        }

        private void PopulateTestTasks()
        {
            if (_testTasks.Count == 0) return;

            // Create first tabpage for list of batch tasks.
            lstList.DataSource = _testTasks;
            lstList.DisplayMember = "Name";
            lstList.SelectedIndexChanged += OnSelectedTaskChange;

            //WebTabPage page1 = new WebTabPage
            //{
            //    HeaderCaption = "List",
            //    Control = _lstTestTasks
            //};

            //// Create second tabpage for list of commands for a selectd test task.
            SetupListViewColumns();

            //WebTabPage page2 = new WebTabPage
            //{
            //    HeaderCaption = "Commands",
            //    Control = _lstCommands
            //};

            ////TabPages = new List<WebTabPage> { page1, page2 };

            //PopulateCommands(_testTasks[0].Commands);
        }

        private void SetupListViewColumns()
        {
            lstCommands.Columns.Clear();
            lstCommands.Columns.Add("");
            lstCommands.Columns.Add("");
            lstCommands.HeaderStyle = ColumnHeaderStyle.None;
            lstCommands.View = View.Details;
            ResizeColumn();
        }

        private void ResizeColumn()
        {
            if (lstCommands.Columns.Count <= 1) return;
            lstCommands.Columns[0].Width = 16;
            lstCommands.Columns[1].Width = Width - lstCommands.Columns[0].Width - 33;

        }

        private void OnSelectedTaskChange(object sender, EventArgs e)
        {
            if (sender == null) return;

            TestTask t = (TestTask)lstList?.SelectedItem;
            if (t == null) return;

            PopulateCommands(t.Commands);
        }

        private void PopulateCommands(List<FullCommandInfo> commands)
        {
            lstCommands.Items.Clear();
            foreach (var command in commands)
            {
                lstCommands.Items.Add(
                    new ListViewItem(new[] { " ", command.DisplayText })
                    {
                        UseItemStyleForSubItems = true,
                        Tag = command,
                        ForeColor = command.Type == UnifiCommands.CommandInfo.CommandType.Code ? Color.Green : Color.Black
                    }
                );
            }
        }
    }
}
