using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TruckCentreWF.Model.Dao;
using TruckCentreWF.Model.Dto;
using TruckCentreWF.Service;

namespace TruckCentreWF.Forms
{
    public partial class AddServiceTicketEmployeeForm : DraggableForm
    {
        private List<Model.Dto.Client> clients;
        private List<Vehicle> vehicles;

        public AddServiceTicketEmployeeForm()
        {
            InitializeComponent();
            // Load data to part and service grids
            LoadData();
        }

        private async void LoadData()
        {
            ClientDAO clientDAO = new ClientDAO();
            VehicleDAO vehicleDAO = new VehicleDAO();

            clients = await clientDAO.GetAll();
            vehicles = await vehicleDAO.GetAll();

            DisplayData();
        }

        private void DisplayData()
        {
            // Clear existing rows
            dataGridViewClients.Rows.Clear();
            dataGridViewVehicles.Rows.Clear();

            // Add data to the tables
            foreach (var client in clients)
            {
                dataGridViewClients.Rows.Add(
                    client.IdClient,
                    client.Email,
                    client.Address
                );
            }

            foreach (var vehicle in vehicles)
            {
                dataGridViewVehicles.Rows.Add(
                    vehicle.IdVehicle,
                    vehicle.Mileage,
                    vehicle.Details,
                    vehicle.LastService
                );
            }
        }

        private void lblExit_Click(object sender, EventArgs e)
        {
            // Close the current form
            this.Close();
        }

        private void lblMinimise_Click(object sender, EventArgs e)
        {
            // Minimize the window
            this.WindowState = FormWindowState.Minimized;
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            // Check if a client and vehicle are selected
            if (dataGridViewClients.SelectedRows.Count == 0 || dataGridViewVehicles.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a client and a vehicle.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Check if the text box is filled
            if (string.IsNullOrWhiteSpace(textBoxDetails.Text))
            {
                MessageBox.Show("Please enter service details.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Get selected client and vehicle Ids
            var selectedClientIdStr = dataGridViewClients.SelectedRows[0].Cells[0].Value?.ToString();
            var selectedVehicleId = dataGridViewVehicles.SelectedRows[0].Cells[0].Value?.ToString();  // Use string for IdVehicle

            if (!int.TryParse(selectedClientIdStr, out var selectedClientId))
            {
                MessageBox.Show("Error parsing client ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Create a new ServiceTicket object
            var newServiceTicket = new ServiceTicket
            {
                IdEmployee = ApplicationService.CurrEmployee.IdEmployee,
                IdClient = selectedClientId,
                EntryDate = DateTime.Now,
                Details = textBoxDetails.Text,
                Status = "Active",
            };

            // Use ServiceTicketDAO to add the new service ticket
            var serviceTicketDAO = new ServiceTicketDAO();
            var addedServiceTicketId = await serviceTicketDAO.Insert(newServiceTicket);

            if (addedServiceTicketId != -1)
            {
                // Create a new ServiceTicketVehicle object
                var newServiceTicketVehicle = new ServiceTicketVehicle
                {
                    IdServiceTicket = addedServiceTicketId,
                    IdVehicle = selectedVehicleId,  // Use string for IdVehicle
                };

                // Use ServiceTicketVehicleDAO to add the new service ticket vehicle
                var serviceTicketVehicleDAO = new ServiceTicketVehicleDAO();
                var addedServiceTicketVehicle = await serviceTicketVehicleDAO.Insert(newServiceTicketVehicle);

                if (addedServiceTicketVehicle != -1)
                {
                    MessageBox.Show("Service ticket and associated vehicle added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Optionally, you can refresh the data grids or take any other actions
                }
                else
                {
                    MessageBox.Show("Error adding service ticket vehicle.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Error adding service ticket.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
