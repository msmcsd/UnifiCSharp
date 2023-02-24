using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Windows.Forms;
using UnifiCommands.CommandsProvider;
using UnifiDesktop.DrawingUtils;

namespace UnifiDesktop.UserControls.V2
{
    public partial class DosCommandCard : UserControl
    {
        private TestTask _testTask;
        public TestTask TestTask 
        {
            set
            {
                _testTask = value;
                PopulateTask();
            }
        }

        private List<ListItem> _listItems = new List<ListItem>();
        public DosCommandCard()
        {
            InitializeComponent();
        }

        private void DosCommandCard_Load(object sender, EventArgs e)
        {
            //LoadItems();
        }

        private void PopulateTask()
        {
            lblGroupDesc.Text = _testTask.Name;

            int itemPadding = 2;
            int bottomPadding = itemPadding * 2;
            int top = lblGroupDesc.Top + lblGroupDesc.Height + itemPadding * 3;
            int left = 5;
            int index = 0;

            ListItem listItem = null;
            foreach (var command in _testTask.Commands)
            {
                listItem = new ListItem
                {
                    Left = left,
                    Top = top,
                    Width = Width - left * 2,
                    Height = 25,
                    Index = index
                };
                listItem.Label.Text = command.DisplayText;
                listItem.SelectedItemEventHandler += ListItemSelectedIndexChanged;

                if (top + listItem.Height + itemPadding > Height)
                {
                    int diff = top + listItem.Height + itemPadding - Height;
                    Height += diff;
                }

                Controls.Add(listItem);
                _listItems.Add(listItem);

                top = top + listItem.Height + itemPadding;
                index++;
            }

            if (listItem.Top + listItem.Height + bottomPadding > Height)
            {
                int diff = listItem.Top + listItem.Height + bottomPadding - Height;
                Height += diff;
            }
        }

        private void LoadItems()
        {
            int itemPadding = 2;
            int bottomPadding = itemPadding * 2;
            int top = lblGroupDesc.Top + lblGroupDesc.Height + itemPadding * 3;
            int left = 5;
            for (int i = 0; i< 6; i++)
            {
                ListItem listItem = new ListItem
                {
                    Left = left,
                    Top = top,
                    Width = Width - left * 2,
                    Height=25,
                    Index = i
                };
                listItem.Label.Text = $"a test string sdh asf rg sdg  a {i}";
                listItem.SelectedItemEventHandler += ListItemSelectedIndexChanged;

                if (top + listItem.Height + itemPadding > Height)
                {
                    int diff = top + listItem.Height + itemPadding - Height;
                    Height += diff;
                }
                
                Controls.Add(listItem);
                _listItems.Add(listItem);

                top = top + listItem.Height + itemPadding;
            }

        }

        private void ListItemSelectedIndexChanged(object sender, SelectedItemEventArgs e)
        {
            foreach(var item in _listItems)
            {
                if (item.Index != e.SelectedIndex)
                {
                    item.Selected = false;
                }
            }
        }

        private void DosCommandCard_Paint(object sender, PaintEventArgs e)
        {
            DrawControlBorder.Draw(this, e.Graphics, 3);
        }
    }
}
