namespace TruckCentreWF.Forms
{
    partial class ShowInvoiceEmployeeForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShowInvoiceEmployeeForm));
            this.lblParts = new System.Windows.Forms.Label();
            this.lblServices = new System.Windows.Forms.Label();
            this.dataGridViewParts = new System.Windows.Forms.DataGridView();
            this.SerialNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PartName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnitPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemPartPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridServices = new System.Windows.Forms.DataGridView();
            this.IdService = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ServiceName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ServiceFee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Labour = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LabourAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemServicePrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblGrandTotal = new System.Windows.Forms.Label();
            this.lblExit = new System.Windows.Forms.Label();
            this.lblMinimise = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblInvoiceDetails = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewParts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridServices)).BeginInit();
            this.SuspendLayout();
            // 
            // lblParts
            // 
            resources.ApplyResources(this.lblParts, "lblParts");
            this.lblParts.Name = "lblParts";
            // 
            // lblServices
            // 
            resources.ApplyResources(this.lblServices, "lblServices");
            this.lblServices.Name = "lblServices";
            // 
            // dataGridViewParts
            // 
            resources.ApplyResources(this.dataGridViewParts, "dataGridViewParts");
            this.dataGridViewParts.AllowUserToAddRows = false;
            this.dataGridViewParts.AllowUserToDeleteRows = false;
            this.dataGridViewParts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridViewParts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SerialNumber,
            this.PartName,
            this.UnitPrice,
            this.Quantity,
            this.ItemPartPrice});
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
            // dataGridServices
            // 
            resources.ApplyResources(this.dataGridServices, "dataGridServices");
            this.dataGridServices.AllowUserToAddRows = false;
            this.dataGridServices.AllowUserToDeleteRows = false;
            this.dataGridServices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridServices.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdService,
            this.ServiceName,
            this.ServiceFee,
            this.Labour,
            this.LabourAmount,
            this.ItemServicePrice});
            this.dataGridServices.Name = "dataGridServices";
            this.dataGridServices.ReadOnly = true;
            this.dataGridServices.RowTemplate.Height = 24;
            this.dataGridServices.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            // 
            // IdService
            // 
            resources.ApplyResources(this.IdService, "IdService");
            this.IdService.Name = "IdService";
            this.IdService.ReadOnly = true;
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
            // lblGrandTotal
            // 
            resources.ApplyResources(this.lblGrandTotal, "lblGrandTotal");
            this.lblGrandTotal.Name = "lblGrandTotal";
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
            // lblTitle
            // 
            resources.ApplyResources(this.lblTitle, "lblTitle");
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Name = "lblTitle";
            // 
            // lblInvoiceDetails
            // 
            resources.ApplyResources(this.lblInvoiceDetails, "lblInvoiceDetails");
            this.lblInvoiceDetails.Name = "lblInvoiceDetails";
            // 
            // ShowInvoiceEmployeeForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblInvoiceDetails);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblMinimise);
            this.Controls.Add(this.lblExit);
            this.Controls.Add(this.lblGrandTotal);
            this.Controls.Add(this.dataGridServices);
            this.Controls.Add(this.dataGridViewParts);
            this.Controls.Add(this.lblServices);
            this.Controls.Add(this.lblParts);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ShowInvoiceEmployeeForm";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewParts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridServices)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblParts;
        private System.Windows.Forms.Label lblServices;
        private System.Windows.Forms.DataGridView dataGridViewParts;
        private System.Windows.Forms.DataGridView dataGridServices;
        private System.Windows.Forms.Label lblGrandTotal;
        private System.Windows.Forms.Label lblExit;
        private System.Windows.Forms.Label lblMinimise;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdService;
        private System.Windows.Forms.DataGridViewTextBoxColumn ServiceName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ServiceFee;
        private System.Windows.Forms.DataGridViewTextBoxColumn Labour;
        private System.Windows.Forms.DataGridViewTextBoxColumn LabourAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemServicePrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn SerialNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn PartName;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnitPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemPartPrice;
        private System.Windows.Forms.Label lblInvoiceDetails;
    }
}