using System;
using System.Drawing;
using System.Windows.Forms;

namespace UnifiDesktop.UserControls.V2
{
    internal class TabHeader : Label
    {
        public int Index => (int)Tag;

        public TabHeader(string text, int index)
        {
            //Font = new Font(Font, FontStyle.Bold);
            TextAlign = ContentAlignment.MiddleCenter;
            Text = text.ToUpper();
            Tag = index;
            Cursor= Cursors.Hand;
            SetInactiveColor();
        }

        public void SetActiveColor() => ForeColor = SystemColors.Highlight;
        
        public void SetInactiveColor() => ForeColor = SystemColors.GrayText;

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);

            StringFormat sfFmt = new StringFormat(StringFormatFlags.LineLimit);
            Graphics g = Graphics.FromImage(new Bitmap(1, 1));
            int width = (int)g.MeasureString(Text, Font, 100, sfFmt).Width;

            Width = width + 10;

        }
    }
}
