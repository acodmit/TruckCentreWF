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
        public int IdTruck { get; set; }
        public int IdClient { get; set; }
        public string Mileage { get; set; }
        public DateTime? LastService { get; set; }

        public Vehicle()
        {
            // Default constructor
        }

        public Vehicle(string idVehicle, int idTruck, int idClient, string mileage, DateTime? lastService)
        {
            IdVehicle = idVehicle;
            IdTruck = idTruck;
            IdClient = idClient;
            Mileage = mileage;
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
