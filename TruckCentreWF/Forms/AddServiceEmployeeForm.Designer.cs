namespace TruckCentreWF.Forms
{
    partial class AddServiceEmployeeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddServiceEmployeeForm));
            this.lblServiceName = new System.Windows.Forms.Label();
            this.txbServiceName = new System.Windows.Forms.TextBox();
            this.lblServiceFee = new System.Windows.Forms.Label();
            this.txbServiceFee = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lblExit = new System.Windows.Forms.Label();
            this.lblMinimise = new System.Windows.Forms.Label();
            this.txbLabour = new System.Windows.Forms.TextBox();
            this.lblLabour = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblServiceName
            // 
            resources.ApplyResources(this.lblServiceName, "lblServiceName");
            this.lblServiceName.Name = "lblServiceName";
            // 
            // txbServiceName
            // 
            resources.ApplyResources(this.txbServiceName, "txbServiceName");
            this.txbServiceName.Name = "txbServiceName";
            // 
            // lblServiceFee
            // 
            resources.ApplyResources(this.lblServiceFee, "lblServiceFee");
            this.lblServiceFee.Name = "lblServiceFee";
            // 
            // txbServiceFee
            // 
            resources.ApplyResources(this.txbServiceFee, "txbServiceFee");
            this.txbServiceFee.Name = "txbServiceFee";
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(195)))), ((int)(((byte)(178)))));
            resources.ApplyResources(this.btnAdd, "btnAdd");
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
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
            // txbLabour
            // 
            resources.ApplyResources(this.txbLabour, "txbLabour");
            this.txbLabour.Name = "txbLabour";
            // 
            // lblLabour
            // 
            resources.ApplyResources(this.lblLabour, "lblLabour");
            this.lblLabour.Name = "lblLabour";
            // 
            // AddServiceEmployeeForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblLabour);
            this.Controls.Add(this.txbLabour);
            this.Controls.Add(this.lblExit);
            this.Controls.Add(this.lblMinimise);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txbServiceFee);
            this.Controls.Add(this.lblServiceFee);
            this.Controls.Add(this.txbServiceName);
            this.Controls.Add(this.lblServiceName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AddServiceEmployeeForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblServiceName;
        private System.Windows.Forms.TextBox txbServiceName;
        private System.Windows.Forms.Label lblServiceFee;
        private System.Windows.Forms.TextBox txbServiceFee;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label lblExit;
        private System.Windows.Forms.Label lblMinimise;
        private System.Windows.Forms.TextBox txbLabour;
        private System.Windows.Forms.Label lblLabour;
    }
}