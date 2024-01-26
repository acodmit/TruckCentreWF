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
    public partial class ServiceTicketsEmployeeForm : Form
    {
        private List<ServiceTicket> tickets;
        private List<Employee> employees;
        private List<Client> clients;
        private ResourceManager resourceManager;
        public ServiceTicketsEmployeeForm()
        {
            InitializeComponent();

            // Initializing resourceManager
            resourceManager = new ResourceManager("TruckCentreWF.Forms.ServiceTicketsEmployeeForm", typeof(ServiceTicketsEmployeeForm).Assembly);
            
            // Setting properties for each column individually
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.Visible = true;
                column.Resizable = DataGridViewTriState.True;
            }

            // Load service tickets data to the data grid
            LoadData();

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

        // Method to set navy style colors
        private void SetNavyTheme()
        {
            // Form Background Color
            this.BackColor = Color.FromArgb(234, 244, 244);

            // Background Colors
            this.dataGridView1.BackgroundColor = Color.FromArgb(150, 180, 208);

            // Foreground Colors
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.HeaderCell.Style.ForeColor = Color.FromArgb(20, 40, 80);
                column.DefaultCellStyle.ForeColor = Color.FromArgb(20, 40, 80);
            }

            // Buttons
            this.btnAdd.BackColor = Color.FromArgb(52, 86, 109);
            this.btnDelete.BackColor = Color.FromArgb(52, 86, 109);
            this.btnGenerateInvoice.BackColor = Color.FromArgb(52, 86, 109);
            this.btnAdd.ForeColor = Color.FromArgb(200, 200, 200);
            this.btnDelete.ForeColor = Color.FromArgb(200, 200, 200);
            this.btnGenerateInvoice.ForeColor = Color.FromArgb(200, 200, 200);
        }
        private void SetGrayTheme()
        {
            // Form Background Color
            this.BackColor = Color.FromArgb(240, 240, 240); // Light gray

            // Background Colors
            this.dataGridView1.BackgroundColor = Color.FromArgb(220, 220, 220); // Lighter gray

            // Foreground Colors
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.HeaderCell.Style.ForeColor = Color.FromArgb(70, 70, 70); // Dark gray
                column.DefaultCellStyle.ForeColor = Color.FromArgb(70, 70, 70); // Dark gray
            }

            // Buttons
            this.btnAdd.BackColor = Color.FromArgb(180, 180, 180); // Medium gray
            this.btnDelete.BackColor = Color.FromArgb(180, 180, 180); // Medium gray
            this.btnGenerateInvoice.BackColor = Color.FromArgb(180, 180, 180); // Medium gray
            this.btnAdd.ForeColor = Color.FromArgb(40, 40, 40); // Dark gray
            this.btnDelete.ForeColor = Color.FromArgb(40, 40, 40); // Dark gray
            this.btnGenerateInvoice.ForeColor = Color.FromArgb(40, 40, 40); // Dark gray
        }

        private async void LoadData()
        {
            // Initialize DAOs
            ServiceTicketDAO serviceTicketDAO = new ServiceTicketDAO();
            ClientDAO clientDAO = new ClientDAO();

            // Retrieving tickets from database
            tickets = await serviceTicketDAO.GetAll();

            // Retrieve employees from database
            employees = await EmployeeService.GetAllEmployees();

            // Retrieve clients from database
            clients = await clientDAO.GetAll();

            // Display data in the data grid
            DisplayData();
        }

        private void DisplayData()
        {
            // Clear existing rows
            dataGridView1.Rows.Clear();

            // Add data to the table
            foreach (var ticket in tickets)
            {
                Employee employee = employees.Find(emp => emp.IdEmployee == ticket.IdEmployee);
                dataGridView1.Rows.Add(
                    employee.FirstName + " " + employee.LastName,
                    clients.Find(cli => cli.IdClient == ticket.IdClient).Name,
                    ticket.EntryDate,
                    ticket.Details,
                    ticket.Status,
                    ticket.EmployeeIdAccount
                );
            }
        }

        private void btnGenerateInvoice_Click(object sender, EventArgs e)
        {
            // Check if a row is selected in dataGridView1
            if (dataGridView1.SelectedRows.Count > 0)
            {
                try
                {
                    // Assuming the first cell of the selected row contains the IdServiceTicket
                    int selectedTicketIndex = Convert.ToInt32(dataGridView1.SelectedRows[0].Index);

                    // Set selectedTicket reference
                    ServiceTicket selectedTicket = tickets[selectedTicketIndex];

                    // Initialize ServiceTicketDAO
                    ServiceTicketDAO serviceTicketDAO = new ServiceTicketDAO();

                    if (selectedTicket != null)
                    {
                        // Initialize the GenerateInvoiceEmployeeForm with the selected ticket
                        GenerateInvoiceEmployeeForm generateInvoiceForm = new GenerateInvoiceEmployeeForm(selectedTicket);

                        // Show the form
                        generateInvoiceForm.ShowDialog();
                    }
                    else
                    {
                        // Handle the case where the ticket is not found in the database
                        MessageBox.Show(resourceManager.GetString("msgTakingTicket"),
                            resourceManager.GetString("lblError"),
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    // Handle any exceptions that may occur
                    MessageBox.Show($"An error occurred: {ex.Message}",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            else
            {
                // Notify the user that no row is selected
                MessageBox.Show(resourceManager.GetString("msgSelectRow"),
                    resourceManager.GetString("lblError"),
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Initialize the AddServiceTicketEmployeeForm
            AddServiceTicketEmployeeForm addServiceTicketEmployeeForm = new AddServiceTicketEmployeeForm();

            // Show the form
            addServiceTicketEmployeeForm.ShowDialog();
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            // Check if a service ticket is selected
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show(resourceManager.GetString("msgSelectTicket"),
                    resourceManager.GetString("lblError"),
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            // Get selected service ticket
            var selectedTicketIndex = dataGridView1.SelectedRows[0].Index;

            if (selectedTicketIndex != -1)
            {
                // Get reference to ServiceTicket object
                var deletingServiceTicket = tickets[selectedTicketIndex];

                // Use ServiceTicketDAO to delete service ticket
                var serviceTicketDAO = new ServiceTicketDAO();
                var deletedServiceTicket = await serviceTicketDAO.Delete(deletingServiceTicket);

                if (deletedServiceTicket != -1)
                {
                    MessageBox.Show(resourceManager.GetString("msgSucessfullyDeletedServiceTicket"),
                        resourceManager.GetString("lblSuccess"),
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(resourceManager.GetString("msgFailedDeletingServiceTicket"),
                        resourceManager.GetString("lblError"),
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show(resourceManager.GetString("msgErrorGettingServiceTicket"),
                    resourceManager.GetString("lblError"),
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            // Refresh
            LoadData();
        }
    }
}
