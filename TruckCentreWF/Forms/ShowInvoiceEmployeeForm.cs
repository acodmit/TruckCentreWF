using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
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
    public partial class ShowInvoiceEmployeeForm : DraggableForm
    {
        private ServiceTicket processingTicket;
        private List<ItemPart> itemParts;
        private List<Model.Dto.ItemService> itemServices;
        private ResourceManager resourceManager;
        public ShowInvoiceEmployeeForm( ServiceTicket serviceTicket)
        {
            // Set processingTicket
            processingTicket = serviceTicket;

            InitializeComponent();

            // Initializing resourceManager
            resourceManager = new ResourceManager("TruckCentreWF.Forms.ShowInvoiceEmployeeForm", typeof(ShowInvoiceEmployeeForm).Assembly);

            // Set lblInvoiceDetails text
            SetInvoiceDetailsText();

            // Load data to part and service grids
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
            this.dataGridServices.BackgroundColor = Color.FromArgb(150, 180, 208);

            // Foreground Colors
            foreach (DataGridViewColumn column in dataGridViewParts.Columns)
            {
                column.HeaderCell.Style.ForeColor = Color.FromArgb(20, 40, 80);
                column.DefaultCellStyle.ForeColor = Color.FromArgb(20, 40, 80);
            }
            foreach (DataGridViewColumn column in dataGridServices.Columns)
            {
                column.HeaderCell.Style.ForeColor = Color.FromArgb(20, 40, 80);
                column.DefaultCellStyle.ForeColor = Color.FromArgb(20, 40, 80);
            }

            // Labels
            this.lblTitle.ForeColor = Color.FromArgb(20, 40, 80);
            this.lblInvoiceDetails.ForeColor = Color.FromArgb(20, 40, 80);
            this.lblParts.ForeColor = Color.FromArgb(20, 40, 80);
            this.lblServices.ForeColor = Color.FromArgb(20, 40, 80);
            this.lblMinimise.ForeColor = Color.FromArgb(20, 40, 80);
            this.lblExit.ForeColor = Color.FromArgb(20, 40, 80);
        }
        private void SetGrayTheme()
        {
            // Form Background Color
            this.BackColor = Color.FromArgb(240, 240, 240); // Light gray

            // Background Colors
            this.dataGridViewParts.BackgroundColor = Color.FromArgb(220, 220, 220); // Lighter gray
            this.dataGridServices.BackgroundColor = Color.FromArgb(220, 220, 220); // Lighter gray

            // Foreground Colors
            foreach (DataGridViewColumn column in dataGridViewParts.Columns)
            {
                column.HeaderCell.Style.ForeColor = Color.FromArgb(70, 70, 70); // Dark gray
                column.DefaultCellStyle.ForeColor = Color.FromArgb(70, 70, 70); // Dark gray
            }
            foreach (DataGridViewColumn column in dataGridServices.Columns)
            {
                column.HeaderCell.Style.ForeColor = Color.FromArgb(70, 70, 70); // Dark gray
                column.DefaultCellStyle.ForeColor = Color.FromArgb(70, 70, 70); // Dark gray
            }

            // Labels
            this.lblTitle.ForeColor = Color.FromArgb(70, 70, 70); // Dark gray
            this.lblInvoiceDetails.ForeColor = Color.FromArgb(70, 70, 70); // Dark gray
            this.lblParts.ForeColor = Color.FromArgb(70, 70, 70); // Dark gray
            this.lblServices.ForeColor = Color.FromArgb(70, 70, 70); // Dark gray
            this.lblMinimise.ForeColor = Color.FromArgb(70, 70, 70); // Dark gray
            this.lblExit.ForeColor = Color.FromArgb(70, 70, 70); // Dark gray
        }

        private void SetInvoiceDetailsText()
        {
            if (processingTicket != null)
            {
                // Concatenating Entry date text with value
                string entryDateText = resourceManager.GetString("lblEntryDate");
                string entryDate = $"{entryDateText} {processingTicket.EntryDate.ToString("yyyy-MM-dd")}\n";

                lblInvoiceDetails.Text = entryDate;
            }
            else
            {
                lblInvoiceDetails.Text = resourceManager.GetString("lblNoDetails");
            }
        }


        private async void LoadData()
        {
            ItemPartDAO itemPartDAO = new ItemPartDAO();
            ItemServiceDAO itemServiceDAO = new ItemServiceDAO();

            itemParts = await itemPartDAO.GetByServiceTicketId(processingTicket.IdServiceTicket);
            itemServices = await itemServiceDAO.GetByServiceTicketId(processingTicket.IdServiceTicket);

            DisplayData();
        }

        private void DisplayData()
        {
            // Clear existing rows
            dataGridViewParts.Rows.Clear();
            dataGridServices.Rows.Clear();

            // Sum of item prices
            decimal totalAmount = 0;

            // Add data to the tables
            foreach (var itemPart in itemParts)
            {
                dataGridViewParts.Rows.Add(
                    itemPart.SerialNumber,
                    itemPart.Name,
                    itemPart.UnitPrice,
                    itemPart.Quantity,
                    itemPart.ItemPrice
                );

                totalAmount += itemPart.ItemPrice ?? 0; // Use null coalescing operator
            }

            foreach (var itemService in itemServices)
            {
                dataGridServices.Rows.Add(
                    itemService.IdService,
                    itemService.Name,
                    itemService.ServiceFee,
                    itemService.Labour,
                    itemService.LabourAmount,
                    itemService.ItemPrice
                );

                totalAmount += itemService.ItemPrice;
            }

            // Concatenating Total amount text with value
            string totalAmountText = resourceManager.GetString("lblTotalAmount");
            lblGrandTotal.Text = $"{totalAmountText} {totalAmount.ToString("C2", new CultureInfo("de"))}";
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
    }
}
