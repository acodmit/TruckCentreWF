using System;

namespace TruckCentreWF.Model.Dto
{
    public class ItemService
    {
        public int IdService { get; set; }
        public int IdServiceTicket { get; set; }
        public string Name { get; set; }
        public decimal ServiceFee { get; set; }
        public decimal Labour { get; set; }
        public int LabourAmount { get; set; }
        public decimal ItemPrice { get; set; }

        public ItemService()
        {
            // Default constructor
        }

        public ItemService(int idService, int idServiceTicket, string name, decimal serviceFee, decimal labour, int labourAmount)
        {
            IdService = idService;
            IdServiceTicket = idServiceTicket;
            Name = name;
            ServiceFee = serviceFee;
            Labour = labour;
            LabourAmount = labourAmount;
        }

        public ItemService(int idService, int idServiceTicket, string name, decimal serviceFee, decimal labour, int labourAmount, decimal itemPrice) :
            this(idService, idServiceTicket, name, serviceFee, labour, labourAmount)
        {
            ItemPrice = itemPrice;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            ItemService other = (ItemService)obj;
            // Compare other relevant members for equality
            return IdService == other.IdService
                && IdServiceTicket == other.IdServiceTicket
                && Name == other.Name
                && ServiceFee == other.ServiceFee
                && Labour == other.Labour
                && LabourAmount == other.LabourAmount
                && ItemPrice == other.ItemPrice;
        }

        public override int GetHashCode()
        {
            // Hash relevant members
            return new { IdService, IdServiceTicket, Name, ServiceFee, Labour, LabourAmount, ItemPrice }
                .GetHashCode();
        }

    }
}
