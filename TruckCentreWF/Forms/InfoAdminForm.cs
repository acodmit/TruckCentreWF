using System;
using System.Windows.Forms;
using System.Globalization;
using System.Resources;

using TruckCentreWF.Service;
using TruckCentreWF.Model.Dto;
using System.Collections.Generic;

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
    }
}
