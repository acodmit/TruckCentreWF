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
    public partial class SettingsAdminForm : Form
    {
        private ResourceManager resourceManager;

        public SettingsAdminForm()
        {
            InitializeComponent();

            // Initializing resourceManager
            resourceManager = new ResourceManager("TruckCentreWF.Forms.SettingsAdminForm", typeof(SettingsAdminForm).Assembly);
        }

        private async void buttonSave_Click(object sender, EventArgs e)
        {
            // Assuming you have TextBox controls for language and theme
            int selectedLanguage = comboBoxLanguage.SelectedIndex;
            int selectedTheme = comboBoxTheme.SelectedIndex;

            // Retrieve the current admin account (you need to have a way to identify the current admin)
            int currentAdminId = ApplicationService.CurrEmployeeIdEmployee;

            // Fetch the current admin account from the database using the EmployeeService
            Employee currentAdmin = await EmployeeService.GetOneEmployee(new Employee { IdEmployee = currentAdminId });

            // Flag to indicate if language is changed
            bool languageChanged = false;

            // Check if a valid language is selected
            if (selectedLanguage != -1)
            {
                // Update the language for the current admin using the ApplicationService method
                ApplicationService.SetLanguage(selectedLanguage);

                // Create a list to store forms to be closed
                List<Form> formsToClose = new List<Form>();

                // Collect forms to close
                foreach (Form form in Application.OpenForms)
                {
                    formsToClose.Add(form);
                }

                // Close the collected forms
                foreach (Form form in formsToClose)
                {
                    form.Hide();
                }

                // Start a new AdminForm
                AdminForm adminForm = new AdminForm();
                adminForm.Show();

                // Set flag to true
                languageChanged = true;

                // Display a message about language change
                MessageBox.Show(resourceManager.GetString("msgLanguageChanged"), resourceManager.GetString("lblInformation"), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            // Flag to indicate if theme is changed
            bool themeChanged = false;

            // Update the theme for the current admin if it's different
            if (selectedTheme != -1 && selectedTheme != currentAdmin.Theme)
            {
                currentAdmin.Theme = selectedTheme;
                themeChanged = true;
            }

            // Retrieve the new password and repeat password from the TextBox controls
            string newPassword = textBoxPassword.Text;
            string repeatPassword = textBoxRepeatPassword.Text;

            // Flag to indicate if password is changed
            bool passwordChanged = false;

            // Check if the new password and repeat password match
            if (!string.IsNullOrEmpty(newPassword) && newPassword == repeatPassword)
            {
                // Update the password for the current admin
                currentAdmin.Password = TruckCentreWF.Util.HashGenerator.GenerateHash(newPassword);

                // Set flag to true
                passwordChanged = true;

            }
            else if (string.IsNullOrEmpty(newPassword))
            {
                // If the new password is empty, don't update the password
            }
            else
            {
                MessageBox.Show(resourceManager.GetString("msgPasswordMismatch"), resourceManager.GetString("lblError"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Stop further processing
            }

            // Use the EmployeeService to update the admin account if any value is updated
            if (themeChanged || passwordChanged)
            {
                bool updateResult = await EmployeeService.UpdateEmployee(currentAdmin);

                if (updateResult)
                {
                    MessageBox.Show(resourceManager.GetString("msgSuccesfullUpdate"), resourceManager.GetString("lblSuccess"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(resourceManager.GetString("msgFailedUpdate"), resourceManager.GetString("lblError"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            if (!languageChanged && !themeChanged && !passwordChanged)
            {
                MessageBox.Show(resourceManager.GetString("msgNoChanges"), resourceManager.GetString("lblInformation"), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
    }
}
