using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TruckCentreWF.Model.Dao;
using TruckCentreWF.Model.Dto;

namespace TruckCentreWF.Service
{
    public class EmployeeService
    {        
        public static async Task<Boolean> AddEmployee(Employee employee)
        {
            EmployeeDAO employeeDAO = new EmployeeDAO();

            // Insert a new employee using the employeeDAO
            int result = await employeeDAO.Insert(employee);

            // Return true if the insertion was successful
            return result > 0;
        }

        public async static Task<Boolean> UpdateEmployee(Employee employee)
        {
            EmployeeDAO employeeDAO = new EmployeeDAO();

            // Update the employee using the employeeDAO
            int result = await employeeDAO.Update(employee);

            // Return true if the update was successful
            return result > 0;
        }

        public static async Task<Boolean> DeleteEmployee(Employee employee)
        {
            EmployeeDAO employeeDAO = new EmployeeDAO();

            // Delete the employee using the employeeDAO
            int result = await employeeDAO.Delete(employee);

            // Return true if the deletion was successful
            return result > 0;
        }
        
        public async static Task<Employee> GetOneEmployee(Employee employee)
        {
            EmployeeDAO employeeDAO = new EmployeeDAO();

            // Get a single employee by ID
            Employee one = await employeeDAO.GetById(employee);

            // Return the retrieved employee
            return one;
        }

        public async static Task<List<Employee>> GetAllEmployees()
        {
            EmployeeDAO employeeDAO = new EmployeeDAO();

            // Get all employees
            List<Employee> result = await employeeDAO.GetAll();

            // Return the list of employees
            return result;
        }

    }
}
