using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UnifiDesktop.DrawingUtils
{
    internal class DrawingHelper
    {
        private const int CornerRadius = 8;

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
           int nLeftRect,     // x-coordinate of upper-left corner
           int nTopRect,      // y-coordinate of upper-left corner
           int nRightRect,    // x-coordinate of lower-right corner
           int nBottomRect,   // y-coordinate of lower-right corner
           int nWidthEllipse, // width of ellipse
           int nHeightEllipse // height of ellipse
        );

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, Int32 wMsg, bool wParam, Int32 lParam);

        private const int WM_SETREDRAW = 11;

        public static void SuspendDrawing(Control parent)
        {
            SendMessage(parent.Handle, WM_SETREDRAW, false, 0);
        }

        public static void ResumeDrawing(Control parent)
        {
            SendMessage(parent.Handle, WM_SETREDRAW, true, 0);
            parent.Refresh();
        }

        public static void DrawRoundBorder(Control control, Graphics g, int cornerRadius = CornerRadius)
        {
            control.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, control.Width, control.Height, cornerRadius *  2, cornerRadius * 2));

            GraphicsPath path = RoundedRectangle.Create(0, 0, control.Width - 2, control.Height - 2, cornerRadius);
            path.Widen(new Pen(Color.Gray, 2));

            //e.Graphics.DrawPath(Pens.Gray, path);
            // Smooth the corners
            g.SmoothingMode = SmoothingMode.HighQuality;

            g.FillPath(new SolidBrush(Color.Gray), path);
        }

        public static void RoundControl(Control control, int cornerRadius)
        {
            control.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, control.Width, control.Height, cornerRadius * 2, cornerRadius * 2));
        }

        public static SizeF CalculateStringDimension(Graphics g, string text, Font font, int maxWidth = 1000, StringFormat stringFormat = null)
        {
            return g.MeasureString(text, font, maxWidth, stringFormat);
        }
    }
}
