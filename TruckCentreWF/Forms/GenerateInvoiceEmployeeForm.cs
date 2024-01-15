using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using TruckCentreWF.Model.Dao;
using TruckCentreWF.Model.Dto;

namespace TruckCentreWF.Forms
{
    public partial class GenerateInvoiceEmployeeForm : DraggableForm
    {
        private List<Part> parts;
        private List<Model.Dto.Service> services;
        private ServiceTicket ticketProcessing;

        public GenerateInvoiceEmployeeForm(ServiceTicket serviceTicket)
        {
            // Set ticket processing
            this.ticketProcessing = serviceTicket;

            InitializeComponent();

            // Load data to part and service grids
            LoadData();
        }

        private async void LoadData()
        {
            PartDAO partsDAO = new PartDAO();
            ServiceDAO serviceDAO = new ServiceDAO();

            parts = await partsDAO.GetAll();
            services = await serviceDAO.GetAll();

            Console.Write(parts);
            Console.Write(services);

            DisplayData();
        }

        private void DisplayData()
        {
            // Clear existing rows
            dataGridViewParts.Rows.Clear();
            dataGridViewServices.Rows.Clear();

            // Add data to the tables
            foreach (var part in parts)
            {
                dataGridViewParts.Rows.Add(
                    part.SerialNumber,
                    part.Name,
                    part.UnitPrice
                );
            }

            foreach (var service in services)
            {
                dataGridViewServices.Rows.Add(
                    service.IdService,
                    service.Name,
                    service.ServiceFee,
                    service.Labour
                );
            }
        }

        private void lblExit_Click(object sender, EventArgs e)
        {
            // Close the current form
            this.Close();
        }

        private void lblMinimise_Click(object sender, EventArgs e)
        {
            // Minimize the window
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
