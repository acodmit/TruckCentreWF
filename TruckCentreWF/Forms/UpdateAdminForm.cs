﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

using TruckCentreWF.Model.Dto;

namespace TruckCentreWF.Forms
{
    partial class UpdateAdminForm : DraggableForm
    {
        private int _idEmployeeToUpdate = -1;

        public UpdateAdminForm(Employee employeeToUpdate)
        {
            InitializeComponent();

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
                MessageBox.Show("Passwords do not match.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("Employee updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();  // Close the form after a successful update
            }
            else
            {
                MessageBox.Show("Failed to update employee.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
