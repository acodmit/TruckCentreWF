using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TruckCentreWF.Forms.Common
{
    public class TransparentPanel : Panel
    {
        private float opacity = 0.6f;

        public TransparentPanel()
        {
            // Set the style to allow transparency
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.Green;
        }

        public float Opacity
        {
            get { return opacity; }
            set
            {
                if (value >= 0.0f && value <= 1.0f)
                {
                    opacity = value;
                    Invalidate();
                }
                else
                {
                    throw new ArgumentException("Opacity must be between 0.0 and 1.0");
                }
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            using (var brush = new SolidBrush(Color.FromArgb((int)(255 * opacity), BackColor)))
            {
                e.Graphics.FillRectangle(brush, ClientRectangle);
            }
        }
    }
}
