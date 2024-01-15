namespace TruckCentreWF.Forms
{
    partial class AddServiceTicketEmployeeForm
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
            this.lblMinimise = new System.Windows.Forms.Label();
            this.lblExit = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblInstruction = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.textBoxDetails = new System.Windows.Forms.TextBox();
            this.dataGridViewVehicles = new System.Windows.Forms.DataGridView();
            this.IdVehicle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Mileage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VehicleDetails = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastService = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewClients = new System.Windows.Forms.DataGridView();
            this.IdClient = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewVehicles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewClients)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMinimise
            // 
            this.lblMinimise.AutoSize = true;
            this.lblMinimise.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMinimise.Location = new System.Drawing.Point(645, 9);
            this.lblMinimise.Name = "lblMinimise";
            this.lblMinimise.Size = new System.Drawing.Size(17, 23);
            this.lblMinimise.TabIndex = 7;
            this.lblMinimise.Text = "_";
            this.lblMinimise.Click += new System.EventHandler(this.lblMinimise_Click);
            // 
            // lblExit
            // 
            this.lblExit.AutoSize = true;
            this.lblExit.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExit.Location = new System.Drawing.Point(668, 9);
            this.lblExit.Name = "lblExit";
            this.lblExit.Size = new System.Drawing.Size(20, 23);
            this.lblExit.TabIndex = 6;
            this.lblExit.Text = "X";
            this.lblExit.Click += new System.EventHandler(this.lblExit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(96, 525);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 23);
            this.label1.TabIndex = 5;
            this.label1.Text = "Insert ticket details:";
            // 
            // lblInstruction
            // 
            this.lblInstruction.AutoSize = true;
            this.lblInstruction.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInstruction.Location = new System.Drawing.Point(96, 49);
            this.lblInstruction.Name = "lblInstruction";
            this.lblInstruction.Size = new System.Drawing.Size(409, 23);
            this.lblInstruction.TabIndex = 4;
            this.lblInstruction.Text = "To create a new ticket, select both client and vehicle:";
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(195)))), ((int)(((byte)(178)))));
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnAdd.Location = new System.Drawing.Point(460, 686);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(140, 35);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // textBoxDetails
            // 
            this.textBoxDetails.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxDetails.Location = new System.Drawing.Point(100, 560);
            this.textBoxDetails.MaxLength = 100;
            this.textBoxDetails.Multiline = true;
            this.textBoxDetails.Name = "textBoxDetails";
            this.textBoxDetails.Size = new System.Drawing.Size(500, 100);
            this.textBoxDetails.TabIndex = 1;
            // 
            // dataGridViewVehicles
            // 
            this.dataGridViewVehicles.AllowUserToAddRows = false;
            this.dataGridViewVehicles.AllowUserToDeleteRows = false;
            this.dataGridViewVehicles.ColumnHeadersHeight = 29;
            this.dataGridViewVehicles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdVehicle,
            this.Mileage,
            this.VehicleDetails,
            this.LastService});
            this.dataGridViewVehicles.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(227)))), ((int)(((byte)(222)))));
            this.dataGridViewVehicles.Location = new System.Drawing.Point(100, 303);
            this.dataGridViewVehicles.Name = "dataGridViewVehicles";
            this.dataGridViewVehicles.ReadOnly = true;
            this.dataGridViewVehicles.RowHeadersWidth = 30;
            this.dataGridViewVehicles.RowTemplate.Height = 24;
            this.dataGridViewVehicles.Size = new System.Drawing.Size(500, 200);
            this.dataGridViewVehicles.TabIndex = 2;
            // 
            // IdVehicle
            // 
            this.IdVehicle.HeaderText = "IdVehicle";
            this.IdVehicle.MinimumWidth = 6;
            this.IdVehicle.Name = "IdVehicle";
            this.IdVehicle.ReadOnly = true;
            this.IdVehicle.Width = 110;
            // 
            // Mileage
            // 
            this.Mileage.HeaderText = "Mileage";
            this.Mileage.MinimumWidth = 6;
            this.Mileage.Name = "Mileage";
            this.Mileage.ReadOnly = true;
            this.Mileage.Width = 110;
            // 
            // VehicleDetails
            // 
            this.VehicleDetails.HeaderText = "VehicleDetails";
            this.VehicleDetails.MinimumWidth = 6;
            this.VehicleDetails.Name = "VehicleDetails";
            this.VehicleDetails.ReadOnly = true;
            this.VehicleDetails.Width = 220;
            // 
            // LastService
            // 
            this.LastService.HeaderText = "LastService";
            this.LastService.MinimumWidth = 6;
            this.LastService.Name = "LastService";
            this.LastService.ReadOnly = true;
            this.LastService.Width = 150;
            // 
            // dataGridViewClients
            // 
            this.dataGridViewClients.AllowUserToAddRows = false;
            this.dataGridViewClients.AllowUserToDeleteRows = false;
            this.dataGridViewClients.ColumnHeadersHeight = 29;
            this.dataGridViewClients.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdClient,
            this.Email,
            this.Address});
            this.dataGridViewClients.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(227)))), ((int)(((byte)(222)))));
            this.dataGridViewClients.Location = new System.Drawing.Point(100, 85);
            this.dataGridViewClients.Name = "dataGridViewClients";
            this.dataGridViewClients.ReadOnly = true;
            this.dataGridViewClients.RowHeadersWidth = 30;
            this.dataGridViewClients.RowTemplate.Height = 24;
            this.dataGridViewClients.Size = new System.Drawing.Size(500, 200);
            this.dataGridViewClients.TabIndex = 3;
            // 
            // IdClient
            // 
            this.IdClient.HeaderText = "IdClient";
            this.IdClient.MinimumWidth = 6;
            this.IdClient.Name = "IdClient";
            this.IdClient.ReadOnly = true;
            this.IdClient.Width = 90;
            // 
            // Email
            // 
            this.Email.HeaderText = "Email";
            this.Email.MinimumWidth = 6;
            this.Email.Name = "Email";
            this.Email.ReadOnly = true;
            this.Email.Width = 200;
            // 
            // Address
            // 
            this.Address.HeaderText = "Address";
            this.Address.MinimumWidth = 6;
            this.Address.Name = "Address";
            this.Address.ReadOnly = true;
            this.Address.Width = 200;
            // 
            // AddServiceTicketEmployeeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 750);
            this.Controls.Add(this.lblMinimise);
            this.Controls.Add(this.lblExit);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblInstruction);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.textBoxDetails);
            this.Controls.Add(this.dataGridViewVehicles);
            this.Controls.Add(this.dataGridViewClients);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AddServiceTicketEmployeeForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewVehicles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewClients)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewClients;
        private System.Windows.Forms.DataGridView dataGridViewVehicles;
        private System.Windows.Forms.TextBox textBoxDetails;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label lblInstruction;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblExit;
        private System.Windows.Forms.Label lblMinimise;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdClient;
        private System.Windows.Forms.DataGridViewTextBoxColumn Email;
        private System.Windows.Forms.DataGridViewTextBoxColumn Address;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdVehicle;
        private System.Windows.Forms.DataGridViewTextBoxColumn Mileage;
        private System.Windows.Forms.DataGridViewTextBoxColumn VehicleDetails;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastService;
    }
}
