using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

using TruckCentreWF.Service;
using System.Globalization;
using System.Resources;

namespace TruckCentreWF.Forms
{
    public partial class LoginForm : DraggableForm
    {
        ResourceManager resourceManager;
        public LoginForm()
        {
            InitializeComponent();

            // Initialize ResourceManager
            resourceManager = new ResourceManager("TruckCentreWF.Forms.LoginForm", typeof(LoginForm).Assembly);


        }

        private void languageComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplicationService.SetLanguage(languageComboBox.SelectedIndex);

            this.Controls.Clear();
            InitializeComponent();
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            // Exit the entire program
            Application.Exit();
        }

        private void toolStripLabel2_Click(object sender, EventArgs e)
        {
            // Minimize the window
            this.WindowState = FormWindowState.Minimized;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            string userType = await LoginService.CheckLogin(textBox1.Text, textBox2.Text);

            // Handle the result as needed
            if (userType == "A")
            {
                // Open the AdminForm
                AdminForm adminForm = new AdminForm();
                adminForm.Show();
                this.Hide();
            }
            else if (userType == "E")
            {
                // Open the EmployeeForm
                EmployeeForm employeeForm = new EmployeeForm();
                employeeForm.Show();
                this.Hide();
            }
            else
            {
                // Show an error message for incorrect username or password
                MessageBox.Show(resourceManager.GetString("msgIncorrect"),
                    resourceManager.GetString("msgLoginFailed"),
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

    }
}

