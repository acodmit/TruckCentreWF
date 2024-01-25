using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TruckCentreWF.Model.Dto
{
    public class ItemPart
    {
        public int SerialNumber { get; set; }
        public int IdServiceTicket { get; set; }
        public string Name { get; set; }
        public decimal? UnitPrice { get; set; }
        public int? Quantity { get; set; }
        public decimal? ItemPrice { get; set; } // This is the generated column

        public ItemPart()
        {
            // Default constructor
        }

        // Constructor without the generated column (itemPrice)
        public ItemPart(int serialNumber, int idServiceTicket, string name, decimal? unitPrice, int? quantity)
        {
            SerialNumber = serialNumber;
            IdServiceTicket = idServiceTicket;
            Name = name;
            UnitPrice = unitPrice;
            Quantity = quantity;
        }

        // Constructor with the generated column (itemPrice)
        public ItemPart(int serialNumber, int idServiceTicket, string name, decimal? unitPrice, int? quantity, decimal? itemPrice)
            : this(serialNumber, idServiceTicket, name, unitPrice, quantity)
        {
            ItemPrice = itemPrice;
        }
    }
}
