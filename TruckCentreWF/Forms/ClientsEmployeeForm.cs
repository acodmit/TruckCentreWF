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
    public partial class ClientsEmployeeForm : Form
    {
        private List<Client> clients;
        private ResourceManager resourceManager;
        public ClientsEmployeeForm()
        {
            InitializeComponent();

            // Initializing resourceManager
            resourceManager = new ResourceManager("TruckCentreWF.Forms.ClientsEmployeeForm", typeof(ClientsEmployeeForm).Assembly);

            // Load data to clients grids
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

            // Foreground Colors
            foreach (DataGridViewColumn column in dataGridViewClients.Columns)
            {
                column.HeaderCell.Style.ForeColor = Color.FromArgb(20, 40, 80);
                column.DefaultCellStyle.ForeColor = Color.FromArgb(20, 40, 80);
            }

            // Buttons
            this.btnAdd.BackColor = Color.FromArgb(52, 86, 109);
            this.btnDelete.BackColor = Color.FromArgb(52, 86, 109);
            this.btnAdd.ForeColor = Color.FromArgb(200, 200, 200);
            this.btnDelete.ForeColor = Color.FromArgb(200, 200, 200);
        }
        public async void LoadData()
        {
            ClientDAO clientDAO = new ClientDAO();
            clients = await clientDAO.GetAll();

            DisplayData();
        }

        private void DisplayData()
        {
            // Clear existing rows
            dataGridViewClients.Rows.Clear();

            // Add data to the table
            foreach (var client in clients)
            {
                dataGridViewClients.Rows.Add(
                    client.Name,
                    client.Email,
                    client.Address
                );
            }
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Generate AddClientEmployeeForm
            AddClientEmployeeForm addClientEmployeeForm = new AddClientEmployeeForm(this);

            // Show form
            addClientEmployeeForm.Show();

        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            // Check if a row is selected
            if (dataGridViewClients.SelectedRows.Count == 1)
            {
                // Get the selected client
                var selectedClient = clients[dataGridViewClients.SelectedRows[0].Index];

                // Ask for confirmation before deletion
                var result = MessageBox.Show(
                    string.Format(resourceManager.GetString("msgDeleteQuestion")),
                    resourceManager.GetString("lblDeleteConfirmation"),
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        ClientDAO clientDAO = new ClientDAO();

                        // Delete the selected service
                        int deleted = await clientDAO.Delete(selectedClient);

                        if (deleted != -1)
                        {
                            MessageBox.Show(
                                resourceManager.GetString("msgSuccessfullyDeleted"),
                                resourceManager.GetString("lblSuccess"),
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                            LoadData();
                        }
                        else
                        {
                            MessageBox.Show(
                                resourceManager.GetString("msgFailedDeleting"),
                                resourceManager.GetString("lblError"),
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"An error occurred: {ex.Message}",
                            resourceManager.GetString("lblError"),
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show(
                    resourceManager.GetString("msgSelectRow"),
                    resourceManager.GetString("lblWarning"),
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

    }
}
