using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TruckCentreWF.Model.Dao;
using TruckCentreWF.Model.Dto;

namespace TruckCentreWF.Service
{
    internal class LoginService
    {
        public static async Task<string> CheckLogin(string username, string password)
        {
            // Fetch the list of employees from the database
            List<Employee> employees = await EmployeeService.GetAllEmployees();

            // Find the user with the given username and password
            Employee user = employees.FirstOrDefault(e => e.Username == username && 
                                                          e.Password == Util.HashGenerator.GenerateHash(password));

            if (user != null)
            {
                // Set the user to the current employee in ApplicationService
                ApplicationService.CurrEmployee = user;

                // Return the user type ("A" for admin, "E" for employee)
                return user.IsAdmin ? "A" : "E";
            }

            // Return null if login is unsuccessful
            return null;
        }
    }
}
