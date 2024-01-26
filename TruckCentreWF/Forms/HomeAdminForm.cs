using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TruckCentreWF.Service;

namespace TruckCentreWF.Forms
{
    public partial class HomeAdminForm : Form
    {
        public HomeAdminForm()
        {
            InitializeComponent();

            // Set the theme based on the Employee's theme value
            if (ApplicationService.CurrEmployee.Theme == 1)
            {
                SetNavyTheme();
            }
            else if (ApplicationService.CurrEmployee.Theme == 2)
            {
                SetGrayTheme();
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

        private void SetGrayTheme()
        {
            // Background Colors
            this.BackColor = Color.FromArgb(240, 240, 240); // Light gray
            this.pnlMainHome.BackColor = Color.FromArgb(220, 220, 220); // Lighter gray

            // Foreground Colors
            this.lblTitleHome.ForeColor = Color.FromArgb(70, 70, 70); // Dark gray
            this.lblContentHome.ForeColor = Color.FromArgb(70, 70, 70); // Dark gray
        }


    }
}

