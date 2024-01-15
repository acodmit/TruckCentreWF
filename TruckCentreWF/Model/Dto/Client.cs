using System;

namespace TruckCentreWF.Model.Dto
{
    public class Client
    {
        public int IdClient { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }

        public Client()
        {
            // Default constructor
        }

        public Client(int idClient, string email, string address)
        {
            IdClient = idClient;
            Email = email;
            Address = address;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Client other = (Client)obj;
            return IdClient == other.IdClient;
        }

        public override int GetHashCode()
        {
            return IdClient.GetHashCode();
        }
    }
}
