namespace TruckCentreWF.Forms
{
    partial class AddPartEmployeeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddPartEmployeeForm));
            this.labelPartName = new System.Windows.Forms.Label();
            this.txbPartName = new System.Windows.Forms.TextBox();
            this.labelUnitPrice = new System.Windows.Forms.Label();
            this.txbUnitPrice = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lblExit = new System.Windows.Forms.Label();
            this.lblMinimise = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelPartName
            // 
            resources.ApplyResources(this.labelPartName, "labelPartName");
            this.labelPartName.Name = "labelPartName";
            // 
            // txbPartName
            // 
            resources.ApplyResources(this.txbPartName, "txbPartName");
            this.txbPartName.Name = "txbPartName";
            // 
            // labelUnitPrice
            // 
            resources.ApplyResources(this.labelUnitPrice, "labelUnitPrice");
            this.labelUnitPrice.Name = "labelUnitPrice";
            // 
            // txbUnitPrice
            // 
            resources.ApplyResources(this.txbUnitPrice, "txbUnitPrice");
            this.txbUnitPrice.Name = "txbUnitPrice";
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
            // AddPartEmployeeForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblExit);
            this.Controls.Add(this.lblMinimise);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txbUnitPrice);
            this.Controls.Add(this.labelUnitPrice);
            this.Controls.Add(this.txbPartName);
            this.Controls.Add(this.labelPartName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AddPartEmployeeForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelPartName;
        private System.Windows.Forms.TextBox txbPartName;
        private System.Windows.Forms.Label labelUnitPrice;
        private System.Windows.Forms.TextBox txbUnitPrice;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label lblExit;
        private System.Windows.Forms.Label lblMinimise;
    }
}
