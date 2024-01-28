using TruckCentreWF.Forms.Common;

namespace TruckCentreWF.Forms
{
    partial class GenerateInvoiceEmployeeForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GenerateInvoiceEmployeeForm));
            this.dataGridViewParts = new System.Windows.Forms.DataGridView();
            this.SerialNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PartName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnitPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewServices = new System.Windows.Forms.DataGridView();
            this.ServiceName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ServiceFee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Labour = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAddPart = new System.Windows.Forms.Button();
            this.btnAddService = new System.Windows.Forms.Button();
            this.btnShowInvoice = new System.Windows.Forms.Button();
            this.labelPart = new System.Windows.Forms.Label();
            this.labelService = new System.Windows.Forms.Label();
            this.labelQuantityPart = new System.Windows.Forms.Label();
            this.labelQuantityService = new System.Windows.Forms.Label();
            this.textBoxQuantityPart = new System.Windows.Forms.TextBox();
            this.textBoxQuantityService = new System.Windows.Forms.TextBox();
            this.lblExit = new System.Windows.Forms.Label();
            this.lblMinimise = new System.Windows.Forms.Label();
            this.btnRemovePart = new System.Windows.Forms.Button();
            this.dataGridViewItemServices = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LabourAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemServicePrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewItemParts = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemPartPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblSelectedParts = new System.Windows.Forms.Label();
            this.lblSelectedServices = new System.Windows.Forms.Label();
            this.panel1 = new TruckCentreWF.Forms.Common.DraggablePanel();
            this.btn = new System.Windows.Forms.Button();
            this.panel2 = new TruckCentreWF.Forms.Common.DraggablePanel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewParts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewServices)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewItemServices)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewItemParts)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewParts
            // 
            this.dataGridViewParts.AllowUserToAddRows = false;
            this.dataGridViewParts.AllowUserToDeleteRows = false;
            resources.ApplyResources(this.dataGridViewParts, "dataGridViewParts");
            this.dataGridViewParts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridViewParts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SerialNumber,
            this.PartName,
            this.UnitPrice});
            this.dataGridViewParts.Name = "dataGridViewParts";
            this.dataGridViewParts.ReadOnly = true;
            this.dataGridViewParts.RowTemplate.Height = 24;
            this.dataGridViewParts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            // 
            // SerialNumber
            // 
            resources.ApplyResources(this.SerialNumber, "SerialNumber");
            this.SerialNumber.Name = "SerialNumber";
            this.SerialNumber.ReadOnly = true;
            // 
            // PartName
            // 
            resources.ApplyResources(this.PartName, "PartName");
            this.PartName.Name = "PartName";
            this.PartName.ReadOnly = true;
            // 
            // UnitPrice
            // 
            resources.ApplyResources(this.UnitPrice, "UnitPrice");
            this.UnitPrice.Name = "UnitPrice";
            this.UnitPrice.ReadOnly = true;
            // 
            // dataGridViewServices
            // 
            this.dataGridViewServices.AllowUserToAddRows = false;
            this.dataGridViewServices.AllowUserToDeleteRows = false;
            resources.ApplyResources(this.dataGridViewServices, "dataGridViewServices");
            this.dataGridViewServices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridViewServices.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ServiceName,
            this.ServiceFee,
            this.Labour});
            this.dataGridViewServices.Name = "dataGridViewServices";
            this.dataGridViewServices.ReadOnly = true;
            this.dataGridViewServices.RowTemplate.Height = 24;
            this.dataGridViewServices.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            // 
            // ServiceName
            // 
            resources.ApplyResources(this.ServiceName, "ServiceName");
            this.ServiceName.Name = "ServiceName";
            this.ServiceName.ReadOnly = true;
            // 
            // ServiceFee
            // 
            resources.ApplyResources(this.ServiceFee, "ServiceFee");
            this.ServiceFee.Name = "ServiceFee";
            this.ServiceFee.ReadOnly = true;
            // 
            // Labour
            // 
            resources.ApplyResources(this.Labour, "Labour");
            this.Labour.Name = "Labour";
            this.Labour.ReadOnly = true;
            // 
            // btnAddPart
            // 
            this.btnAddPart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(195)))), ((int)(((byte)(178)))));
            this.btnAddPart.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.btnAddPart, "btnAddPart");
            this.btnAddPart.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnAddPart.Name = "btnAddPart";
            this.btnAddPart.UseVisualStyleBackColor = false;
            this.btnAddPart.Click += new System.EventHandler(this.btnAddPart_Click);
            // 
            // btnAddService
            // 
            this.btnAddService.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(195)))), ((int)(((byte)(178)))));
            this.btnAddService.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.btnAddService, "btnAddService");
            this.btnAddService.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnAddService.Name = "btnAddService";
            this.btnAddService.UseVisualStyleBackColor = false;
            this.btnAddService.Click += new System.EventHandler(this.btnAddService_Click);
            // 
            // btnShowInvoice
            // 
            this.btnShowInvoice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(195)))), ((int)(((byte)(178)))));
            this.btnShowInvoice.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.btnShowInvoice, "btnShowInvoice");
            this.btnShowInvoice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnShowInvoice.Name = "btnShowInvoice";
            this.btnShowInvoice.UseVisualStyleBackColor = false;
            this.btnShowInvoice.Click += new System.EventHandler(this.btnShowInvoice_Click);
            // 
            // labelPart
            // 
            resources.ApplyResources(this.labelPart, "labelPart");
            this.labelPart.Name = "labelPart";
            // 
            // labelService
            // 
            resources.ApplyResources(this.labelService, "labelService");
            this.labelService.Name = "labelService";
            // 
            // labelQuantityPart
            // 
            resources.ApplyResources(this.labelQuantityPart, "labelQuantityPart");
            this.labelQuantityPart.Name = "labelQuantityPart";
            // 
            // labelQuantityService
            // 
            resources.ApplyResources(this.labelQuantityService, "labelQuantityService");
            this.labelQuantityService.Name = "labelQuantityService";
            // 
            // textBoxQuantityPart
            // 
            resources.ApplyResources(this.textBoxQuantityPart, "textBoxQuantityPart");
            this.textBoxQuantityPart.Name = "textBoxQuantityPart";
            // 
            // textBoxQuantityService
            // 
            resources.ApplyResources(this.textBoxQuantityService, "textBoxQuantityService");
            this.textBoxQuantityService.Name = "textBoxQuantityService";
            // 
            // lblExit
            // 
            resources.ApplyResources(this.lblExit, "lblExit");
            this.lblExit.Name = "lblExit";
            this.lblExit.Click += new System.EventHandler(this.lblExit_Click);
            // 
            // lblMinimise
            // 
            resources.ApplyResources(this.lblMinimise, "lblMinimise");
            this.lblMinimise.Name = "lblMinimise";
            this.lblMinimise.Click += new System.EventHandler(this.lblMinimise_Click);
            // 
            // btnRemovePart
            // 
            this.btnRemovePart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(195)))), ((int)(((byte)(178)))));
            this.btnRemovePart.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.btnRemovePart, "btnRemovePart");
            this.btnRemovePart.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnRemovePart.Name = "btnRemovePart";
            this.btnRemovePart.UseVisualStyleBackColor = false;
            this.btnRemovePart.Click += new System.EventHandler(this.btnRemovePart_Click);
            // 
            // dataGridViewItemServices
            // 
            this.dataGridViewItemServices.AllowUserToAddRows = false;
            this.dataGridViewItemServices.AllowUserToDeleteRows = false;
            resources.ApplyResources(this.dataGridViewItemServices, "dataGridViewItemServices");
            this.dataGridViewItemServices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridViewItemServices.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.LabourAmount,
            this.ItemServicePrice});
            this.dataGridViewItemServices.Name = "dataGridViewItemServices";
            this.dataGridViewItemServices.ReadOnly = true;
            this.dataGridViewItemServices.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridViewItemServices.RowTemplate.Height = 24;
            this.dataGridViewItemServices.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            // 
            // dataGridViewTextBoxColumn2
            // 
            resources.ApplyResources(this.dataGridViewTextBoxColumn2, "dataGridViewTextBoxColumn2");
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            resources.ApplyResources(this.dataGridViewTextBoxColumn3, "dataGridViewTextBoxColumn3");
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            resources.ApplyResources(this.dataGridViewTextBoxColumn4, "dataGridViewTextBoxColumn4");
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // LabourAmount
            // 
            resources.ApplyResources(this.LabourAmount, "LabourAmount");
            this.LabourAmount.Name = "LabourAmount";
            this.LabourAmount.ReadOnly = true;
            // 
            // ItemServicePrice
            // 
            resources.ApplyResources(this.ItemServicePrice, "ItemServicePrice");
            this.ItemServicePrice.Name = "ItemServicePrice";
            this.ItemServicePrice.ReadOnly = true;
            // 
            // dataGridViewItemParts
            // 
            this.dataGridViewItemParts.AllowUserToAddRows = false;
            this.dataGridViewItemParts.AllowUserToDeleteRows = false;
            resources.ApplyResources(this.dataGridViewItemParts, "dataGridViewItemParts");
            this.dataGridViewItemParts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridViewItemParts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.Quantity,
            this.ItemPartPrice});
            this.dataGridViewItemParts.Name = "dataGridViewItemParts";
            this.dataGridViewItemParts.ReadOnly = true;
            this.dataGridViewItemParts.RowTemplate.Height = 24;
            this.dataGridViewItemParts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            // 
            // dataGridViewTextBoxColumn5
            // 
            resources.ApplyResources(this.dataGridViewTextBoxColumn5, "dataGridViewTextBoxColumn5");
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            resources.ApplyResources(this.dataGridViewTextBoxColumn6, "dataGridViewTextBoxColumn6");
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // dataGridViewTextBoxColumn7
            // 
            resources.ApplyResources(this.dataGridViewTextBoxColumn7, "dataGridViewTextBoxColumn7");
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            // 
            // Quantity
            // 
            resources.ApplyResources(this.Quantity, "Quantity");
            this.Quantity.Name = "Quantity";
            this.Quantity.ReadOnly = true;
            // 
            // ItemPartPrice
            // 
            resources.ApplyResources(this.ItemPartPrice, "ItemPartPrice");
            this.ItemPartPrice.Name = "ItemPartPrice";
            this.ItemPartPrice.ReadOnly = true;
            // 
            // lblSelectedParts
            // 
            resources.ApplyResources(this.lblSelectedParts, "lblSelectedParts");
            this.lblSelectedParts.Name = "lblSelectedParts";
            // 
            // lblSelectedServices
            // 
            resources.ApplyResources(this.lblSelectedServices, "lblSelectedServices");
            this.lblSelectedServices.Name = "lblSelectedServices";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btn);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // btn
            // 
            this.btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(195)))), ((int)(((byte)(178)))));
            this.btn.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.btn, "btn");
            this.btn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn.Name = "btn";
            this.btn.UseVisualStyleBackColor = false;
            this.btn.Click += new System.EventHandler(this.btnRemoveService_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.textBoxQuantityPart);
            this.panel2.Controls.Add(this.btnAddPart);
            this.panel2.Controls.Add(this.labelQuantityPart);
            this.panel2.Controls.Add(this.textBoxQuantityService);
            this.panel2.Controls.Add(this.btnAddService);
            this.panel2.Controls.Add(this.labelQuantityService);
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Name = "panel2";
            // 
            // GenerateInvoiceEmployeeForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblSelectedServices);
            this.Controls.Add(this.lblSelectedParts);
            this.Controls.Add(this.dataGridViewItemParts);
            this.Controls.Add(this.btnRemovePart);
            this.Controls.Add(this.lblMinimise);
            this.Controls.Add(this.lblExit);
            this.Controls.Add(this.labelPart);
            this.Controls.Add(this.labelService);
            this.Controls.Add(this.btnShowInvoice);
            this.Controls.Add(this.dataGridViewServices);
            this.Controls.Add(this.dataGridViewParts);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.dataGridViewItemServices);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "GenerateInvoiceEmployeeForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewParts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewServices)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewItemServices)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewItemParts)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewParts;
        private System.Windows.Forms.DataGridView dataGridViewServices;
        private System.Windows.Forms.Button btnAddPart;
        private System.Windows.Forms.Button btnAddService;
        private System.Windows.Forms.Button btnShowInvoice;
        private System.Windows.Forms.Label labelPart;
        private System.Windows.Forms.Label labelService;
        private System.Windows.Forms.Label labelQuantityPart;
        private System.Windows.Forms.Label labelQuantityService;
        private System.Windows.Forms.TextBox textBoxQuantityPart;
        private System.Windows.Forms.TextBox textBoxQuantityService;
        private System.Windows.Forms.Label lblExit;
        private System.Windows.Forms.Label lblMinimise;
        private System.Windows.Forms.Button btnRemovePart;
        private System.Windows.Forms.DataGridView dataGridViewItemServices;
        private System.Windows.Forms.DataGridView dataGridViewItemParts;
        private System.Windows.Forms.Label lblSelectedParts;
        private System.Windows.Forms.Label lblSelectedServices;
        private DraggablePanel panel1;
        private DraggablePanel panel2;
        private System.Windows.Forms.Button btn;
        private System.Windows.Forms.DataGridViewTextBoxColumn SerialNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn PartName;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnitPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn ServiceName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ServiceFee;
        private System.Windows.Forms.DataGridViewTextBoxColumn Labour;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn LabourAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemServicePrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemPartPrice;
    }
}
