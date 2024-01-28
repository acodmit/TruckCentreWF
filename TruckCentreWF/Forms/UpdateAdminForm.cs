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
using System.Windows.Forms.VisualStyles;

using TruckCentreWF.Model.Dto;
using TruckCentreWF.Service;

namespace TruckCentreWF.Forms
{
    partial class UpdateAdminForm : DraggableForm
    {
        private int _idEmployeeToUpdate = -1;
        private ResourceManager resourceManager;
        public UpdateAdminForm(Employee employeeToUpdate)
        {
            InitializeComponent();

            // Initializing resourceManager
            resourceManager = new ResourceManager("TruckCentreWF.Forms.UpdateAdminForm", typeof(UpdateAdminForm).Assembly);

            // Populate the form fields with the values from the existing Employee object
            _idEmployeeToUpdate = employeeToUpdate.IdEmployee;
            textBoxUsername.Text = employeeToUpdate.Username;
            textBoxPassword.Text = "";  // For security reasons, leave password fields empty
            textBoxRepeatPassword.Text = "";
            checkBoxAdmin.Checked = employeeToUpdate.IsAdmin;
            comboBoxStatus.SelectedItem = employeeToUpdate.Status ? "Active" : "Suspended";
            textBoxFirstName.Text = employeeToUpdate.FirstName;
            textBoxLastName.Text = employeeToUpdate.LastName;
            comboBoxTheme.SelectedItem = employeeToUpdate.Theme.ToString();

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

        private async void buttonUpdate_Click(object sender, EventArgs e)
        {
            // Retrieve the values from the form fields
            string username = textBoxUsername.Text;
            string password = textBoxPassword.Text;
            string repeatPassword = textBoxRepeatPassword.Text;
            bool isAdmin = checkBoxAdmin.Checked;
            string status = comboBoxStatus.SelectedItem.ToString();
            string firstName = textBoxFirstName.Text;
            string lastName = textBoxLastName.Text;
            int theme = comboBoxTheme.SelectedIndex != -1 ? comboBoxTheme.SelectedIndex : 0;

            // Check if passwords match
            if (password != repeatPassword)
            {
                MessageBox.Show(resourceManager.GetString("msgPasswordMismatch"),
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            // Create an Employee object with the updated values
            Employee updatedEmployee = new Employee(
                _idEmployeeToUpdate,  // _idEmployeeToUpdate is the ID of the employee to update
                username,
                TruckCentreWF.Util.HashGenerator.GenerateHash(password),
                isAdmin,
                status.Equals("Active", StringComparison.OrdinalIgnoreCase),
                firstName,
                lastName,
                theme
            );

            // Call the UpdateEmployee method to update the employee
            bool updateResult = await TruckCentreWF.Service.EmployeeService.UpdateEmployee(updatedEmployee);

            // Check the result of the update operation
            if (updateResult)
            {
                MessageBox.Show(resourceManager.GetString("msgSuccesfullUpdate"),
                    resourceManager.GetString("lblSuccess"),
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                this.Close();  // Close the form after a successful update
            }
            else
            {
                MessageBox.Show(resourceManager.GetString("msgFailedUpdate"),
                    resourceManager.GetString("lblError"),
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
            this.comboBoxTheme.BackColor = Color.FromArgb(72, 106, 129);
            this.buttonAdd.BackColor = Color.FromArgb(52, 86, 109);
            this.comboBoxStatus.BackColor = Color.FromArgb(72, 106, 129);

            // Foreground Colors
            this.labelTheme.ForeColor = Color.FromArgb(150, 180, 208);
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

