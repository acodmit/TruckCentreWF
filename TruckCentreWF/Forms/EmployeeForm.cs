using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using TruckCentreWF.Forms.Common;
using TruckCentreWF.Service;

namespace TruckCentreWF.Forms
{
    public partial class EmployeeForm : DraggableForm
    {
        private ResourceManager resourceManager;

        public EmployeeForm()
        {   
            InitializeComponent();
            SetPanelOpacity(pnlLogo, 0.3f);

            // Initializing ResourceManager
            resourceManager = new ResourceManager("TruckCentreWF.Forms.EmployeeForm", typeof(EmployeeForm).Assembly);

            // Set the theme based on the Employee's theme value
            if (ApplicationService.CurrEmployee.Theme == 1)
            {
                SetNavyTheme();
            }
            else
            {
                // Leave default green theme
            }

            // Load Home Form class
            HomeEmployeeForm childForm = new HomeEmployeeForm();

            // Load the child form into the panel
            LoadChildFormIntoPanel(childForm);
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


        // Method to load a child form into a panel
        private void LoadChildFormIntoPanel(Form childForm)
        {
            // Ensure the child form is not null
            if (childForm != null)
            {
                // Set the TopLevel property to false to make it a non-top-level control
                childForm.TopLevel = false;

                // Set the FormBorderStyle property to None to remove the border
                childForm.FormBorderStyle = FormBorderStyle.None;

                // Set the Dock property to Fill to make it fill the entire panel
                childForm.Dock = DockStyle.Fill;

                // Attach a method to handle the child form's FormClosed event
                childForm.FormClosed += ChildForm_FormClosed;

                // Add the child form to the panel's controls
                pnlMain.Controls.Add(childForm);

                // Show the child form
                childForm.Show();
            }
        }

        // Event handler for child form closed
        private void ChildForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Remove the child form from the panel when closed
            if (sender is Form childForm)
            {
                childForm.FormClosed -= ChildForm_FormClosed;
                pnlMenu.Controls.Remove(childForm);
            }
        }
        private void SetNavyTheme()
        {
            // Background Colors
            this.pnlLogo.BackColor = Color.FromArgb(52, 86, 109);
            this.pnlMenu.BackColor = Color.FromArgb(52, 86, 109);
            this.pnlToolbar.BackColor = Color.FromArgb(150, 180, 208);
            this.pnlMain.BackColor = Color.FromArgb(150, 180, 208);
            this.lblTitle.BackColor = Color.FromArgb(150, 180, 208);
            this.btnHome.BackColor = Color.FromArgb(52, 86, 109);
            this.btnLogOut.BackColor = Color.FromArgb(52, 86, 109);
            this.btnPartsServices.BackColor = Color.FromArgb(52, 86, 109);
            this.btnTickets.BackColor = Color.FromArgb(52, 86, 109);

            // Foreground Colors
            this.lblTitle.ForeColor = Color.FromArgb(20, 40, 80);
            this.lblMinimise.ForeColor = Color.FromArgb(20, 40, 80);
            this.lblExit.ForeColor = Color.FromArgb(20, 40, 80);
            this.btnHome.ForeColor = Color.FromArgb(200, 200, 200);
            this.btnTickets.ForeColor = Color.FromArgb(200, 200, 200);
            this.btnPartsServices.ForeColor = Color.FromArgb(200, 200, 200);
            this.btnLogOut.ForeColor = Color.FromArgb(200, 200, 200);
        }

        private void lblExit_Click(object sender, EventArgs e)
        {
            // Exit the entire program, uncomment the following line
            Application.Exit();
        }

        private void lblMinimise_Click(object sender, EventArgs e)
        {
            // Minimize the window
            this.WindowState = FormWindowState.Minimized;
        }

        // Menu buttons

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            // Close the current form
            this.Close();

            // Set currentEmployee to null
            ApplicationService.CurrEmployee = null;

            // Open a new instance of the login form
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            // Set title label to "Home"
            lblTitle.Text = resourceManager.GetString("lblHome", Thread.CurrentThread.CurrentUICulture);

            // Close the currently loaded form in pnlMain
            pnlMain.Controls.Clear();

            // Generate HomeEmployeeForm
            HomeEmployeeForm childForm = new HomeEmployeeForm();

            // Load the child form into the panel
            LoadChildFormIntoPanel(childForm);
        }

        private void btnTickets_Click(object sender, EventArgs e)
        {
            // Set title label to "Service Tickets"
            lblTitle.Text = resourceManager.GetString("lblServiceTickets", Thread.CurrentThread.CurrentUICulture);

            // Close the currently loaded form in pnlMain
            pnlMain.Controls.Clear();

            // Generate ServiceTicketsEmployeeForm
            ServiceTicketsEmployeeForm childForm = new ServiceTicketsEmployeeForm();

            // Load the child form into the panel
            LoadChildFormIntoPanel(childForm);
        }
    }
}
