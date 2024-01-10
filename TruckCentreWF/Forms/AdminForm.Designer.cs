namespace TruckCentreWF.Forms
{
    partial class AdminForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminForm));
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.btnInfo = new System.Windows.Forms.Button();
            this.btnLogOut = new System.Windows.Forms.Button();
            this.btnSettings = new System.Windows.Forms.Button();
            this.btnAccounts = new System.Windows.Forms.Button();
            this.btnHome = new System.Windows.Forms.Button();
            this.pnlLogo = new TruckCentreWF.Forms.Common.TransparentPanel();
            this.pnlToolbar = new TruckCentreWF.Forms.Common.DraggablePanel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblMinimise = new System.Windows.Forms.Label();
            this.lblExit = new System.Windows.Forms.Label();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlMenu.SuspendLayout();
            this.pnlToolbar.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMenu
            // 
            this.pnlMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(144)))), ((int)(((byte)(128)))));
            this.pnlMenu.Controls.Add(this.btnInfo);
            this.pnlMenu.Controls.Add(this.btnLogOut);
            this.pnlMenu.Controls.Add(this.btnSettings);
            this.pnlMenu.Controls.Add(this.btnAccounts);
            this.pnlMenu.Controls.Add(this.btnHome);
            this.pnlMenu.Controls.Add(this.pnlLogo);
            resources.ApplyResources(this.pnlMenu, "pnlMenu");
            this.pnlMenu.Name = "pnlMenu";
            // 
            // btnInfo
            // 
            this.btnInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(144)))), ((int)(((byte)(128)))));
            resources.ApplyResources(this.btnInfo, "btnInfo");
            this.btnInfo.FlatAppearance.BorderSize = 0;
            this.btnInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnInfo.Name = "btnInfo";
            this.btnInfo.UseVisualStyleBackColor = false;
            this.btnInfo.Click += new System.EventHandler(this.btnInfo_Click);
            // 
            // btnLogOut
            // 
            this.btnLogOut.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(144)))), ((int)(((byte)(128)))));
            resources.ApplyResources(this.btnLogOut, "btnLogOut");
            this.btnLogOut.FlatAppearance.BorderSize = 0;
            this.btnLogOut.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.UseVisualStyleBackColor = false;
            this.btnLogOut.Click += new System.EventHandler(this.btnLogOut_Click);
            // 
            // btnSettings
            // 
            this.btnSettings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(144)))), ((int)(((byte)(128)))));
            resources.ApplyResources(this.btnSettings, "btnSettings");
            this.btnSettings.FlatAppearance.BorderSize = 0;
            this.btnSettings.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.UseVisualStyleBackColor = false;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // btnAccounts
            // 
            this.btnAccounts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(144)))), ((int)(((byte)(128)))));
            resources.ApplyResources(this.btnAccounts, "btnAccounts");
            this.btnAccounts.FlatAppearance.BorderSize = 0;
            this.btnAccounts.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnAccounts.Name = "btnAccounts";
            this.btnAccounts.UseVisualStyleBackColor = false;
            this.btnAccounts.Click += new System.EventHandler(this.btnAccounts_Click);
            // 
            // btnHome
            // 
            this.btnHome.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(144)))), ((int)(((byte)(128)))));
            resources.ApplyResources(this.btnHome, "btnHome");
            this.btnHome.FlatAppearance.BorderSize = 0;
            this.btnHome.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnHome.Name = "btnHome";
            this.btnHome.UseVisualStyleBackColor = false;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // pnlLogo
            // 
            this.pnlLogo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(130)))), ((int)(((byte)(115)))));
            this.pnlLogo.BackgroundImage = global::TruckCentreWF.Properties.Resources.truck;
            resources.ApplyResources(this.pnlLogo, "pnlLogo");
            this.pnlLogo.Name = "pnlLogo";
            this.pnlLogo.Opacity = 0.6F;
            // 
            // pnlToolbar
            // 
            this.pnlToolbar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(227)))), ((int)(((byte)(222)))));
            this.pnlToolbar.Controls.Add(this.lblTitle);
            this.pnlToolbar.Controls.Add(this.lblMinimise);
            this.pnlToolbar.Controls.Add(this.lblExit);
            resources.ApplyResources(this.pnlToolbar, "pnlToolbar");
            this.pnlToolbar.Name = "pnlToolbar";
            // 
            // lblTitle
            // 
            resources.ApplyResources(this.lblTitle, "lblTitle");
            this.lblTitle.Name = "lblTitle";
            // 
            // lblMinimise
            // 
            resources.ApplyResources(this.lblMinimise, "lblMinimise");
            this.lblMinimise.Name = "lblMinimise";
            this.lblMinimise.Click += new System.EventHandler(this.lblMinimise_Click);
            // 
            // lblExit
            // 
            resources.ApplyResources(this.lblExit, "lblExit");
            this.lblExit.Name = "lblExit";
            this.lblExit.Click += new System.EventHandler(this.lblExit_Click);
            // 
            // pnlMain
            // 
            resources.ApplyResources(this.pnlMain, "pnlMain");
            this.pnlMain.Name = "pnlMain";
            // 
            // AdminForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlToolbar);
            this.Controls.Add(this.pnlMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AdminForm";
            this.pnlMenu.ResumeLayout(false);
            this.pnlToolbar.ResumeLayout(false);
            this.pnlToolbar.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.Button btnHome;
        private TruckCentreWF.Forms.Common.TransparentPanel pnlLogo;
        private System.Windows.Forms.Button btnLogOut;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Button btnAccounts;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblMinimise;
        private System.Windows.Forms.Label lblExit;
        private Common.DraggablePanel pnlToolbar;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Button btnInfo;
    }
}