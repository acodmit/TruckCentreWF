using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TruckCentreWF.Service;

namespace TruckCentreWF.Forms
{
    public partial class HomeEmployeeForm : Form
    {
        public HomeEmployeeForm()
        {
            InitializeComponent();

            // Setting panel opacity
            SetPanelOpacity(pnlMainHome, 0.6F);

            // Set the theme based on the Employee's theme value
            if (ApplicationService.CurrEmployee.Theme == 1)
            {
                SetNavyTheme();
            }
            else
            {
                // Leave default green theme
            }
        }
        private void SetNavyTheme()
        {
            // Background Colors
            this.BackColor = Color.FromArgb(234, 244, 244);
            this.pnlMainHome.BackColor = Color.FromArgb(150, 180, 208);

            // Foreground Colors
            this.lblTitleHome.ForeColor = Color.FromArgb(20, 40, 80);
            this.lblContentHome.ForeColor = Color.FromArgb(20, 40, 80);
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
