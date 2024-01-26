using System;
using System.Windows.Forms;
using System.Globalization;
using System.Resources;

using TruckCentreWF.Service;
using TruckCentreWF.Model.Dto;
using System.Collections.Generic;
using System.Drawing;

namespace TruckCentreWF.Forms
{
    public partial class InfoAdminForm : Form
    {
        private ResourceManager resourceManager;

        public InfoAdminForm()
        {
            InitializeComponent();

            // Initialize ResourceManager
            resourceManager = new ResourceManager("TruckCentreWF.Forms.InfoAdminForm", typeof(InfoAdminForm).Assembly);

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

            // Update labels
            InfoAdminForm_Load(this, EventArgs.Empty);
        }

        private async void InfoAdminForm_Load(object sender, EventArgs e)
        {
            // Retrieve data using DAO classes
            int activeTicketsCount = await serviceTicketDAO.GetActiveTicketsCount();
            int finishedTicketsCount = await serviceTicketDAO.GetFinishedTicketsCount();
            List<Employee> allEmployees = await employeeDAO.GetAll();
            List<Vehicle> allVehicles = await vehicleDAO.GetAll();

            int totalEmployeesCount = allEmployees?.Count ?? 0;
            int totalVehiclesCount = allVehicles?.Count ?? 0;

            // Update labels with retrieved data
            labelActiveTickets.Text = string.Format(resourceManager.GetString("labelActiveTickets"), activeTicketsCount);
            labelFinishedTickets.Text = string.Format(resourceManager.GetString("labelFinishedTickets"), finishedTicketsCount);
            labelTotalEmployees.Text = string.Format(resourceManager.GetString("labelTotalEmployees"), totalEmployeesCount);
            labelTotalVehicles.Text = string.Format(resourceManager.GetString("labelTotalVehicles"), totalVehiclesCount);

        }

        private void SetNavyTheme()
        {
            // Set Form background color to light blue
            this.BackColor = Color.FromArgb(234, 244, 244);

            // Set PanelInfo background color
            this.panelInfo.BackColor = Color.FromArgb(150, 180, 208);

            // Set LabelTitle color
            this.labelTitle.ForeColor = Color.FromArgb( 20, 40, 80);

            // Set other Label colors
            this.labelActiveTickets.ForeColor = Color.FromArgb(20, 40, 80);
            this.labelFinishedTickets.ForeColor = Color.FromArgb(20, 40, 80);
            this.labelTotalEmployees.ForeColor = Color.FromArgb(20, 40, 80);
            this.labelTotalVehicles.ForeColor = Color.FromArgb(20, 40, 80);

        }
        private void SetGrayTheme()
        {
            // Set Form background color to light gray
            this.BackColor = Color.FromArgb(240, 240, 240);

            // Set PanelInfo background color
            this.panelInfo.BackColor = Color.FromArgb(220, 220, 220);

            // Set LabelTitle color
            this.labelTitle.ForeColor = Color.FromArgb(70, 70, 70);

            // Set other Label colors
            this.labelActiveTickets.ForeColor = Color.FromArgb(70, 70, 70);
            this.labelFinishedTickets.ForeColor = Color.FromArgb(70, 70, 70);
            this.labelTotalEmployees.ForeColor = Color.FromArgb(70, 70, 70);
            this.labelTotalVehicles.ForeColor = Color.FromArgb(70, 70, 70);
        }

    }
}
