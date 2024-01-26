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

            // Set visibility of comboboxes
            this.comboBoxLanguage.SelectedIndex = ApplicationService.languageIndex;
            this.comboBoxTheme.SelectedIndex = ApplicationService.themeIndex;

            // Initializing resourceManager
            resourceManager = new ResourceManager("TruckCentreWF.Forms.SettingsAdminForm", typeof(SettingsAdminForm).Assembly);

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

        private async void buttonSave_Click(object sender, EventArgs e)
        {
            // Assuming you have TextBox controls for language and theme
            int selectedLanguage = comboBoxLanguage.SelectedIndex;
            int selectedTheme = comboBoxTheme.SelectedIndex;

            // Retrieve the current admin account (you need to have a way to identify the current admin)
            int currentAdminId = ApplicationService.CurrEmployeeIdEmployee;

            // Fetch the current admin account from the database using the EmployeeService
            Employee currentAdmin = await EmployeeService.GetOneEmployee(new Employee { IdEmployee = currentAdminId });

            // Flag to indicate if language or theme is changed
            bool languageChanged = false;
            bool themeChanged = false;

            // Check if a valid language is selected
            if (selectedLanguage != -1)
            {
                // Update the language for the current admin using the ApplicationService method
                ApplicationService.SetLanguage(selectedLanguage);
                languageChanged = true;
            }

            // Update the theme for the current admin if it's different
            if (selectedTheme != -1 && selectedTheme != currentAdmin.Theme)
            {
                ApplicationService.CurrEmployee.Theme = selectedTheme;
                currentAdmin.Theme = selectedTheme;
                themeChanged = true;
            }

            // Refresh Form if either language or theme is changed
            if (languageChanged || themeChanged)
            {
                RefreshForm();
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
                currentAdmin.Password = Util.HashGenerator.GenerateHash(newPassword);

                // Set flag to true
                passwordChanged = true;

            }
            else if (string.IsNullOrEmpty(newPassword))
            {
                // If the new password is empty, don't update the password
            }
            else
            {
                MessageBox.Show(resourceManager.GetString("msgPasswordMismatch"),
                    resourceManager.GetString("lblError"),
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return; // Stop further processing
            }

            // Use the EmployeeService to update the admin account if any value is updated
            if (themeChanged || passwordChanged)
            {
                bool updateResult = await EmployeeService.UpdateEmployee(currentAdmin);
            }

            if (languageChanged || themeChanged || passwordChanged)
            {
                // Display a message about language and/or theme and/or password change
                MessageBox.Show(resourceManager.GetString("msgChangesSaved"),
                    resourceManager.GetString("lblInformation"),
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(resourceManager.GetString("msgNoChanges"),
                    resourceManager.GetString("lblInformation"),
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }

        }

        private void RefreshForm()
        {
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
        }

        private void SetNavyTheme()
        {
            // Set Form background colors
            this.BackColor = Color.FromArgb(234, 244, 244);
            this.buttonSave.BackColor = Color.FromArgb(52, 86, 109);

            // Set Form foregroung colors
            this.buttonSave.ForeColor = Color.FromArgb(200, 200, 200);
        }
        private void SetGrayTheme()
        {
            // Set Form background colors
            this.BackColor = Color.FromArgb(240, 240, 240);
            this.buttonSave.BackColor = Color.FromArgb(180, 180, 180); // Medium gray

            // Set Form foregroung colors
            this.buttonSave.ForeColor = Color.FromArgb(40, 40, 40); // Dark gray
        }

    }
}
