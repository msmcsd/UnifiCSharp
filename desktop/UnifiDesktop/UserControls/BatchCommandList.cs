﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unifi.Observers.Animation;
using UnifiCommands;
using UnifiCommands.CommandInfo;
using UnifiCommands.Commands.CodeCommands;
using UnifiCommands.CommandsProvider;
using UnifiCommands.Logging;
//using UnifiCommands.Socket;
//using UnifiCommands.Socket.Behaviors;

namespace UnifiDesktop.UserControls
{
    public partial class BatchCommandList : UserControl
    {
        public List<TestTask> TestTasks 
        {
            set
            {
                cmbList.DataSource = value;
                cmbList.DisplayMember = "Name";
            }
        }

        public ILogger Logger { get;  set; }

        public BatchCommandList()
        {
            InitializeComponent();
        }

        private void cmbList_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateBatchCommands();
        }

        private void PopulateBatchCommands()
        {
            if (cmbList.SelectedItem == null)
            {
                Debug.Fail("cmbList.SelectedItem is null");
                return;
            }

            TestTask t = (TestTask)cmbList.SelectedItem;
            PopulateCommands(t.Commands);
        }

        private void PopulateCommands(List<FullCommandInfo> commands)
        {
            lstCommands.Items.Clear();
            foreach(var command in commands)
            {
                lstCommands.Items.Add(
                    new ListViewItem(new[] { " ", command.DisplayText })
                    {
                        UseItemStyleForSubItems = true,
                        Tag = command, 
                        ForeColor = command.Type == CommandType.Code ? Color.Green : Color.Black
                    }
                );
            }
        }

        private void lstCommands_DoubleClick(object sender, EventArgs e)
        {
            btnRun_Click(sender, e);
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            Task.Run(RunBatchCommands);
        }

        private void RunBatchCommands()
        {
            if (lstCommands.Items.Count == 0)
            {
                Debug.WriteLine(GetType(), "lstCommands.Items.Count = 0");
                return;
            }
            Task.Run(ClearStatusMarks);

            TestTask t = (TestTask)cmbList.SelectedItem;

            Logger.LogInfo($"Batch comands start: {t.Name}");
            var b = new BatchCommandExecutor(t.Commands, true, null, Logger, AppType.Desktop);
            b.RegisterObserver(new BatchListViewUpdater(lstCommands));
            b.Execute();
        }

        private void ClearStatusMarks()
        {
            lstCommands.BeginInvoke(new MethodInvoker(() =>
            {
                if (lstCommands.Items.Count > 0)
                {
                    for (int i = 0; i < lstCommands.Items.Count; i++)
                    {
                        lstCommands.Items[i].SubItems[0].Text = "";
                    }
                }
            }));
        }

        private void BatchCommandList_Resize(object sender, EventArgs e)
        {
            colStatus.Width = 16;
            colCommand.Width = Width - colStatus.Width - 8;
        }

        private void lstCommands_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            if (lstCommands.Items.Count <= 0 || e.Item == null) return;

            if ((e.State & ListViewItemStates.Selected) == 0)
            {
                // Draw the background and focus rectangle for a selected item.
                e.Graphics.FillRectangle(Brushes.Maroon, e.Bounds);
                e.DrawFocusRectangle();
            }
            else
            {
                e.DrawDefault = true;
            }

            e.DrawBackground();
        }

        private void lstCommands_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            if (lstCommands.Items.Count <= 0 || e.Item == null) return;
            if (e.ColumnIndex != 1) return;

            FullCommandInfo info = (FullCommandInfo)e.Item.Tag;

            Brush brush = info.Type == CommandType.Code ? Brushes.Green : Brushes.Black;
            e.Graphics.DrawString(e.Item.SubItems[1].Text, lstCommands.Font, brush, e.Bounds);
        }

    }
}
