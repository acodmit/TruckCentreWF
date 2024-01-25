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
    public partial class AddPartEmployeeForm : DraggableForm
    {
        private PartsEmployeeForm partsForm;
        ResourceManager resourceManager;
        public AddPartEmployeeForm(PartsEmployeeForm partsEmployeeForm)
        {
            // Set partsForm
            this.partsForm = partsEmployeeForm;

            InitializeComponent();

            // Initializing resourceManager
            resourceManager = new ResourceManager("TruckCentreWF.Forms.AddPartEmployeeForm", typeof(AddPartEmployeeForm).Assembly);
            
            // Set the theme based on the Employee's theme value
            if (ApplicationService.CurrEmployee.Theme == 1)
            {
                SetNavyTheme();
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
            this.lblExit.ForeColor = Color.FromArgb(20, 40, 80);
            this.lblMinimise.ForeColor = Color.FromArgb(20, 40, 80);
            this.lblExit.ForeColor = Color.FromArgb(20, 40, 80);
            this.lblMinimise.ForeColor = Color.FromArgb(20, 40, 80);
            this.btnAdd.ForeColor = Color.FromArgb(200, 200, 200);
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
            string partName = txbPartName.Text;
            decimal unitPrice;

            // Validate and parse the unit price
            if (!decimal.TryParse(txbUnitPrice.Text, out unitPrice))
            {
                MessageBox.Show(resourceManager.GetString("msgInvalidUnitPrice"),
                    resourceManager.GetString("lblError"),
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }
                        
            // Create a Part object
            Part newPart = new Part(0, partName, unitPrice);

            try
            {
                PartDAO partDAO = new PartDAO();

                // Attempt to add the new part
                int addedSuccessfully = await partDAO.Insert(newPart);

                if (addedSuccessfully != -1)
                {
                    MessageBox.Show(resourceManager.GetString("msgSuccessfulyAdded"),
                        resourceManager.GetString("lblSuccess"),
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    // Refresh partsForm form
                    partsForm.LoadData();

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
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
