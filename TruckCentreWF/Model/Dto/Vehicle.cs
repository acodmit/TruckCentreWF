using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TruckCentreWF.Model.Dto
{
    public class Vehicle
    {
        public string IdVehicle { get; set; }
        public string Mileage { get; set; }
        public string Details { get; set; }
        public DateTime? LastService { get; set; }

        public Vehicle()
        {
            // Default constructor
        }

        public Vehicle(string idVehicle, string mileage, string details, DateTime? lastService)
        {
            IdVehicle = idVehicle;
            Mileage = mileage;
            Details = details;
            LastService = lastService;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Vehicle other = (Vehicle)obj;
            return IdVehicle == other.IdVehicle;
        }

        public override int GetHashCode()
        {
            return IdVehicle.GetHashCode();
        }
    }
}
