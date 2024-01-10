using System;

namespace TruckCentre.Model.Dto
{
    public class ServiceTicket
    {
        public int IdServiceTicket { get; set; }
        public int IdAccount { get; set; }
        public DateTime EntryDate { get; set; }
        public string Details { get; set; }
        public string Status { get; set; }
        public int EmployeeIdAccount { get; set; }

        public ServiceTicket()
        {
            // Default constructor
        }

        public ServiceTicket(int idServiceTicket, int idAccount, DateTime entryDate, string details, string status, int employeeIdAccount)
        {
            IdServiceTicket = idServiceTicket;
            IdAccount = idAccount;
            EntryDate = entryDate;
            Details = details;
            Status = status;
            EmployeeIdAccount = employeeIdAccount;
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
