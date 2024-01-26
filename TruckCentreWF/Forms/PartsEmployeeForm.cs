using MySqlX.XDevAPI;
using MySqlX.XDevAPI.Relational;
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
    public partial class PartsEmployeeForm : Form
    {
        private List<Part> parts;
        private ResourceManager resourceManager;
        public PartsEmployeeForm()
        {
            InitializeComponent();

            // Initializing resourceManager
            resourceManager = new ResourceManager("TruckCentreWF.Forms.PartsEmployeeForm", typeof(PartsEmployeeForm).Assembly);

            // Load data to parts grid
            LoadData();

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

        // Method to set navy style colors
        private void SetNavyTheme()
        {
            // Form Background Color
            this.BackColor = Color.FromArgb(234, 244, 244);

            // Background Colors
            this.dataGridViewParts.BackgroundColor = Color.FromArgb(150, 180, 208);

            // Foreground Colors
            foreach (DataGridViewColumn column in dataGridViewParts.Columns)
            {
                column.HeaderCell.Style.ForeColor = Color.FromArgb(20, 40, 80);
                column.DefaultCellStyle.ForeColor = Color.FromArgb(20, 40, 80);
            }

            // Buttons
            this.btnAdd.BackColor = Color.FromArgb(52, 86, 109);
            this.btnDelete.BackColor = Color.FromArgb(52, 86, 109);
            this.btnAdd.ForeColor = Color.FromArgb(200, 200, 200);
            this.btnDelete.ForeColor = Color.FromArgb(200, 200, 200);
        }
        private void SetGrayTheme()
        {
            // Form Background Color
            this.BackColor = Color.FromArgb(240, 240, 240); // Light gray

            // Background Colors
            this.dataGridViewParts.BackgroundColor = Color.FromArgb(220, 220, 220); // Lighter gray

            // Foreground Colors
            foreach (DataGridViewColumn column in dataGridViewParts.Columns)
            {
                column.HeaderCell.Style.ForeColor = Color.FromArgb(70, 70, 70); // Dark gray
                column.DefaultCellStyle.ForeColor = Color.FromArgb(70, 70, 70); // Dark gray
            }

            // Buttons
            this.btnAdd.BackColor = Color.FromArgb(180, 180, 180); // Medium gray
            this.btnDelete.BackColor = Color.FromArgb(180, 180, 180); // Medium gray
            this.btnAdd.ForeColor = Color.FromArgb(40, 40, 40); // Dark gray
            this.btnDelete.ForeColor = Color.FromArgb(40, 40, 40); // Dark gray
        }

        public async void LoadData()
        {
            PartDAO partsDAO = new PartDAO();
            parts = await partsDAO.GetAll();

            DisplayData();
        }

        private void DisplayData()
        {
            // Clear existing rows
            dataGridViewParts.Rows.Clear();

            // Add data to the table
            foreach (var part in parts)
            {
                dataGridViewParts.Rows.Add(
                    part.SerialNumber,
                    part.Name,
                    part.UnitPrice
                );
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Generate AddPartEmployeeForm
            AddPartEmployeeForm addPartEmployeeForm = new AddPartEmployeeForm(this);

            // Show form
            addPartEmployeeForm.Show();
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            // Check if a row is selected
            if (dataGridViewParts.SelectedRows.Count == 1)
            {
                // Get the selected part
                var selectedPart = parts[dataGridViewParts.SelectedRows[0].Index];

                // Ask for confirmation before deletion
                var result = MessageBox.Show(
                    string.Format(resourceManager.GetString("msgDeleteQuestion") + "'{0}'?", selectedPart.Name),
                    resourceManager.GetString("lblDeleteConfirmation"),
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        PartDAO partDAO = new PartDAO();

                        // Delete the selected part
                        int deleted = await partDAO.Delete(selectedPart);

                        if (deleted != -1)
                        {
                            MessageBox.Show(
                                resourceManager.GetString("msgSuccessfullyDeleted"),
                                resourceManager.GetString("lblSuccess"),
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                            LoadData();
                        }
                        else
                        {
                            MessageBox.Show(
                                resourceManager.GetString("msgFailedDeleting"),
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
            else
            {
                MessageBox.Show(
                    resourceManager.GetString("msgSelectRow"),
                    resourceManager.GetString("lblWarning"),
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

    }
}
