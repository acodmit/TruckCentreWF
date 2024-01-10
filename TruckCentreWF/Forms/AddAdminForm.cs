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

using TruckCentreWF.Model.Dto;
using TruckCentreWF.Service;

namespace TruckCentreWF.Forms
{
    public partial class AddAdminForm : DraggableForm
    {
        ResourceManager resourceManager;

        public AddAdminForm()
        {
            InitializeComponent();

            // Initializing resourceManager
            resourceManager = new ResourceManager("TruckCentreWF.Forms.AddAdminForm", typeof(AddAdminForm).Assembly);
        }

        private async void buttonAdd_Click(object sender, EventArgs e)
        {
            // Get input values from the form
            string username = textBoxUsername.Text;
            string password = textBoxPassword.Text;
            string repeatPassword = textBoxRepeatPassword.Text;
            bool isAdmin = checkBoxAdmin.Checked;
            bool status = comboBoxStatus.SelectedItem.ToString().ToLower() == "active"; // Assuming "Active" is selected by default
            string firstName = textBoxFirstName.Text;
            string lastName = textBoxLastName.Text;
            int theme = comboBoxTheme.SelectedIndex;

            // Validate password and repeated password
            if (password != repeatPassword)
            {
                MessageBox.Show(resourceManager.GetString("msgPasswordMismatch"), resourceManager.GetString("lblPasswordMismatch"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Hash the password (replace this with your actual password hashing logic)
            string hashedPassword = TruckCentreWF.Util.HashGenerator.GenerateHash(password);

            // Create an Employee object
            Employee newEmployee = new Employee(0, username, hashedPassword, isAdmin, status, firstName, lastName, theme);

            try
            {
                // Attempt to add the new employee
                bool addedSuccessfully = await EmployeeService.AddEmployee(newEmployee);

                if (addedSuccessfully)
                {
                    MessageBox.Show(resourceManager.GetString("msgSuccesfullUpdate"), resourceManager.GetString("lblSuccess"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Close the form or perform any other necessary actions
                }
                else
                {
                    MessageBox.Show(resourceManager.GetString("msgFailedUpdate"), resourceManager.GetString("lblError"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            // Close the current form
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            // Minimize the window
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
