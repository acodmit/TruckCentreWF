using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TruckCentreWF.Forms
{
    public partial class HomeEmployeeForm : Form
    {
        public HomeEmployeeForm()
        {
            InitializeComponent();

            // Setting panel opacity
            SetPanelOpacity(pnlMainHome, 0.6F);
        }

        private void SetPanelOpacity(Panel panel, float opacity)
        {
            // Check if the Panel has a background image
            if (panel.BackgroundImage != null)
            {
                // Set the opacity of the Panel's background color
                panel.BackColor = Color.FromArgb((int)(255 * opacity), panel.BackColor);
            }
        }
    }
}
