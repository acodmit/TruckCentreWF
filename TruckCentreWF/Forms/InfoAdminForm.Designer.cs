using System;
using System.Collections.Generic;
using System.Drawing;
using System.Resources;
using System.Windows.Forms;

using TruckCentreWF.Model.Dao;
using TruckCentreWF.Model.Dto;

namespace TruckCentreWF.Forms
{
    partial class InfoAdminForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel panelInfo;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelActiveTickets;
        private System.Windows.Forms.Label labelFinishedTickets;
        private System.Windows.Forms.Label labelTotalEmployees;
        private System.Windows.Forms.Label labelTotalVehicles;

        // DAO instances
        private ServiceTicketDAO serviceTicketDAO = new ServiceTicketDAO();
        private EmployeeDAO employeeDAO = new EmployeeDAO();
        private VehicleDAO vehicleDAO = new VehicleDAO();

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InfoAdminForm));
            this.panelInfo = new System.Windows.Forms.Panel();
            this.labelTitle = new System.Windows.Forms.Label();
            this.labelActiveTickets = new System.Windows.Forms.Label();
            this.labelFinishedTickets = new System.Windows.Forms.Label();
            this.labelTotalEmployees = new System.Windows.Forms.Label();
            this.labelTotalVehicles = new System.Windows.Forms.Label();
            this.panelInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelInfo
            // 
            resources.ApplyResources(this.panelInfo, "panelInfo");
            this.panelInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(227)))), ((int)(((byte)(222)))));
            this.panelInfo.Controls.Add(this.labelTitle);
            this.panelInfo.Controls.Add(this.labelActiveTickets);
            this.panelInfo.Controls.Add(this.labelFinishedTickets);
            this.panelInfo.Controls.Add(this.labelTotalEmployees);
            this.panelInfo.Controls.Add(this.labelTotalVehicles);
            this.panelInfo.Name = "panelInfo";
            // 
            // labelTitle
            // 
            resources.ApplyResources(this.labelTitle, "labelTitle");
            this.labelTitle.ForeColor = System.Drawing.Color.Gray;
            this.labelTitle.Name = "labelTitle";
            // 
            // labelActiveTickets
            // 
            resources.ApplyResources(this.labelActiveTickets, "labelActiveTickets");
            this.labelActiveTickets.ForeColor = System.Drawing.Color.DimGray;
            this.labelActiveTickets.Name = "labelActiveTickets";
            // 
            // labelFinishedTickets
            // 
            resources.ApplyResources(this.labelFinishedTickets, "labelFinishedTickets");
            this.labelFinishedTickets.ForeColor = System.Drawing.Color.DimGray;
            this.labelFinishedTickets.Name = "labelFinishedTickets";
            // 
            // labelTotalEmployees
            // 
            resources.ApplyResources(this.labelTotalEmployees, "labelTotalEmployees");
            this.labelTotalEmployees.ForeColor = System.Drawing.Color.DimGray;
            this.labelTotalEmployees.Name = "labelTotalEmployees";
            // 
            // labelTotalVehicles
            // 
            resources.ApplyResources(this.labelTotalVehicles, "labelTotalVehicles");
            this.labelTotalVehicles.ForeColor = System.Drawing.Color.DimGray;
            this.labelTotalVehicles.Name = "labelTotalVehicles";
            // 
            // InfoAdminForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "InfoAdminForm";
            this.Load += new System.EventHandler(this.InfoAdminForm_Load);
            this.panelInfo.ResumeLayout(false);
            this.panelInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

    }
}
