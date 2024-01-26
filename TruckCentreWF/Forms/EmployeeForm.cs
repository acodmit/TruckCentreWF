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
            else if (ApplicationService.CurrEmployee.Theme == 2)
            {
                SetGrayTheme();
            }
            else
            {
                // Leave default green theme
            }

            ApplicationService.themeIndex = ApplicationService.CurrEmployee.Theme;

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
            this.btnTickets.BackColor = Color.FromArgb(52, 86, 109);
            this.btnParts.BackColor = Color.FromArgb(52, 86, 109);
            this.btnServices.BackColor = Color.FromArgb(52, 86, 109);
            this.btnClients.BackColor = Color.FromArgb(52, 86, 109);
            this.btnVehicles.BackColor = Color.FromArgb(52, 86, 109);
            this.btnSettings.BackColor = Color.FromArgb(52, 86, 109);
            this.btnLogOut.BackColor = Color.FromArgb(52, 86, 109);

            // Foreground Colors
            this.lblTitle.ForeColor = Color.FromArgb(20, 40, 80);
            this.lblMinimise.ForeColor = Color.FromArgb(20, 40, 80);
            this.lblExit.ForeColor = Color.FromArgb(20, 40, 80);
            this.btnHome.ForeColor = Color.FromArgb(200, 200, 200);
            this.btnTickets.ForeColor = Color.FromArgb(200, 200, 200);
            this.btnParts.ForeColor = Color.FromArgb(200, 200, 200);
            this.btnServices.ForeColor = Color.FromArgb(200, 200, 200);
            this.btnServices.ForeColor = Color.FromArgb(200, 200, 200);
            this.btnClients.ForeColor = Color.FromArgb(200, 200, 200);
            this.btnVehicles.ForeColor = Color.FromArgb(200, 200, 200);
            this.btnSettings.ForeColor = Color.FromArgb(200, 200, 200);
            this.btnLogOut.ForeColor = Color.FromArgb(200, 200, 200);
        }

        private void SetGrayTheme()
        {
            // Background Colors
            this.pnlLogo.BackColor = Color.FromArgb(220, 220, 220); // Light gray
            this.pnlMenu.BackColor = Color.FromArgb(220, 220, 220); // Light gray
            this.pnlToolbar.BackColor = Color.FromArgb(220, 220, 220); // Lighter gray
            this.pnlMain.BackColor = Color.FromArgb(220, 220, 220); // Lighter gray
            this.lblTitle.BackColor = Color.FromArgb(220, 220, 220); // Lighter gray
            this.btnHome.BackColor = Color.FromArgb(220, 220, 220); // Light gray
            this.btnTickets.BackColor = Color.FromArgb(220, 220, 220); // Light gray
            this.btnParts.BackColor = Color.FromArgb(220, 220, 220); // Light gray
            this.btnServices.BackColor = Color.FromArgb(220, 220, 220); // Light gray
            this.btnClients.BackColor = Color.FromArgb(220, 220, 220); // Light gray
            this.btnVehicles.BackColor = Color.FromArgb(220, 220, 220); // Light gray
            this.btnSettings.BackColor = Color.FromArgb(220, 220, 220); // Light gray
            this.btnLogOut.BackColor = Color.FromArgb(220, 220, 220); // Light gray

            // Foreground Colors
            this.lblTitle.ForeColor = Color.FromArgb(70, 70, 70); // Dark gray
            this.lblMinimise.ForeColor = Color.FromArgb(70, 70, 70); // Dark gray
            this.lblExit.ForeColor = Color.FromArgb(70, 70, 70); // Dark gray
            this.btnHome.ForeColor = Color.FromArgb(40, 40, 40); // Dark gray
            this.btnTickets.ForeColor = Color.FromArgb(40, 40, 40); // Dark gray
            this.btnParts.ForeColor = Color.FromArgb(40, 40, 40); // Dark gray
            this.btnServices.ForeColor = Color.FromArgb(40, 40, 40); // Dark gray
            this.btnClients.ForeColor = Color.FromArgb(40, 40, 40); // Dark gray
            this.btnVehicles.ForeColor = Color.FromArgb(40, 40, 40); // Dark gray
            this.btnSettings.ForeColor = Color.FromArgb(40, 40, 40); // Dark gray
            this.btnLogOut.ForeColor = Color.FromArgb(40, 40, 40); // Dark gray
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
            lblTitle.Text = resourceManager.GetString("lblHome");

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
            lblTitle.Text = resourceManager.GetString("lblServiceTickets");

            // Close the currently loaded form in pnlMain
            pnlMain.Controls.Clear();

            // Generate ServiceTicketsEmployeeForm
            ServiceTicketsEmployeeForm childForm = new ServiceTicketsEmployeeForm();

            // Load the child form into the panel
            LoadChildFormIntoPanel(childForm);
        }

        private void btnParts_Click(object sender, EventArgs e)
        {
            // Set title label to "Parts"
            lblTitle.Text = resourceManager.GetString("lblParts");

            // Close the currently loaded form in pnlMain
            pnlMain.Controls.Clear();

            // Generate PartsEmployeeForm
            PartsEmployeeForm childForm = new PartsEmployeeForm();

            // Load the child form into the panel
            LoadChildFormIntoPanel(childForm);
        }

        private void btnServices_Click(object sender, EventArgs e)
        {
            // Set title label to "Services"
            lblTitle.Text = resourceManager.GetString("lblServices");

            // Close the currently loaded form in pnlMain
            pnlMain.Controls.Clear();

            // Generate ServicesEmployeeForm
            ServicesEmployeeForm childForm = new ServicesEmployeeForm();

            // Load the child form into the panel
            LoadChildFormIntoPanel(childForm);
        }

        private void btnClients_Click(object sender, EventArgs e)
        {
            // Set title label to "Clients"
            lblTitle.Text = resourceManager.GetString("lblClients");

            // Close the currently loaded form in pnlMain
            pnlMain.Controls.Clear();

            // Generate ClientsEmployeeForm
            ClientsEmployeeForm childForm = new ClientsEmployeeForm();

            // Load the child form into the panel
            LoadChildFormIntoPanel(childForm);
        }

        private void btnVehicles_Click(object sender, EventArgs e)
        {
            // Set title label to "Vehicles"
            lblTitle.Text = resourceManager.GetString("lblVehicles");

            // Close the currently loaded form in pnlMain
            pnlMain.Controls.Clear();

            // Generate VehiclesEmployeeForm
            VehiclesEmployeeForm childForm = new VehiclesEmployeeForm();

            // Load the child form into the panel
            LoadChildFormIntoPanel(childForm);
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            // Set title label to "Settings"
            lblTitle.Text = resourceManager.GetString("lblSettings");

            // Close the currently loaded form in pnlMain
            pnlMain.Controls.Clear();

            // Generate SettingsEmployeeForm
            SettingsEmployeeForm childForm = new SettingsEmployeeForm();

            // Load the child form into the panel
            LoadChildFormIntoPanel(childForm);
        }
    }
}
