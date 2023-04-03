using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using UnifiDesktop.UserControls.V2;

namespace UnifiDesktop.UserControls
{
    public partial class WebTabControl : UserControl
    {
        private List<string> _headers = new List<string>() { };
        private TabInfo[] _tabInfos = new TabInfo[] { };
        private TabHeaderLabel _preTabHeader = null;

        private List<WebTabPage> _tabPages = new List<WebTabPage>() { };

        public WebTabControl()
        {
            InitializeComponent();
        }

        //[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        //[Editor("System.Windows.Forms.Design.StringCollectionEditor, System.Design, Culture=neutral", typeof(System.Drawing.Design.UITypeEditor))]
        public List<string> Headers 
        { 
            get => _headers;
            set 
            { 
                _headers= value;
                CreatTabHeader();
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<WebTabPage> TabPages
        {
            get => _tabPages;
            set
            {
                _tabPages = value;
                CreateTabPages();
            }
        }

        private void CreateTabPages()
        {
            if (_tabPages.Count == 0) return;

            tabControl.TabPages.Clear();
            int index = 0;
            int left = 10;
            int pixelBetweenLabel = 10;

            List<TabInfo> tabInfos = new List<TabInfo>();

            foreach (WebTabPage page in _tabPages)
            {
                TabHeaderLabel label = new TabHeaderLabel(page.HeaderCaption, index);
                label.Left = left;
                label.Top = (pnlHeader.Height - label.Height) / 2;
                label.IsActive = index == 0;
                label.Click += OnHeaderClick;
                pnlHeader.Controls.Add(label);

                TabPage tabPage = new TabPage();
                tabPage.Controls.Add(page.Control);
                page.Control.Dock = DockStyle.Fill;
                tabControl.TabPages.Add(tabPage);

                tabInfos.Add(new TabInfo { TabHeaderLabel = label, TabClientWidth = Width, TabPage = tabPage });

                index++;
                left = left + label.Width + pixelBetweenLabel;
            }

            _tabInfos = tabInfos.ToArray();

            if (_tabInfos.Length > 0)
            {
                tabControl.SelectedIndex = 0;
                MoveUnderLine(0);
            }
        }

        private void CreatTabHeader()
        {
            if (_headers.Count == 0) return;

            int index = 0;
            int left = 10;
            int pixelBetweenLabel = 10;

            List<TabInfo> tabInfos= new List<TabInfo>();

            foreach (var header in _headers)
            {
                TabHeaderLabel label = new TabHeaderLabel(header, index);
                label.Left = left;
                label.Top = (pnlHeader.Height - label.Height)/2;
                label.IsActive = index == 0;

                label.Click += OnHeaderClick;

                pnlHeader.Controls.Add(label);
                tabInfos.Add(new TabInfo { TabHeaderLabel = label, TabClientWidth = Width });

                index++;
                left = left + label.Width + pixelBetweenLabel;
            }

            _tabInfos = tabInfos.ToArray();

            if (_tabInfos.Length > 0)
            {
                tabControl.SelectedIndex = 0;
                MoveUnderLine(0);
            }
        }

        private void MoveUnderLine(int endIndex)
        {
            if (endIndex >= _tabInfos.Length) return;

            int loops = 10;
            TabHeaderLabel endHeader = _tabInfos[endIndex].TabHeaderLabel;
            int startPosition = lblUnderline.Left;
            int endPosition = endHeader.Left;
            int pixelPerLoopInPosition = (endPosition - startPosition) / loops;
            int pixelPerLoopInWidth = (endHeader.Width - lblUnderline.Width) / loops;

            if (_preTabHeader != null) _preTabHeader.IsActive = false;
            endHeader.IsActive = true;
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
            int index = (int)(sender as Label).Tag;

            MoveUnderLine(index);
            tabControl.SelectedIndex = index;
        }
    }

    class TabInfo
    {
        public TabHeaderLabel TabHeaderLabel { get; set; }

        public int TabClientWidth { get; set; }

        public TabPage TabPage { get; set; }
    }

    public class WebTabPage
    {
        public string HeaderCaption { get; set; }

        public Control Control { get; set; }

    }
}
