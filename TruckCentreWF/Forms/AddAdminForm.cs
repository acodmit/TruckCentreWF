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

        private async void buttonAdd_Click(object sender, EventArgs e)
        {
            // Get input values from the form
            string username = textBoxUsername.Text;
            string password = textBoxPassword.Text;
            string repeatPassword = textBoxRepeatPassword.Text;
            bool isAdmin = checkBoxAdmin.Checked;
            bool status = comboBoxStatus.SelectedItem.ToString().ToLower().Equals("active"); // Assuming "Active" is selected by default
            string firstName = textBoxFirstName.Text;
            string lastName = textBoxLastName.Text;
            int theme = comboBoxTheme.SelectedIndex;

            // Validate password and repeated password
            if (password != repeatPassword)
            {
                MessageBox.Show(resourceManager.GetString("msgPasswordMismatch"),
                    resourceManager.GetString("lblPasswordMismatch"),
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
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
                    MessageBox.Show(resourceManager.GetString("msgSuccesfullyAdded"),
                        resourceManager.GetString("lblSuccess"),
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    // Close the form or perform any other necessary actions
                }
                else
                {
                    MessageBox.Show(resourceManager.GetString("msgFailedAdding"),
                        resourceManager.GetString("lblError"),
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
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

        private void SetNavyTheme()
        {
            // Background Colors
            this.BackColor = Color.FromArgb(234, 244, 244);
            this.comboBoxStatus.BackColor = Color.FromArgb(72, 106, 129);
            this.comboBoxTheme.BackColor = Color.FromArgb(72, 106, 129);
            this.buttonAdd.BackColor = Color.FromArgb(52, 86, 109);

            // Foreground Colors
            this.labelUsername.ForeColor = Color.FromArgb(20, 40, 80);
            this.labelPassword.ForeColor = Color.FromArgb(20, 40, 80);
            this.labelRepeatPassword.ForeColor = Color.FromArgb(20, 40, 80);
            this.labelStatus.ForeColor = Color.FromArgb(20, 40, 80);
            this.labelFirstName.ForeColor = Color.FromArgb(20, 40, 80);
            this.labelLastName.ForeColor = Color.FromArgb(20, 40, 80);
            this.labelTheme.ForeColor = Color.FromArgb(20, 40, 80);
            this.checkBoxAdmin.ForeColor = Color.FromArgb(20, 40, 80);
            this.buttonAdd.ForeColor = Color.FromArgb(200, 200, 200);
        }

        private void SetGrayTheme()
        {
            // Background Colors
            this.BackColor = Color.FromArgb(240, 240, 240); // Light gray
            this.comboBoxStatus.BackColor = Color.FromArgb(180, 180, 180); // Medium gray
            this.comboBoxTheme.BackColor = Color.FromArgb(180, 180, 180); // Medium gray
            this.buttonAdd.BackColor = Color.FromArgb(200, 200, 200); // Light gray

            // Foreground Colors
            this.labelUsername.ForeColor = Color.FromArgb(70, 70, 70); // Dark gray
            this.labelPassword.ForeColor = Color.FromArgb(70, 70, 70); // Dark gray
            this.labelRepeatPassword.ForeColor = Color.FromArgb(70, 70, 70); // Dark gray
            this.labelStatus.ForeColor = Color.FromArgb(70, 70, 70); // Dark gray
            this.labelFirstName.ForeColor = Color.FromArgb(70, 70, 70); // Dark gray
            this.labelLastName.ForeColor = Color.FromArgb(70, 70, 70); // Dark gray
            this.labelTheme.ForeColor = Color.FromArgb(70, 70, 70); // Dark gray
            this.checkBoxAdmin.ForeColor = Color.FromArgb(70, 70, 70); // Dark gray
            this.buttonAdd.ForeColor = Color.FromArgb(40, 40, 40); // Dark gray
        }
    }
}
