using System;
using System.Drawing;
using System.Windows.Forms;

namespace UnifiDesktop.UserControls.V2
{
    internal class TabHeaderLabel : Label
    {
        public int Index => (int)Tag;

        public TabHeaderLabel(string text, int index)
        {
            Font = new Font(Font.FontFamily, 9f);
            TextAlign = ContentAlignment.MiddleCenter;
            Text = text.ToUpper();
            Tag = index;
            Cursor= Cursors.Hand;
            SetInactiveColor();
        }

        public void SetActiveColor() => ForeColor = SystemColors.Highlight;
        
        public void SetInactiveColor() => ForeColor = Color.Black;

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
