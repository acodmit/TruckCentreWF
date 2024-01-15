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
            this.dataGridViewParts = new System.Windows.Forms.DataGridView();
            this.dataGridViewServices = new System.Windows.Forms.DataGridView();
            this.IdService = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.SerialNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PartName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnitPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewParts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewServices)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewParts
            // 
            this.dataGridViewParts.AllowUserToAddRows = false;
            this.dataGridViewParts.AllowUserToDeleteRows = false;
            this.dataGridViewParts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewParts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SerialNumber,
            this.PartName,
            this.UnitPrice});
            this.dataGridViewParts.Location = new System.Drawing.Point(50, 70);
            this.dataGridViewParts.Name = "dataGridViewParts";
            this.dataGridViewParts.ReadOnly = true;
            this.dataGridViewParts.RowHeadersWidth = 50;
            this.dataGridViewParts.RowTemplate.Height = 24;
            this.dataGridViewParts.Size = new System.Drawing.Size(450, 200);
            this.dataGridViewParts.TabIndex = 7;
            // 
            // dataGridViewServices
            // 
            this.dataGridViewServices.AllowUserToAddRows = false;
            this.dataGridViewServices.AllowUserToDeleteRows = false;
            this.dataGridViewServices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewServices.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdService,
            this.ServiceName,
            this.ServiceFee,
            this.Labour});
            this.dataGridViewServices.Location = new System.Drawing.Point(50, 330);
            this.dataGridViewServices.Name = "dataGridViewServices";
            this.dataGridViewServices.ReadOnly = true;
            this.dataGridViewServices.RowHeadersWidth = 50;
            this.dataGridViewServices.RowTemplate.Height = 24;
            this.dataGridViewServices.Size = new System.Drawing.Size(450, 200);
            this.dataGridViewServices.TabIndex = 6;
            // 
            // IdService
            // 
            this.IdService.MinimumWidth = 6;
            this.IdService.Name = "IdService";
            this.IdService.ReadOnly = true;
            this.IdService.Width = 125;
            // 
            // ServiceName
            // 
            this.ServiceName.MinimumWidth = 6;
            this.ServiceName.Name = "ServiceName";
            this.ServiceName.ReadOnly = true;
            this.ServiceName.Width = 125;
            // 
            // ServiceFee
            // 
            this.ServiceFee.MinimumWidth = 6;
            this.ServiceFee.Name = "ServiceFee";
            this.ServiceFee.ReadOnly = true;
            this.ServiceFee.Width = 125;
            // 
            // Labour
            // 
            this.Labour.MinimumWidth = 6;
            this.Labour.Name = "Labour";
            this.Labour.ReadOnly = true;
            this.Labour.Width = 125;
            // 
            // btnAddPart
            // 
            this.btnAddPart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(195)))), ((int)(((byte)(178)))));
            this.btnAddPart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddPart.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnAddPart.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnAddPart.Location = new System.Drawing.Point(550, 110);
            this.btnAddPart.Name = "btnAddPart";
            this.btnAddPart.Size = new System.Drawing.Size(140, 35);
            this.btnAddPart.TabIndex = 0;
            this.btnAddPart.Text = "Add Part";
            this.btnAddPart.UseVisualStyleBackColor = false;
            // 
            // btnAddService
            // 
            this.btnAddService.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(195)))), ((int)(((byte)(178)))));
            this.btnAddService.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddService.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnAddService.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnAddService.Location = new System.Drawing.Point(550, 370);
            this.btnAddService.Name = "btnAddService";
            this.btnAddService.Size = new System.Drawing.Size(140, 35);
            this.btnAddService.TabIndex = 1;
            this.btnAddService.Text = "Add Service";
            this.btnAddService.UseVisualStyleBackColor = false;
            // 
            // btnShowInvoice
            // 
            this.btnShowInvoice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(195)))), ((int)(((byte)(178)))));
            this.btnShowInvoice.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnShowInvoice.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnShowInvoice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnShowInvoice.Location = new System.Drawing.Point(550, 490);
            this.btnShowInvoice.Name = "btnShowInvoice";
            this.btnShowInvoice.Size = new System.Drawing.Size(140, 35);
            this.btnShowInvoice.TabIndex = 2;
            this.btnShowInvoice.Text = "Show Invoice";
            this.btnShowInvoice.UseVisualStyleBackColor = false;
            // 
            // labelPart
            // 
            this.labelPart.AutoSize = true;
            this.labelPart.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPart.Location = new System.Drawing.Point(50, 40);
            this.labelPart.Name = "labelPart";
            this.labelPart.Size = new System.Drawing.Size(160, 23);
            this.labelPart.TabIndex = 0;
            this.labelPart.Text = "Choose used parts: ";
            // 
            // labelService
            // 
            this.labelService.AutoSize = true;
            this.labelService.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelService.Location = new System.Drawing.Point(50, 300);
            this.labelService.Name = "labelService";
            this.labelService.Size = new System.Drawing.Size(199, 23);
            this.labelService.TabIndex = 1;
            this.labelService.Text = "Choose provided service:";
            // 
            // labelQuantityPart
            // 
            this.labelQuantityPart.AutoSize = true;
            this.labelQuantityPart.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelQuantityPart.Location = new System.Drawing.Point(550, 40);
            this.labelQuantityPart.Name = "labelQuantityPart";
            this.labelQuantityPart.Size = new System.Drawing.Size(139, 23);
            this.labelQuantityPart.TabIndex = 2;
            this.labelQuantityPart.Text = "Number of units:";
            // 
            // labelQuantityService
            // 
            this.labelQuantityService.AutoSize = true;
            this.labelQuantityService.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelQuantityService.Location = new System.Drawing.Point(550, 300);
            this.labelQuantityService.Name = "labelQuantityService";
            this.labelQuantityService.Size = new System.Drawing.Size(145, 23);
            this.labelQuantityService.TabIndex = 3;
            this.labelQuantityService.Text = "Number of hours:";
            // 
            // textBoxQuantityPart
            // 
            this.textBoxQuantityPart.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxQuantityPart.Location = new System.Drawing.Point(550, 70);
            this.textBoxQuantityPart.Name = "textBoxQuantityPart";
            this.textBoxQuantityPart.Size = new System.Drawing.Size(140, 30);
            this.textBoxQuantityPart.TabIndex = 4;
            // 
            // textBoxQuantityService
            // 
            this.textBoxQuantityService.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxQuantityService.Location = new System.Drawing.Point(550, 330);
            this.textBoxQuantityService.Name = "textBoxQuantityService";
            this.textBoxQuantityService.Size = new System.Drawing.Size(140, 30);
            this.textBoxQuantityService.TabIndex = 5;
            // 
            // lblExit
            // 
            this.lblExit.AutoSize = true;
            this.lblExit.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExit.Location = new System.Drawing.Point(707, 5);
            this.lblExit.Name = "lblExit";
            this.lblExit.Size = new System.Drawing.Size(20, 23);
            this.lblExit.TabIndex = 8;
            this.lblExit.Text = "X";
            this.lblExit.Click += new System.EventHandler(this.lblExit_Click);
            // 
            // lblMinimise
            // 
            this.lblMinimise.AutoSize = true;
            this.lblMinimise.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMinimise.Location = new System.Drawing.Point(684, 5);
            this.lblMinimise.Name = "lblMinimise";
            this.lblMinimise.Size = new System.Drawing.Size(17, 23);
            this.lblMinimise.TabIndex = 9;
            this.lblMinimise.Text = "_";
            this.lblMinimise.Click += new System.EventHandler(this.lblMinimise_Click);
            // 
            // SerialNumber
            // 
            this.SerialNumber.HeaderText = "SerialNumber";
            this.SerialNumber.MinimumWidth = 6;
            this.SerialNumber.Name = "SerialNumber";
            this.SerialNumber.ReadOnly = true;
            this.SerialNumber.Width = 125;
            // 
            // PartName
            // 
            this.PartName.HeaderText = "PartName";
            this.PartName.MinimumWidth = 6;
            this.PartName.Name = "PartName";
            this.PartName.ReadOnly = true;
            this.PartName.Width = 180;
            // 
            // UnitPrice
            // 
            this.UnitPrice.HeaderText = "UnitPrice";
            this.UnitPrice.MinimumWidth = 6;
            this.UnitPrice.Name = "UnitPrice";
            this.UnitPrice.ReadOnly = true;
            // 
            // GenerateInvoiceEmployeeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(730, 590);
            this.Controls.Add(this.lblMinimise);
            this.Controls.Add(this.lblExit);
            this.Controls.Add(this.labelPart);
            this.Controls.Add(this.labelService);
            this.Controls.Add(this.labelQuantityPart);
            this.Controls.Add(this.labelQuantityService);
            this.Controls.Add(this.textBoxQuantityPart);
            this.Controls.Add(this.textBoxQuantityService);
            this.Controls.Add(this.btnShowInvoice);
            this.Controls.Add(this.btnAddService);
            this.Controls.Add(this.btnAddPart);
            this.Controls.Add(this.dataGridViewServices);
            this.Controls.Add(this.dataGridViewParts);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "GenerateInvoiceEmployeeForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewParts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewServices)).EndInit();
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

        // dataGridViewServices
        private System.Windows.Forms.DataGridViewTextBoxColumn IdService;
        private System.Windows.Forms.DataGridViewTextBoxColumn ServiceName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ServiceFee;
        private System.Windows.Forms.DataGridViewTextBoxColumn Labour;
        private System.Windows.Forms.DataGridViewTextBoxColumn SerialNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn PartName;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnitPrice;
    }
}
