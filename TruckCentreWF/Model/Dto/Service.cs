using System;

namespace TruckCentreWF.Model.Dto
{
    public class Service
    {
        public int IdService { get; set; }
        public string Name { get; set; }
        public decimal ServiceFee { get; set; }
        public decimal Labour { get; set; }

        public Service()
        {
            // Default constructor
        }

        public Service(int idService, string name, decimal serviceFee, decimal labour)
        {
            IdService = idService;
            Name = name;
            ServiceFee = serviceFee;
            Labour = labour;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Service other = (Service)obj;
            return IdService == other.IdService;
        }

        public override int GetHashCode()
        {
            return IdService.GetHashCode();
        }
    }
}
