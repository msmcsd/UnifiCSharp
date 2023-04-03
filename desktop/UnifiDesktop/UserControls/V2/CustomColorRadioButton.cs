using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace UnifiDesktop.UserControls.V2
{
    internal class CustomColorRadioButton : RadioButton
    {
        private Color _checkedColor = Color.Black;
        private Color _unCheckedColor = Color.Black;

        private const float _outerCircleSize = 15f;
        private const float _innerCircleSize = 9;

        public Color CheckedColor
        { 
            get => _checkedColor;
            set
            {
                _checkedColor = value;
                Invalidate();
            }
        }    

        public Color UncCheckedColor
        { 
            get => _unCheckedColor;
            set
            {
                _unCheckedColor = value;
                Invalidate();
            }
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            Graphics g = pevent.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            RectangleF rectRbBorder = new RectangleF
            {
                X = 0.5f,
                Y = (Height - _outerCircleSize) / 2,
                Width = _outerCircleSize,
                Height = _outerCircleSize
            };

            RectangleF rectRbCheck = new RectangleF
            {
                X = rectRbBorder.X + ((rectRbBorder.Width - _innerCircleSize)/2),
                Y = (Height - _innerCircleSize) / 2,
                Width = _innerCircleSize,
                Height = _innerCircleSize
            };

            int textHeight = (int)g.MeasureString(Text, Font).Height;
            int textStartX = (int)_outerCircleSize + 3;
            // When the average is not a whole number, ceiling is applied so the start Y position of the text
            // is pushed down one pixel so it shows towards the bottom of the client area.
            int textStartY = (int)Math.Ceiling((float)(Height - textHeight) / 2); 

            using (Pen penBorder = new Pen(_checkedColor, 1f))
            using (SolidBrush burhsCheck = new SolidBrush(_checkedColor)) 
            using (SolidBrush brushText = new SolidBrush(_checkedColor)) 
            {
                g.Clear(BackColor);
                
                // Draw the current item text
                Brush brush = Brushes.Black;
                Rectangle bounds = new Rectangle(textStartX, textStartY, pevent.ClipRectangle.Width - textStartX, pevent.ClipRectangle.Height);
                g.DrawString(Text, Font, brush, bounds, StringFormat.GenericDefault);

                if (Checked)
                {
                    g.DrawEllipse(penBorder, rectRbBorder);
                    g.FillEllipse(brushText, rectRbCheck);
                }
                else
                {
                    penBorder.Color = _unCheckedColor;
                    g.DrawEllipse(penBorder, rectRbBorder);
                }
            }

        }

        protected override void OnMouseHover(EventArgs e)
        {
            Graphics g = CreateGraphics();
            int textHeight = (int)g.MeasureString(Text, Font).Height;
            //int textStartX = (int)_outerCircleSize + 3;
            // When the average is not a whole number, ceiling is applied so the start Y position of the text
            // is pushed down one pixel so it shows towards the bottom of the client area.
            int textStartY = (int)Math.Ceiling((float)(Height - textHeight) / 2);
            Brush brush = Brushes.Green;
            Rectangle bounds = new Rectangle(0, 0, Width, Height);//new Rectangle(textStartX, textStartY, pevent.ClipRectangle.Width - textStartX, pevent.ClipRectangle.Height);
            g.DrawString(Text, Font, brush, bounds, StringFormat.GenericDefault);
        }
    }
}
