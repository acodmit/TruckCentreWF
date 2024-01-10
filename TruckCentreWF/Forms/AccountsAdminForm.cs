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

namespace TruckCentreWF.Forms
{
    public partial class AccountsAdminForm : Form
    {            
        private List<Employee> employees;

        public AccountsAdminForm()
        {
            InitializeComponent();
            LoadData();
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
                    employee.IdEmployee,
                    employee.Username,
                    employee.IsAdmin,
                    employee.FirstName,
                    employee.LastName,
                    employee.Theme,
                    employee.Status
                );
            }
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
                var result = MessageBox.Show($"Are you sure you want to delete the account for {selectedEmployee.Username}?",
                    "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Delete the selected employee
                    bool deleted = await EmployeeService.DeleteEmployee(selectedEmployee);

                    if (deleted)
                    {
                        MessageBox.Show("Account deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData();
                    }
                    else
                    {
                        MessageBox.Show("Failed to delete account.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a row to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
