using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Windows.Forms;
using UnifiCommands.CommandsProvider;
using UnifiCommands.Logging;
using UnifiDesktop.DrawingUtils;

namespace UnifiDesktop.UserControls.V2
{
    public partial class DosCommandCardCustom : UserControl
    {
        private CommandItem[] _listItems;
        private readonly ILogger _logger;
        private int _preSelectedIndex = -1;

        public DosCommandCardCustom()
        {
            InitializeComponent();
        }

        public DosCommandCardCustom(TestTask testTask, ILogger logger)
        {
            InitializeComponent();
            _logger = logger;
            PopulateTask(testTask);
        }

        private void PopulateTask(TestTask testTask)
        {
            lblGroupDesc.Text = testTask.Name;

            int itemPadding = 2;
            int bottomPadding = itemPadding * 2;
            int top = lblGroupDesc.Top + lblGroupDesc.Height + itemPadding * 3;
            int left = 5;
            int index = 0;

            List<CommandItem> listItems = new List<CommandItem>();

            CommandItem listItem = null;
            foreach (var command in testTask.Commands)
            {
                listItem = new CommandItem(_logger)
                {
                    Left = left,
                    Top = top,
                    Width = Width - left * 2,
                    Height = 25,
                    Index = index,
                    Tag = command
                };
                listItem.Label.Text = command.DisplayText;
                listItem.SelectedItemEventHandler += ListItemSelectedIndexChanged;

                if (top + listItem.Height + itemPadding > Height)
                {
                    int diff = top + listItem.Height + itemPadding - Height;
                    Height += diff;
                }

                Controls.Add(listItem);
                listItems.Add(listItem);

                top = top + listItem.Height + itemPadding;
                index++;
            }

            if (listItem.Top + listItem.Height + bottomPadding > Height)
            {
                int diff = listItem.Top + listItem.Height + bottomPadding - Height;
                Height += diff;
            }

            _listItems = listItems.ToArray();
        }

        private void ListItemSelectedIndexChanged(object sender, SelectedItemEventArgs e)
        {
            //foreach(var item in _listItems)
            //{
            //    if (item.Index != e.SelectedIndex)
            //    {
            //        item.Selected = false;
            //    }
            //}

            if (_preSelectedIndex < 0)
            {

                _preSelectedIndex = e.SelectedIndex;
                return;
            }

            //var item = _listItems.FirstOrDefault(i => i.Index == _preSelectedIndex);
            //if (item != null) item.Selected = false;
            _listItems[_preSelectedIndex].Selected = false;

            _preSelectedIndex = e.SelectedIndex;
        }

        private void DosCommandCard_Paint(object sender, PaintEventArgs e)
        {
            DrawingUtils.DrawingHelper.DrawRoundBorder(this, e.Graphics, 3);
        }
    }
}
