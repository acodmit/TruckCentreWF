namespace TruckCentreWF.Forms
{
    partial class AddVehicleEmployeeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddVehicleEmployeeForm));
            this.btnAdd = new System.Windows.Forms.Button();
            this.txbMileage = new System.Windows.Forms.TextBox();
            this.lblMileage = new System.Windows.Forms.Label();
            this.txbDetails = new System.Windows.Forms.TextBox();
            this.lblDetails = new System.Windows.Forms.Label();
            this.dtpLastService = new System.Windows.Forms.DateTimePicker();
            this.lblLastService = new System.Windows.Forms.Label();
            this.lblExit = new System.Windows.Forms.Label();
            this.lblMinimise = new System.Windows.Forms.Label();
            this.txbIdVehicle = new System.Windows.Forms.TextBox();
            this.lblIdVehicle = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnAdd
            // 
            resources.ApplyResources(this.btnAdd, "btnAdd");
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(195)))), ((int)(((byte)(178)))));
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txbMileage
            // 
            resources.ApplyResources(this.txbMileage, "txbMileage");
            this.txbMileage.Name = "txbMileage";
            // 
            // lblMileage
            // 
            resources.ApplyResources(this.lblMileage, "lblMileage");
            this.lblMileage.Name = "lblMileage";
            // 
            // txbDetails
            // 
            resources.ApplyResources(this.txbDetails, "txbDetails");
            this.txbDetails.Name = "txbDetails";
            // 
            // lblDetails
            // 
            resources.ApplyResources(this.lblDetails, "lblDetails");
            this.lblDetails.Name = "lblDetails";
            // 
            // dtpLastService
            // 
            resources.ApplyResources(this.dtpLastService, "dtpLastService");
            this.dtpLastService.MaxDate = new System.DateTime(2100, 12, 31, 0, 0, 0, 0);
            this.dtpLastService.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.dtpLastService.Name = "dtpLastService";
            // 
            // lblLastService
            // 
            resources.ApplyResources(this.lblLastService, "lblLastService");
            this.lblLastService.Name = "lblLastService";
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
            // txbIdVehicle
            // 
            resources.ApplyResources(this.txbIdVehicle, "txbIdVehicle");
            this.txbIdVehicle.Name = "txbIdVehicle";
            // 
            // lblIdVehicle
            // 
            resources.ApplyResources(this.lblIdVehicle, "lblIdVehicle");
            this.lblIdVehicle.Name = "lblIdVehicle";
            // 
            // AddVehicleEmployeeForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txbIdVehicle);
            this.Controls.Add(this.lblIdVehicle);
            this.Controls.Add(this.lblExit);
            this.Controls.Add(this.lblMinimise);
            this.Controls.Add(this.lblLastService);
            this.Controls.Add(this.dtpLastService);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txbMileage);
            this.Controls.Add(this.lblMileage);
            this.Controls.Add(this.txbDetails);
            this.Controls.Add(this.lblDetails);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AddVehicleEmployeeForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox txbMileage;
        private System.Windows.Forms.Label lblMileage;
        private System.Windows.Forms.TextBox txbDetails;
        private System.Windows.Forms.Label lblDetails;
        private System.Windows.Forms.DateTimePicker dtpLastService;
        private System.Windows.Forms.Label lblLastService;
        private System.Windows.Forms.Label lblExit;
        private System.Windows.Forms.Label lblMinimise;
        private System.Windows.Forms.TextBox txbIdVehicle;
        private System.Windows.Forms.Label lblIdVehicle;
    }
}