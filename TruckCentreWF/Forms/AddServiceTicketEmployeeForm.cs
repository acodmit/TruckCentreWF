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
using TruckCentreWF.Model.Dao;
using TruckCentreWF.Model.Dto;
using TruckCentreWF.Service;

namespace TruckCentreWF.Forms
{
    public partial class AddServiceTicketEmployeeForm : DraggableForm
    {
        private List<Model.Dto.Client> clients;
        private List<Vehicle> vehicles;
        private ResourceManager resourceManager;

        public AddServiceTicketEmployeeForm()
        {
            InitializeComponent();

            // Initializing resourceManager
            resourceManager = new ResourceManager("TruckCentreWF.Forms.AddServiceTicketEmployeeForm", typeof(AddServiceTicketEmployeeForm).Assembly);

            // Load data to part and service grids
            LoadData();
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

        // Method to set navy style colors
        private void SetNavyTheme()
        {
            // Form Background Color
            this.BackColor = Color.FromArgb(234, 244, 244);

            // Background Colors
            this.dataGridViewClients.BackgroundColor = Color.FromArgb(150, 180, 208);
            this.dataGridViewVehicles.BackgroundColor = Color.FromArgb(150, 180, 208);

            // Foreground Colors
            foreach (DataGridViewColumn column in dataGridViewClients.Columns)
            {
                column.HeaderCell.Style.ForeColor = Color.FromArgb(20, 40, 80);
                column.DefaultCellStyle.ForeColor = Color.FromArgb(20, 40, 80);
            }
            foreach (DataGridViewColumn column in dataGridViewVehicles.Columns)
            {
                column.HeaderCell.Style.ForeColor = Color.FromArgb(20, 40, 80);
                column.DefaultCellStyle.ForeColor = Color.FromArgb(20, 40, 80);
            }

            // Buttons
            this.btnAdd.BackColor = Color.FromArgb(52, 86, 109);
            this.btnAdd.ForeColor = Color.FromArgb(200, 200, 200);
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
                    client.Name,
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
                MessageBox.Show(resourceManager.GetString("msgSelect"),
                    resourceManager.GetString("lblError"),
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            // Check if the text box is filled
            if (string.IsNullOrWhiteSpace(textBoxDetails.Text))
            {
                MessageBox.Show(resourceManager.GetString("msgEnterDetails"),
                    resourceManager.GetString("lblError"),
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            // Get selected client and vehicle Ids
            var selectedClientIndex = dataGridViewClients.SelectedRows[0].Index;
            var selectedVehicleId = dataGridViewVehicles.SelectedRows[0].Cells[0].Value?.ToString();  // Use string for IdVehicle

            if (selectedClientIndex == -1)
            {
                MessageBox.Show(resourceManager.GetString("msgErrorClientId"),
                    resourceManager.GetString("lblError"),
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            // Create a new ServiceTicket object
            var newServiceTicket = new ServiceTicket
            {
                IdEmployee = ApplicationService.CurrEmployee.IdEmployee,
                IdClient = clients[selectedClientIndex].IdClient,
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
                    MessageBox.Show(resourceManager.GetString("msgSuccesfullyAdded"),
                        resourceManager.GetString("lblSuccess"),
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                }
                else
                {
                    MessageBox.Show(resourceManager.GetString("msgFailedAdding"),
                        resourceManager.GetString("lblError"),
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show(resourceManager.GetString("msgFailedAdding"),
                    resourceManager.GetString("lblError"),
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}
