using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TruckCentreWF.Model.Dto
{    
    public class Employee
    {          
        public int IdEmployee { get; set; }
        public string Username { get; set; }
        public string Password { get; set; } // Storing hashed password as VARCHAR(64)
        public bool IsAdmin { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Theme { get; set; }
        public bool Status { get; set; }

        public Employee()
        {
            // Default constructor
        }

        public Employee(int idEmployee, string username, string password, bool isAdmin, bool status, string firstName, string lastName,
            int theme)
        {
            IdEmployee = idEmployee;
            Username = username;
            Password = password;
            IsAdmin = isAdmin;
            Status = status;
            FirstName = firstName;
            LastName = lastName;
            Theme = theme;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Employee other = (Employee)obj;
            return IdEmployee == other.IdEmployee;
        }

        public override int GetHashCode()
        {
            return IdEmployee.GetHashCode();
        }

    }
}
