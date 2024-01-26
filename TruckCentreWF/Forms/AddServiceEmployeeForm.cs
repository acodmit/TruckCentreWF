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
using TruckCentreWF.Model.Dao;
using TruckCentreWF.Model.Dto;
using TruckCentreWF.Service;

namespace TruckCentreWF.Forms
{
    public partial class AddServiceEmployeeForm : DraggableForm
    {
        private ServicesEmployeeForm servicesForm;
        private ResourceManager resourceManager;
        public AddServiceEmployeeForm(ServicesEmployeeForm servicesEmployeeForm)
        {
            // Set servicesForm
            this.servicesForm = servicesEmployeeForm;
            
            InitializeComponent();

            // Initializing resourceManager
            resourceManager = new ResourceManager("TruckCentreWF.Forms.AddServiceEmployeeForm", typeof(AddServiceEmployeeForm).Assembly);
            
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

        private void SetNavyTheme()
        {
            // Background Colors
            this.BackColor = Color.FromArgb(234, 244, 244);
            this.btnAdd.BackColor = Color.FromArgb(52, 86, 109);

            // Foreground Colors
            this.lblServiceFee.ForeColor = Color.FromArgb(20, 40, 80);
            this.lblServiceName.ForeColor = Color.FromArgb(20, 40, 80);
            this.lblExit.ForeColor = Color.FromArgb(20, 40, 80);
            this.lblMinimise.ForeColor = Color.FromArgb(20, 40, 80);
            this.btnAdd.ForeColor = Color.FromArgb(200, 200, 200);
        }
        private void SetGrayTheme()
        {
            // Background Colors
            this.BackColor = Color.FromArgb(240, 240, 240); // Light gray
            this.btnAdd.BackColor = Color.FromArgb(180, 180, 180); // Medium gray

            // Foreground Colors
            this.lblServiceFee.ForeColor = Color.FromArgb(70, 70, 70); // Dark gray
            this.lblServiceName.ForeColor = Color.FromArgb(70, 70, 70); // Dark gray
            this.lblExit.ForeColor = Color.FromArgb(70, 70, 70); // Dark gray
            this.lblMinimise.ForeColor = Color.FromArgb(70, 70, 70); // Dark gray
            this.btnAdd.ForeColor = Color.FromArgb(40, 40, 40); // Dark gray
        }

        private void lblExit_Click(object sender, EventArgs e)
        {
            // Close the current form
            this.Close();
        }

        private void lblMinimise_Click(object sender, EventArgs e)
        {
            // Minimize the window
            this.WindowState = FormWindowState.Minimized;
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            // Get input values from the form
            string serviceName = txbServiceName.Text;
            decimal serviceFee;
            decimal labour;

            // Validate and parse serviceFee
            if (!decimal.TryParse(txbServiceFee.Text, out serviceFee))
            {
                MessageBox.Show(resourceManager.GetString("msgInvalidServiceFee"),
                    resourceManager.GetString("lblError"),
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            // Validate and parse labour
            if (!decimal.TryParse(txbLabour.Text, out labour))
            {
                MessageBox.Show(resourceManager.GetString("msgInvalidLabour"),
                    resourceManager.GetString("lblError"),
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            // Create a Service object
            Model.Dto.Service newService = new Model.Dto.Service(0, serviceName, serviceFee, labour);

            try
            {
                ServiceDAO serviceDAO = new ServiceDAO();

                // Attempt to add a new service
                int addedSuccessfully = await serviceDAO.Insert(newService);

                if (addedSuccessfully != -1)
                {
                    MessageBox.Show(resourceManager.GetString("msgSuccesfullyAdded"),
                        resourceManager.GetString("lblSuccess"),
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    // Refresh servicesForm form
                    servicesForm.LoadData();

                    // Close the form
                    this.Close();
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
    }
}
