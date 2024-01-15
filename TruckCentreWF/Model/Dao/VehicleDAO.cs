using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Threading.Tasks;

using TruckCentreWF.Model.Dao;
using TruckCentreWF.Model.Dto;

namespace TruckCentreWF.Model.Dao
{
    public class VehicleDAO : BaseDAO<Vehicle>
    {
        // Specify the table name for the "vehicle" entity
        protected override string GetTableName()
        {
            return "vehicle";
        }

        // Parse a single row from the database reader into a Vehicle object
        protected override Vehicle ParseLine(DbDataReader reader)
        {
            return new Vehicle(
                reader.GetString(0),    // IdVehicle
                reader.GetString(1),    // Mileage
                reader.IsDBNull(2) ? null : reader.GetString(2),    // Details
                reader.IsDBNull(3) ? (DateTime?)null : reader.GetDateTime(3)   // LastService
            );
        }

        // Compose a SQL command to delete a vehicle by IdVehicle
        protected override MySqlCommand ComposeDeleteCommand(Vehicle vehicle, MySqlConnection conn)
        {
            string query = "DELETE FROM vehicle WHERE IdVehicle=@IdVehicle";
            MySqlCommand command = new MySqlCommand(query, conn);
            command.Parameters.AddWithValue("@IdVehicle", vehicle.IdVehicle);
            return command;
        }

        // Compose a SQL command to retrieve a vehicle by IdVehicle
        protected override MySqlCommand ComposeGetByIdCommand(Vehicle vehicle, MySqlConnection conn)
        {
            string query = "SELECT * FROM vehicle WHERE IdVehicle=@IdVehicle";
            MySqlCommand command = new MySqlCommand(query, conn);
            command.Parameters.AddWithValue("@IdVehicle", vehicle.IdVehicle);
            return command;
        }

        // Compose a SQL command to insert a new vehicle
        protected override MySqlCommand ComposeInsertCommand(Vehicle vehicle, MySqlConnection conn)
        {
            string query = @"INSERT INTO vehicle ( Mileage, Details, LastService) 
                             VALUES (@Mileage, @Details, @LastService)";
            MySqlCommand command = new MySqlCommand(query, conn);
            command.Parameters.AddWithValue("@Mileage", vehicle.Mileage);
            command.Parameters.AddWithValue("@Details", vehicle.Details);
            command.Parameters.AddWithValue("@LastService", vehicle.LastService);
            return command;
        }

        // Compose a SQL command to update an existing vehicle
        protected override MySqlCommand ComposeUpdateCommand(Vehicle vehicle, MySqlConnection conn)
        {
            string query = @"UPDATE vehicle 
                             SET Mileage=@Mileage, Details=@Details, LastService=@LastService
                             WHERE IdVehicle=@IdVehicle";
            MySqlCommand command = new MySqlCommand(query, conn);
            command.Parameters.AddWithValue("@IdVehicle", vehicle.IdVehicle);
            command.Parameters.AddWithValue("@Mileage", vehicle.Mileage);
            command.Parameters.AddWithValue("@Details", vehicle.Details);
            command.Parameters.AddWithValue("@LastService", vehicle.LastService);
            return command;
        }

        protected override Task<int> PreDeleteQuery(Vehicle vehicle)
        {
            // Additional logic before deleting a vehicle, if needed
            return Task.FromResult(1);
        }
    }
}
