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
    public partial class AddVehicleEmployeeForm : DraggableForm
    {
        private VehiclesEmployeeForm vehiclesForm;
        private ResourceManager resourceManager;
        public AddVehicleEmployeeForm(VehiclesEmployeeForm vehiclesEmployeeForm)
        {
            // Set vehiclesForm
            vehiclesForm = vehiclesEmployeeForm;

            InitializeComponent();

            // Initializing resourceManager
            resourceManager = new ResourceManager("TruckCentreWF.Forms.AddVehicleEmployeeForm", typeof(AddVehicleEmployeeForm).Assembly);
            
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
            this.lblIdVehicle.ForeColor = Color.FromArgb(20, 40, 80);
            this.lblMileage.ForeColor = Color.FromArgb(20, 40, 80);
            this.lblDetails.ForeColor = Color.FromArgb(20, 40, 80);
            this.lblLastService.ForeColor = Color.FromArgb(20, 40, 80);
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
            this.lblIdVehicle.ForeColor = Color.FromArgb(70, 70, 70); // Dark gray
            this.lblMileage.ForeColor = Color.FromArgb(70, 70, 70); // Dark gray
            this.lblDetails.ForeColor = Color.FromArgb(70, 70, 70); // Dark gray
            this.lblLastService.ForeColor = Color.FromArgb(70, 70, 70); // Dark gray
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
            string idVehicle = txbIdVehicle.Text;
            string mileageStr = txbMileage.Text;
            string details = txbDetails.Text;
            DateTime lastServiceDate = dtpLastService.Value;

            // Validate input values
            if (string.IsNullOrWhiteSpace(mileageStr) || !int.TryParse(mileageStr, out int mileage) || mileage < 0)
            {
                MessageBox.Show(resourceManager.GetString("msgValidMileage"),
                    resourceManager.GetString("lblError"),
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            // Create a Vehicle object
            Vehicle newVehicle = new Vehicle
            {
                IdVehicle = idVehicle,
                Mileage = mileage.ToString(),
                Details = details,
                LastService = lastServiceDate
            };

            try
            {
                VehicleDAO vehicleDAO = new VehicleDAO();

                // Attempt to add a new vehicle
                int addedSuccessfully = await vehicleDAO.Insert(newVehicle);

                if (addedSuccessfully != -1)
                {
                    MessageBox.Show(resourceManager.GetString("msgSuccesfullyAdded"),
                        resourceManager.GetString("lblSuccess"),
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    // Close the form or perform any other necessary actions
                    this.Close();

                    // Refresh vehicles form
                    vehiclesForm.LoadData();
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
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
