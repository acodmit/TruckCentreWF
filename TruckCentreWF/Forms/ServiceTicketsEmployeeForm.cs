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
    public partial class ServiceTicketsEmployeeForm : Form
    {
        private List<ServiceTicket> tickets;

        public ServiceTicketsEmployeeForm()
        {
            InitializeComponent();

            // Setting properties for each column individually
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.Visible = true;
                column.Resizable = DataGridViewTriState.True;
            }

            // Load service tickets data to the data grid
            LoadData();
        }

        private async void LoadData()
        {
            // Initialize ServiceTicketDAO
            ServiceTicketDAO serviceTicketDAO = new ServiceTicketDAO();

            // Retrieving tickets from database
            tickets = await serviceTicketDAO.GetAll();

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
                dataGridView1.Rows.Add(
                    ticket.IdServiceTicket,
                    ticket.IdEmployee,
                    ticket.EntryDate,
                    ticket.Details,
                    ticket.Status,
                    ticket.EmployeeIdAccount
                );
            }
        }

        private async void btnGenerateInvoice_Click(object sender, EventArgs e)
        {
            // Check if a row is selected in dataGridView1
            if (dataGridView1.SelectedRows.Count > 0)
            {
                try
                {
                    // Assuming the first cell of the selected row contains the IdServiceTicket
                    int selectedTicketId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["IdServiceTicket"].Value);

                    // Initialize ServiceTicketDAO
                    ServiceTicketDAO serviceTicketDAO = new ServiceTicketDAO();

                    // Retrieve the ServiceTicket from the database using GetById method
                    ServiceTicket selectedTicket = await serviceTicketDAO.GetById(new ServiceTicket(selectedTicketId));

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
                        MessageBox.Show("Error retrieving Service Ticket from the database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    // Handle any exceptions that may occur
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                // Notify the user that no row is selected
                MessageBox.Show("Please select a row before generating an invoice.", "No Row Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Initialize the AddServiceTicketEmployeeForm
            AddServiceTicketEmployeeForm addServiceTicketEmployeeForm = new AddServiceTicketEmployeeForm();

            // Show the form
            addServiceTicketEmployeeForm.ShowDialog();
        }
    }
}
