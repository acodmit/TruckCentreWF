using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

using TruckCentreWF.Model.Dto;

namespace TruckCentreWF.Model.Dao
{
    public class EmployeeDAO : BaseDAO<Employee>
    {
        // Specify the table name for the "employee" entity
        protected override string GetTableName()
        {
            return "employee";
        }

        // Parse a single row from the database reader into an Employee object
        protected override Employee ParseLine(DbDataReader reader)
        {
            return new Employee(
                reader.GetInt32(0),         // IdEmployee
                reader.GetString(1),        // Username
                reader.GetString(2),        // Password
                reader.GetBoolean(3),       // IsAdmin
                reader.GetBoolean(4),       // Status
                reader.GetString(5),        // FirstName
                reader.GetString(6),        // LastName
                reader.GetInt32(7)          // Theme
            );
        }


        // Compose a SQL command to delete an employee by IdEmployee
        protected override MySqlCommand ComposeDeleteCommand(Employee employee, MySqlConnection conn)
        {
            string query = "DELETE FROM employee WHERE IdEmployee=@IdEmployee";
            MySqlCommand command = new MySqlCommand(query, conn);
            command.Parameters.AddWithValue("@IdEmployee", employee.IdEmployee);
            return command;
        }

        // Compose a SQL command to retrieve an employee by IdEmployee
        protected override MySqlCommand ComposeGetByIdCommand(Employee employee, MySqlConnection conn)
        {
            string query = "SELECT * FROM employee WHERE IdEmployee=@IdEmployee";
            MySqlCommand command = new MySqlCommand(query, conn);
            command.Parameters.AddWithValue("@IdEmployee", employee.IdEmployee);
            return command;
        }

        // Compose a SQL command to insert a new employee
        protected override MySqlCommand ComposeInsertCommand(Employee employee, MySqlConnection conn)
        {
            string query = @"INSERT INTO employee (Username, Password, IsAdmin, Status, FirstName, LastName, Theme) 
                             VALUES (@Username, @Password, @IsAdmin, @Status, @FirstName, @LastName, @Theme)";
            MySqlCommand command = new MySqlCommand(query, conn);
            command.Parameters.AddWithValue("@Username", employee.Username);
            command.Parameters.AddWithValue("@Password", employee.Password);
            command.Parameters.AddWithValue("@IsAdmin", employee.IsAdmin);
            command.Parameters.AddWithValue("@Status", employee.Status);
            command.Parameters.AddWithValue("@FirstName", employee.FirstName);
            command.Parameters.AddWithValue("@LastName", employee.LastName);
            command.Parameters.AddWithValue("@Theme", employee.Theme);
            return command;
        }

        // Compose a SQL command to update an existing employee
        protected override MySqlCommand ComposeUpdateCommand(Employee employee, MySqlConnection conn)
        {
            string query = @"UPDATE employee 
                             SET Username=@Username, Password=@Password, IsAdmin=@IsAdmin, Status=@Status, FirstName=@FirstName, LastName=@LastName, 
                             Theme=@Theme 
                             WHERE IdEmployee=@IdEmployee";
            MySqlCommand command = new MySqlCommand(query, conn);
            command.Parameters.AddWithValue("@IdEmployee", employee.IdEmployee);
            command.Parameters.AddWithValue("@Username", employee.Username);
            command.Parameters.AddWithValue("@Password", employee.Password);
            command.Parameters.AddWithValue("@IsAdmin", employee.IsAdmin);
            command.Parameters.AddWithValue("@Status", employee.Status);
            command.Parameters.AddWithValue("@FirstName", employee.FirstName);
            command.Parameters.AddWithValue("@LastName", employee.LastName);
            command.Parameters.AddWithValue("@Theme", employee.Theme);
            return command;
        }

        protected override Task<int> PreDeleteQuery(Employee employee)
        {
            // Check if the employee is an administrator
            if (employee.IsAdmin)
            {
                // Show a message that administrators cannot be deleted
                DialogResult result = MessageBox.Show("Administrators cannot be deleted.",
                                                      "Authorization Error",
                                                      MessageBoxButtons.OKCancel,
                                                      MessageBoxIcon.Error);

                // Return 0 if the user clicks OK, indicating deletion should not proceed
                return Task.FromResult(result == DialogResult.OK ? 0 : 1);
            }

            // For other types of employees, allowing deletion to proceed
            return Task.FromResult(1);
        }
    }
}

