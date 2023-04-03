using System;
using System.Drawing;
using System.Windows.Forms;

namespace UnifiDesktop.UserControls.ListBox
{
    internal class ListBoxV2 : System.Windows.Forms.ListBox
    {
        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            if (Items.Count <= 0 || e.Index < 0) return;
            base.OnDrawItem(e);

            // If the item state is selected them change the back color 
            bool selected = (e.State & DrawItemState.Selected) == DrawItemState.Selected;
            if (selected)
                e = new DrawItemEventArgs(e.Graphics,
                                          e.Font,
                                          e.Bounds,
                                          e.Index,
                                          e.State ^ DrawItemState.Selected,
                                          e.ForeColor,
                                          Color.FromArgb(80, 169, 45));//Choose the color

            // Draw the background of the ListBox control for each item.
            e.DrawBackground();

            // Draw the current item text
            Brush brush = selected ? Brushes.White : Brushes.Black;

            // Draw the text 2 pixel down to make the text show vertically centered. 
            Rectangle bounds = new Rectangle(e.Bounds.X, e.Bounds.Y + 2, e.Bounds.Width, e.Bounds.Height);
            e.Graphics.DrawString(Items[e.Index].ToString(), e.Font, brush, bounds, StringFormat.GenericDefault);

            // If the ListBox has focus, draw a focus rectangle around the selected item.
            e.DrawFocusRectangle();
        }

        protected override void OnMeasureItem(MeasureItemEventArgs e)
        {
            if (Items.Count <= 0 || e.Index < 0) return;
            base.OnMeasureItem(e);

            StringFormat sfFmt = new StringFormat(StringFormatFlags.LineLimit);
            Graphics g = Graphics.FromImage(new Bitmap(1, 1));

            string text = Items[e.Index].ToString();
            int maxWidth = Width;

            int totalHeight = (int)g.MeasureString(text, Font, maxWidth, sfFmt).Height;
            int oneLineHeight = (int)g.MeasureString("Z", Font, maxWidth, sfFmt).Height;
            int additionalLineCount = totalHeight == oneLineHeight ? 0 : (int)Math.Floor((decimal)totalHeight / oneLineHeight);

            if (additionalLineCount > 0)
                e.ItemHeight = ItemHeight + additionalLineCount * oneLineHeight;
        }
    }
}
