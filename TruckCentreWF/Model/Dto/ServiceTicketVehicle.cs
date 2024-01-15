using System;

namespace TruckCentreWF.Model.Dto
{
    public class ServiceTicketVehicle
    {
        public int IdServiceTicket { get; set; }
        public string IdVehicle { get; set; }

        public ServiceTicketVehicle()
        {
            // Default constructor
        }

        public ServiceTicketVehicle(int idServiceTicket, string idVehicle)
        {
            IdServiceTicket = idServiceTicket;
            IdVehicle = idVehicle;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            ServiceTicketVehicle other = (ServiceTicketVehicle)obj;
            return IdServiceTicket == other.IdServiceTicket && IdVehicle == other.IdVehicle;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + IdServiceTicket.GetHashCode();
                hash = hash * 23 + (IdVehicle != null ? IdVehicle.GetHashCode() : 0);
                return hash;
            }
        }
    }
}
