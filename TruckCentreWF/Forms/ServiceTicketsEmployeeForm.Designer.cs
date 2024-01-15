namespace TruckCentreWF.Forms
{
    partial class ServiceTicketsEmployeeForm
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnGenerateInvoice = new System.Windows.Forms.Button();
            this.IdServiceTicket = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdEmployee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EntryDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Details = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeight = 29;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdServiceTicket,
            this.IdEmployee,
            this.EntryDate,
            this.Details,
            this.Status});
            this.dataGridView1.Location = new System.Drawing.Point(80, 60);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 50;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(830, 384);
            this.dataGridView1.TabIndex = 4;
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(195)))), ((int)(((byte)(178)))));
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnAdd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnAdd.Location = new System.Drawing.Point(540, 470);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(170, 35);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(195)))), ((int)(((byte)(178)))));
            this.btnUpdate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUpdate.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnUpdate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnUpdate.Location = new System.Drawing.Point(741, 470);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(170, 35);
            this.btnUpdate.TabIndex = 2;
            this.btnUpdate.Text = "Delete";
            this.btnUpdate.UseVisualStyleBackColor = false;
            // 
            // btnGenerateInvoice
            // 
            this.btnGenerateInvoice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(195)))), ((int)(((byte)(178)))));
            this.btnGenerateInvoice.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGenerateInvoice.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnGenerateInvoice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnGenerateInvoice.Location = new System.Drawing.Point(669, 523);
            this.btnGenerateInvoice.Name = "btnGenerateInvoice";
            this.btnGenerateInvoice.Size = new System.Drawing.Size(240, 35);
            this.btnGenerateInvoice.TabIndex = 0;
            this.btnGenerateInvoice.Text = "Generate Invoice";
            this.btnGenerateInvoice.UseVisualStyleBackColor = false;
            this.btnGenerateInvoice.Click += new System.EventHandler(this.btnGenerateInvoice_Click);
            // 
            // IdServiceTicket
            // 
            this.IdServiceTicket.HeaderText = "IdServiceTicket";
            this.IdServiceTicket.MinimumWidth = 6;
            this.IdServiceTicket.Name = "IdServiceTicket";
            this.IdServiceTicket.ReadOnly = true;
            // 
            // IdEmployee
            // 
            this.IdEmployee.HeaderText = "CreatedByEmployeeID";
            this.IdEmployee.MinimumWidth = 6;
            this.IdEmployee.Name = "IdEmployee";
            this.IdEmployee.ReadOnly = true;
            // 
            // EntryDate
            // 
            this.EntryDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.EntryDate.HeaderText = "EntryDate";
            this.EntryDate.MinimumWidth = 6;
            this.EntryDate.Name = "EntryDate";
            this.EntryDate.ReadOnly = true;
            // 
            // Details
            // 
            this.Details.HeaderText = "Details";
            this.Details.MinimumWidth = 6;
            this.Details.Name = "Details";
            this.Details.ReadOnly = true;
            // 
            // Status
            // 
            this.Status.HeaderText = "Status";
            this.Status.MinimumWidth = 6;
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            // 
            // ServiceTicketsEmployeeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(990, 580);
            this.Controls.Add(this.btnGenerateInvoice);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ServiceTicketsEmployeeForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnGenerateInvoice;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdServiceTicket;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdEmployee;
        private System.Windows.Forms.DataGridViewTextBoxColumn EntryDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Details;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
    }
}
