using System;

namespace TruckCentreWF.Model.Dto
{
    public class ServiceTicket
    {
        public int IdServiceTicket { get; set; }
        public int IdEmployee { get; set; }
        public int IdClient { get; set; }
        public DateTime EntryDate { get; set; }
        public string Details { get; set; }
        public string Status { get; set; }
        public int EmployeeIdAccount { get; set; }

        public ServiceTicket()
        {
            // Default constructor
        }
        public ServiceTicket(int idServiceTicket)
        {
            IdServiceTicket = idServiceTicket;
        }


        public ServiceTicket(int idServiceTicket, int idEmployee, int idClient, DateTime entryDate, string details, string status)
        {
            IdServiceTicket = idServiceTicket;
            IdEmployee = idEmployee;
            IdClient = idClient;
            EntryDate = entryDate;
            Details = details;
            Status = status;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            ServiceTicket other = (ServiceTicket)obj;
            return IdServiceTicket == other.IdServiceTicket;
        }

        public override int GetHashCode()
        {
            return IdServiceTicket.GetHashCode();
        }
    }
}
