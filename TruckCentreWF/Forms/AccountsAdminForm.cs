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
using TruckCentreWF.Model.Dto;
using System.Resources;

namespace TruckCentreWF.Forms
{
    public partial class AccountsAdminForm : Form
    {            
        private List<Employee> employees;

        private ResourceManager resourceManager;
        public AccountsAdminForm()
        {
            InitializeComponent();

            // Initialize ResourceManager
            resourceManager = new ResourceManager("TruckCentreWF.Forms.AccountsAdminForm", typeof(AccountsAdminForm).Assembly);

            // Load data to the grid
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

        private async void LoadData()
        {
            employees = await EmployeeService.GetAllEmployees();
            Console.Write(employees);
            DisplayData();
        }

        private void DisplayData()
        {
            // Clear existing rows
            dataGridView1.Rows.Clear();

            // Add data to the table
            foreach (var employee in employees)
            {
                dataGridView1.Rows.Add(
                    employee.Username,
                    employee.IsAdmin,
                    employee.FirstName,
                    employee.LastName,
                    employee.Theme,
                    employee.Status
                );
            }
        }

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
            this.button1.BackColor = Color.FromArgb(52, 86, 109);
            this.button2.BackColor = Color.FromArgb(52, 86, 109);
            this.button3.BackColor = Color.FromArgb(52, 86, 109);
            this.button1.ForeColor = Color.FromArgb(200, 200, 200);
            this.button2.ForeColor = Color.FromArgb(200, 200, 200);
            this.button3.ForeColor = Color.FromArgb(200, 200, 200);
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
            this.button1.BackColor = Color.FromArgb(180, 180, 180); // Medium gray
            this.button2.BackColor = Color.FromArgb(180, 180, 180); // Medium gray
            this.button3.BackColor = Color.FromArgb(180, 180, 180); // Medium gray
            this.button1.ForeColor = Color.FromArgb(40, 40, 40); // Dark gray
            this.button2.ForeColor = Color.FromArgb(40, 40, 40); // Dark gray
            this.button3.ForeColor = Color.FromArgb(40, 40, 40); // Dark gray
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Open the form to add a new account
            var addForm = new AddAdminForm();
            addForm.FormClosed += (s, args) => LoadData();
            addForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Check if a row is selected
            if (dataGridView1.SelectedRows.Count == 1)
            {
                // Get the selected employee
                var selectedEmployee = employees[dataGridView1.SelectedRows[0].Index];

                // Open the form to update the selected account
                var updateForm = new UpdateAdminForm(selectedEmployee);
                updateForm.FormClosed += (s, args) => LoadData();
                updateForm.Show();
            }
            else
            {
                MessageBox.Show("Please select a row to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            // Check if a row is selected
            if (dataGridView1.SelectedRows.Count == 1)
            {
                // Get the selected employee
                var selectedEmployee = employees[dataGridView1.SelectedRows[0].Index];

                // Ask for confirmation before deletion
                var result = MessageBox.Show(
                    string.Format(resourceManager.GetString("msgDeleteConfirmation"), selectedEmployee.Username),
                    resourceManager.GetString("msgDeleteConfirmationTitle"),
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Delete the selected employee
                    bool deleted = await EmployeeService.DeleteEmployee(selectedEmployee);

                    if (deleted)
                    {
                        MessageBox.Show(
                            resourceManager.GetString("msgDeleteSuccess"),
                            resourceManager.GetString("msgSuccessTitle"),
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        LoadData();
                    }
                    else
                    {
                        MessageBox.Show(
                            resourceManager.GetString("msgDeleteError"),
                            resourceManager.GetString("msgErrorTitle"),
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show(
                    resourceManager.GetString("msgNoRowSelectedWarning"),
                    resourceManager.GetString("msgWarningTitle"),
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

    }
}
