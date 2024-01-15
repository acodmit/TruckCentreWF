using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Threading.Tasks;
using TruckCentreWF.Model.Dto;

namespace TruckCentreWF.Model.Dao
{
    public class ServiceTicketVehicleDAO : BaseDAO<ServiceTicketVehicle>
    {
        protected override string GetTableName()
        {
            return "service_ticket_vehicle";
        }

        protected override ServiceTicketVehicle ParseLine(DbDataReader reader)
        {
            return new ServiceTicketVehicle
            {
                IdServiceTicket = reader.GetInt32(0),
                IdVehicle = reader.GetString(1)
            };
        }

        protected override MySqlCommand ComposeDeleteCommand(ServiceTicketVehicle entity, MySqlConnection conn)
        {
            string query = "DELETE FROM service_ticket_vehicle WHERE idServiceTicket=@idServiceTicket AND idVehicle=@idVehicle";
            MySqlCommand command = new MySqlCommand(query, conn);
            command.Parameters.AddWithValue("@idServiceTicket", entity.IdServiceTicket);
            command.Parameters.AddWithValue("@idVehicle", entity.IdVehicle);
            return command;
        }

        protected override MySqlCommand ComposeGetByIdCommand(ServiceTicketVehicle entity, MySqlConnection conn)
        {
            string query = "SELECT * FROM service_ticket_vehicle WHERE idServiceTicket=@idServiceTicket AND idVehicle=@idVehicle";
            MySqlCommand command = new MySqlCommand(query, conn);
            command.Parameters.AddWithValue("@idServiceTicket", entity.IdServiceTicket);
            command.Parameters.AddWithValue("@idVehicle", entity.IdVehicle);
            return command;
        }

        protected override MySqlCommand ComposeInsertCommand(ServiceTicketVehicle entity, MySqlConnection conn)
        {
            string query = "INSERT INTO service_ticket_vehicle (idServiceTicket, idVehicle) VALUES (@idServiceTicket, @idVehicle)";
            MySqlCommand command = new MySqlCommand(query, conn);
            command.Parameters.AddWithValue("@idServiceTicket", entity.IdServiceTicket);
            command.Parameters.AddWithValue("@idVehicle", entity.IdVehicle);
            return command;
        }

        protected override MySqlCommand ComposeUpdateCommand(ServiceTicketVehicle entity, MySqlConnection conn)
        {
            // Since it's a composite key table, we may not need an update command
            throw new NotSupportedException("Update operation not supported for composite key table");
        }

        protected override Task<int> PreDeleteQuery(ServiceTicketVehicle entity)
        {
            // Additional logic before deleting a service_ticket_vehicle, if needed
            return Task.FromResult(1);
        }
    }
}
