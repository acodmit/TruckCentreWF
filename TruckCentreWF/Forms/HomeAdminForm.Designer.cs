namespace TruckCentreWF.Forms
{
    partial class HomeAdminForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HomeAdminForm));
            this.pnlMainHome = new TruckCentreWF.Forms.Common.DraggablePanel();
            this.lblContentHome = new System.Windows.Forms.Label();
            this.lblTitleHome = new System.Windows.Forms.Label();
            this.pnlMainHome.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMainHome
            // 
            this.pnlMainHome.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(227)))), ((int)(((byte)(222)))));
            this.pnlMainHome.Controls.Add(this.lblContentHome);
            this.pnlMainHome.Controls.Add(this.lblTitleHome);
            resources.ApplyResources(this.pnlMainHome, "pnlMainHome");
            this.pnlMainHome.Name = "pnlMainHome";
            // 
            // lblContentHome
            // 
            resources.ApplyResources(this.lblContentHome, "lblContentHome");
            this.lblContentHome.Name = "lblContentHome";
            // 
            // lblTitleHome
            // 
            resources.ApplyResources(this.lblTitleHome, "lblTitleHome");
            this.lblTitleHome.Name = "lblTitleHome";
            // 
            // HomeAdminForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.Controls.Add(this.pnlMainHome);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "HomeAdminForm";
            this.pnlMainHome.ResumeLayout(false);
            this.pnlMainHome.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Common.DraggablePanel pnlMainHome;
        private System.Windows.Forms.Label lblContentHome;
        private System.Windows.Forms.Label lblTitleHome;
    }
}