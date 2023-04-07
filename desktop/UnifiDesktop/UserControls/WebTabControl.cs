using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using UnifiDesktop.UserControls.V2;
using static System.Windows.Forms.TabControl;

namespace UnifiDesktop.UserControls
{
    /// <summary>
    /// A tab control that uses web style tab header labels.
    /// </summary>
    [Designer(typeof(WebTabControlDesigner))]
    public partial class WebTabControl : UserControl
    {
        private List<string> _headers = new List<string>() { };
        private TabInfo[] _tabInfos = new TabInfo[] { };
        private TabHeaderLabel _preTabHeader = null;

        private TabPageCollection _tabPages;

        public WebTabControl()
        {
            InitializeComponent();
        }

        private void WebTabControl_Load(object sender, EventArgs e)
        {
            CreatTabHeaderLabels();
            HideTabControlHeader();
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public TabControl TabControl
        {
            get => tabControl;
            set => tabControl= value;
        }

        //private void CreateTabPages()
        //{
        //    if (_tabPages.Count == 0) return;

        //    tabControl.TabPages.Clear();
        //    int index = 0;
        //    int left = 10;
        //    int pixelBetweenLabel = 10;

        //    List<TabInfo> tabInfos = new List<TabInfo>();

        //    foreach (WebTabPage page in _tabPages)
        //    {
        //        TabHeaderLabel label = new TabHeaderLabel(page.HeaderCaption, index);
        //        label.Left = left;
        //        label.Top = (pnlHeader.Height - label.Height) / 2;
        //        label.IsActive = index == 0;
        //        label.Click += OnHeaderClick;
        //        pnlHeader.Controls.Add(label);

        //        TabPage tabPage = new TabPage();
        //        tabPage.Controls.Add(page.Control);
        //        page.Control.Dock = DockStyle.Fill;
        //        tabControl.TabPages.Add(tabPage);

        //        tabInfos.Add(new TabInfo { TabHeaderLabel = label, TabClientWidth = Width, TabPage = tabPage });

        //        index++;
        //        left = left + label.Width + pixelBetweenLabel;
        //    }

        //    _tabInfos = tabInfos.ToArray();

        //    if (_tabInfos.Length > 0)
        //    {
        //        tabControl.SelectedIndex = 0;
        //        MoveUnderLine(0);
        //    }
        //}

        private void ClearTabHeaderLabels()
        {
            foreach(Control ctl in pnlHeader.Controls)
            {
                if (ctl is TabHeaderLabel lbl) pnlHeader.Controls.Remove(lbl);
            }
        }

        /// <summary>
        /// Hides the header of TabControl. 
        /// </summary>
        private void HideTabControlHeader()
        {
            tabControl.Appearance = TabAppearance.FlatButtons;
            tabControl.ItemSize = new Size(0, 1);
            tabControl.SizeMode = TabSizeMode.Fixed;
        }

        private void CreatTabHeaderLabels()
        {
            ClearTabHeaderLabels();
            if (tabControl.TabPages.Count == 0) return;

            int index = 0;
            int left = 10;
            int pixelBetweenLabel = 10;

            List<TabInfo> tabInfos= new List<TabInfo>();

            foreach (TabPage tabPage in tabControl.TabPages)
            {
                TabHeaderLabel label = new TabHeaderLabel(tabPage.Text, index);
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

        private void tabControl_ControlAdded(object sender, ControlEventArgs e)
        {
            if (sender != null && e.Control is TabPage t)
            {
                //MessageBox.Show(sender.GetType().ToString());
            }
        }
    }

    class TabInfo
    {
        public TabHeaderLabel TabHeaderLabel { get; set; }

        public int TabClientWidth { get; set; }

        public TabPage TabPage { get; set; }
    }

    //public class WebTabPage
    //{
    //    public string HeaderCaption { get; set; }

    //    public Control Control { get; set; }

    //}

    class WebTabControlDesigner : ParentControlDesigner
    {

        public override void Initialize(IComponent component)
        {
            base.Initialize(component);

            WebTabControl tab = component as WebTabControl;
            //EnableDesignMode(tab.tabControl.TabPages[0], "tabPage1");
            //EnableDesignMode(tab.tabControl.TabPages[1], "tabPage2");
            EnableDesignMode(tab.tabControl, "TabControl");
        }

    }
}
