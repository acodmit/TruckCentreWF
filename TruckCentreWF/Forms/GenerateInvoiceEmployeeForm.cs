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
    public partial class GenerateInvoiceEmployeeForm : DraggableForm
    {
        private List<Part> parts;
        private List<Model.Dto.Service> services;
        private List<ItemPart> itemParts;
        private List<ItemService> itemServices;

        private ServiceTicket processingTicket;
        private ResourceManager resourceManager;
        public GenerateInvoiceEmployeeForm(ServiceTicket serviceTicket)
        {
            // Set ticket processing
            this.processingTicket = serviceTicket;

            InitializeComponent();

            // Initializing resourceManager
            resourceManager = new ResourceManager("TruckCentreWF.Forms.GenerateInvoiceEmployeeForm", typeof(GenerateInvoiceEmployeeForm).Assembly);

            // Load data to part and service grids
            LoadData();

            // Load data to item part and item service grids
            LoadItemData();

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
            // Form Background Color
            this.BackColor = Color.FromArgb(234, 244, 244);

            // Background Colors
            this.dataGridViewParts.BackgroundColor = Color.FromArgb(150, 180, 208);
            this.dataGridViewServices.BackgroundColor = Color.FromArgb(150, 180, 208);
            this.dataGridViewItemParts.BackgroundColor = Color.FromArgb(150, 180, 208);
            this.dataGridViewItemServices.BackgroundColor = Color.FromArgb(150, 180, 208);

            // Foreground Colors
            foreach (DataGridViewColumn column in dataGridViewParts.Columns)
            {
                column.HeaderCell.Style.ForeColor = Color.FromArgb(20, 40, 80);
                column.DefaultCellStyle.ForeColor = Color.FromArgb(20, 40, 80);
            }
            foreach (DataGridViewColumn column in dataGridViewServices.Columns)
            {
                column.HeaderCell.Style.ForeColor = Color.FromArgb(20, 40, 80);
                column.DefaultCellStyle.ForeColor = Color.FromArgb(20, 40, 80);
            }
            foreach (DataGridViewColumn column in dataGridViewItemParts.Columns)
            {
                column.HeaderCell.Style.ForeColor = Color.FromArgb(20, 40, 80);
                column.DefaultCellStyle.ForeColor = Color.FromArgb(20, 40, 80);
            }
            foreach (DataGridViewColumn column in dataGridViewItemServices.Columns)
            {
                column.HeaderCell.Style.ForeColor = Color.FromArgb(20, 40, 80);
                column.DefaultCellStyle.ForeColor = Color.FromArgb(20, 40, 80);
            }

            // Buttons
            this.btnAddPart.BackColor = Color.FromArgb(52, 86, 109);
            this.btnAddService.BackColor = Color.FromArgb(52, 86, 109);
            this.btnRemovePart.BackColor = Color.FromArgb(52, 86, 109);
            this.btn.BackColor = Color.FromArgb(52, 86, 109);
            this.btnShowInvoice.BackColor = Color.FromArgb(52, 86, 109);
            this.btnAddPart.ForeColor = Color.FromArgb(200, 200, 200);
            this.btnAddService.ForeColor = Color.FromArgb(200, 200, 200);
            this.btnRemovePart.ForeColor = Color.FromArgb(200, 200, 200);
            this.btn.ForeColor = Color.FromArgb(200, 200, 200);
            this.btnShowInvoice.ForeColor = Color.FromArgb(200, 200, 200);

            // Labels
            this.lblMinimise.ForeColor = Color.FromArgb(20, 40, 80);
            this.lblExit.ForeColor = Color.FromArgb(20, 40, 80);
        }
        private void SetGrayTheme()
        {
            // Form Background Color
            this.BackColor = Color.FromArgb(240, 240, 240); // Light gray

            // Background Colors
            this.dataGridViewParts.BackgroundColor = Color.FromArgb(220, 220, 220); // Lighter gray
            this.dataGridViewServices.BackgroundColor = Color.FromArgb(220, 220, 220); // Lighter gray
            this.dataGridViewItemParts.BackgroundColor = Color.FromArgb(220, 220, 220); // Lighter gray
            this.dataGridViewItemServices.BackgroundColor = Color.FromArgb(220, 220, 220); // Lighter gray

            // Foreground Colors
            foreach (DataGridViewColumn column in dataGridViewParts.Columns)
            {
                column.HeaderCell.Style.ForeColor = Color.FromArgb(70, 70, 70); // Dark gray
                column.DefaultCellStyle.ForeColor = Color.FromArgb(70, 70, 70); // Dark gray
            }
            foreach (DataGridViewColumn column in dataGridViewServices.Columns)
            {
                column.HeaderCell.Style.ForeColor = Color.FromArgb(70, 70, 70); // Dark gray
                column.DefaultCellStyle.ForeColor = Color.FromArgb(70, 70, 70); // Dark gray
            }
            foreach (DataGridViewColumn column in dataGridViewItemParts.Columns)
            {
                column.HeaderCell.Style.ForeColor = Color.FromArgb(70, 70, 70); // Dark gray
                column.DefaultCellStyle.ForeColor = Color.FromArgb(70, 70, 70); // Dark gray
            }
            foreach (DataGridViewColumn column in dataGridViewItemServices.Columns)
            {
                column.HeaderCell.Style.ForeColor = Color.FromArgb(70, 70, 70); // Dark gray
                column.DefaultCellStyle.ForeColor = Color.FromArgb(70, 70, 70); // Dark gray
            }

            // Buttons
            this.btnAddPart.BackColor = Color.FromArgb(180, 180, 180); // Medium gray
            this.btnAddService.BackColor = Color.FromArgb(180, 180, 180); // Medium gray
            this.btnRemovePart.BackColor = Color.FromArgb(180, 180, 180); // Medium gray
            this.btn.BackColor = Color.FromArgb(180, 180, 180); // Medium gray
            this.btnShowInvoice.BackColor = Color.FromArgb(180, 180, 180); // Medium gray
            this.btnAddPart.ForeColor = Color.FromArgb(40, 40, 40); // Dark gray
            this.btnAddService.ForeColor = Color.FromArgb(40, 40, 40); // Dark gray
            this.btnRemovePart.ForeColor = Color.FromArgb(40, 40, 40); // Dark gray
            this.btn.ForeColor = Color.FromArgb(40, 40, 40); // Dark gray
            this.btnShowInvoice.ForeColor = Color.FromArgb(40, 40, 40); // Dark gray

            // Labels
            this.lblMinimise.ForeColor = Color.FromArgb(70, 70, 70); // Dark gray
            this.lblExit.ForeColor = Color.FromArgb(70, 70, 70); // Dark gray
        }

        private async void LoadData()
        {
            PartDAO partsDAO = new PartDAO();
            ServiceDAO serviceDAO = new ServiceDAO();

            parts = await partsDAO.GetAll();
            services = await serviceDAO.GetAll();

            Console.Write(parts);
            Console.Write(services);

            DisplayData();
        }

        private void DisplayData()
        {
            // Clear existing rows
            dataGridViewParts.Rows.Clear();
            dataGridViewServices.Rows.Clear();

            // Add data to the tables
            foreach (var part in parts)
            {
                dataGridViewParts.Rows.Add(
                    part.SerialNumber,
                    part.Name,
                    part.UnitPrice
                );
            }

            foreach (var service in services)
            {
                dataGridViewServices.Rows.Add(
                    service.IdService,
                    service.Name,
                    service.ServiceFee,
                    service.Labour
                );
            }
        }

        private async void LoadItemData()
        {
            ItemPartDAO itemPartDAO = new ItemPartDAO();
            ItemServiceDAO itemServiceDAO = new ItemServiceDAO();

            itemParts = await itemPartDAO.GetByServiceTicketId(processingTicket.IdServiceTicket);
            itemServices = await itemServiceDAO.GetByServiceTicketId(processingTicket.IdServiceTicket);

            DisplayItemData();
        }

        private void DisplayItemData()
        {
            // Clear existing rows
            dataGridViewItemParts.Rows.Clear();
            dataGridViewItemServices.Rows.Clear();

            // Add data to the tables
            foreach (var itemPart in itemParts)
            {
                dataGridViewItemParts.Rows.Add(
                    itemPart.SerialNumber,
                    itemPart.Name,
                    itemPart.UnitPrice,
                    itemPart.Quantity,
                    itemPart.ItemPrice
                );
            }

            foreach (var itemService in itemServices)
            {
                dataGridViewItemServices.Rows.Add(
                    itemService.IdService,
                    itemService.Name,
                    itemService.ServiceFee,
                    itemService.Labour,
                    itemService.LabourAmount,
                    itemService.ItemPrice
                );
            }
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

        private async void btnAddPart_Click(object sender, EventArgs e)
        {
            // Check if a part is selected
            if (dataGridViewParts.SelectedRows.Count == 0)
            {
                MessageBox.Show(resourceManager.GetString("msgSelectPart"),
                    resourceManager.GetString("lblError"),
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            // Check if the quantity is provided
            if (!int.TryParse(textBoxQuantityPart.Text, out int quantity) || quantity <= 0)
            {
                MessageBox.Show(resourceManager.GetString("msgValidQuantity"),
                    resourceManager.GetString("lblError"),
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            // Get selected part
            var selectedPartRow = dataGridViewParts.SelectedRows[0];

            if (selectedPartRow.Cells[0].Value is int serialNumber &&
                selectedPartRow.Cells[1].Value is string name &&
                selectedPartRow.Cells[2].Value is decimal unitPrice)
            {
                // Create a new ItemPart object
                var newItemPart = new ItemPart
                {
                    SerialNumber = serialNumber,
                    IdServiceTicket = processingTicket.IdServiceTicket,
                    Name = name,
                    UnitPrice = unitPrice,
                    Quantity = quantity
                };

                // Use ItemPartDAO to add the new item part
                var itemPartDAO = new ItemPartDAO();
                var addedItemPart = await itemPartDAO.Insert(newItemPart);

                if (addedItemPart != -1)
                {
                    MessageBox.Show(resourceManager.GetString("msgSuccessfullyAdded"),
                        resourceManager.GetString("lblSuccess"),
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(resourceManager.GetString("msgFailedAdding"),
                        resourceManager.GetString("lblError"),
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show(resourceManager.GetString("msgErrorGettingPart"),
                    resourceManager.GetString("lblError"),
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            // Refresh
            LoadItemData();
        }

        private async void btnAddService_Click(object sender, EventArgs e)
        {
            // Check if a service is selected
            if (dataGridViewServices.SelectedRows.Count == 0)
            {
                MessageBox.Show(resourceManager.GetString("msgSelectService"),
                    resourceManager.GetString("lblError"),
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            // Check if the LabourAmount is provided
            if (!int.TryParse(textBoxQuantityService.Text, out int labourAmount) || labourAmount <= 0)
            {
                MessageBox.Show(resourceManager.GetString("msgValidLabourAmount"),
                    resourceManager.GetString("lblError"),
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            // Get selected service
            var selectedServiceIndex = dataGridViewServices.SelectedRows[0].Index;

            if (selectedServiceIndex != -1)
            {
                // Create a new ItemService object
                var newItemService = new ItemService
                {
                    IdService = services[selectedServiceIndex].IdService,
                    IdServiceTicket = processingTicket.IdServiceTicket,
                    Name = services[selectedServiceIndex].Name,
                    ServiceFee = services[selectedServiceIndex].ServiceFee,
                    Labour = services[selectedServiceIndex].Labour,
                    LabourAmount = labourAmount
                };

                // Use ItemServiceDAO to add the new item service
                var itemServiceDAO = new ItemServiceDAO();
                var addedItemService = await itemServiceDAO.Insert(newItemService);

                if (addedItemService != -1)
                {
                    MessageBox.Show(resourceManager.GetString("msgSuccessfullyAddedService"),
                        resourceManager.GetString("lblSuccess"),
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(resourceManager.GetString("msgFailedAddingService"),
                        resourceManager.GetString("lblError"),
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show(resourceManager.GetString("msgErrorGettingService"),
                    resourceManager.GetString("lblError"),
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            // Refresh items grid
            LoadItemData();
        }

        private async void btnShowInvoice_Click(object sender, EventArgs e)
        {
            // Check if a processing ticket is available
            if (processingTicket == null)
            {
                MessageBox.Show(resourceManager.GetString("msgNoTicket"),
                    resourceManager.GetString("lblError"),
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            // Initialize ServiceTikcetDAO
            ServiceTicketDAO serviceTicketDAO = new ServiceTicketDAO();
            
            // Update ticket status to "Finished"
            processingTicket.Status = "Finished";
            await serviceTicketDAO.Update(processingTicket);

            // Open the ShowInvoiceEmployeeForm with the processing ticket
            ShowInvoiceEmployeeForm showInvoiceForm = new ShowInvoiceEmployeeForm(processingTicket);
            showInvoiceForm.Show();

            // Close the current form
            this.Close();
        }

        private async void btnRemovePart_Click(object sender, EventArgs e)
        {
            // Check if a item part is selected
            if (dataGridViewItemParts.SelectedRows.Count == 0)
            {
                MessageBox.Show(resourceManager.GetString("msgSelectItemPart"),
                    resourceManager.GetString("lblError"),
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            // Get selected item part
            var selectedItemPart = dataGridViewItemParts.SelectedRows[0];

            if (selectedItemPart.Cells[0].Value is int serialNumber &&
                selectedItemPart.Cells[1].Value is string name &&
                selectedItemPart.Cells[2].Value is decimal unitPrice)
            {
                // Create a new ItemPart object
                var deletingItemPart = new ItemPart
                {
                    SerialNumber = serialNumber,
                    IdServiceTicket = processingTicket.IdServiceTicket,
                    Name = name,
                    UnitPrice = unitPrice
                };

                // Use ItemPartDAO to delete the new item part
                var itemPartDAO = new ItemPartDAO();
                var deletedItemPart = await itemPartDAO.Delete(deletingItemPart);

                if (deletedItemPart != -1)
                {
                    MessageBox.Show(resourceManager.GetString("msgSucessfullyDeletedItemPart"),
                        resourceManager.GetString("lblSuccess"),
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(resourceManager.GetString("msgFailedDeletingItemPart"),
                        resourceManager.GetString("lblError"),
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show(resourceManager.GetString("msgErrorGettingItemPart"),
                    resourceManager.GetString("lblError"),
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            // Refresh
            LoadItemData();
        }

        private async void btnRemoveService_Click(object sender, EventArgs e)
        {
            // Check if an item service is selected
            if (dataGridViewItemServices.SelectedRows.Count == 0)
            {
                MessageBox.Show(resourceManager.GetString("msgSelectItemService"),
                    resourceManager.GetString("lblError"),
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            // Get selected service
            var selectedServiceIndex = dataGridViewItemServices.SelectedRows[0].Index;

            if (selectedServiceIndex != -1)
            {
                // Create a new ItemService object
                var deletingItemService = new ItemService
                {
                    IdService = itemServices[selectedServiceIndex].IdService,
                    IdServiceTicket = processingTicket.IdServiceTicket,
                    Name = itemServices[selectedServiceIndex].Name,
                    ServiceFee = itemServices[selectedServiceIndex].ServiceFee,
                    Labour = itemServices[selectedServiceIndex].Labour
                };

                // Use ItemServiceDAO to add the new item service
                var itemServiceDAO = new ItemServiceDAO();
                var deletedItemService = await itemServiceDAO.Delete(deletingItemService);

                if (deletedItemService != -1)
                {
                    MessageBox.Show(resourceManager.GetString("msgSuccessfullyDeletedItemService"),
                        resourceManager.GetString("lblSuccess"),
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(resourceManager.GetString("msgFailedDeletingItemService"),
                        resourceManager.GetString("lblError"),
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show(resourceManager.GetString("msgErrorGettingItemService"),
                    resourceManager.GetString("lblError"),
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            // Refresh items grids
            LoadItemData();
        }

    }
}
