using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using TruckCentreWF.Model;
using TruckCentreWF.Util;

namespace TruckCentreWF.Model.Dao
{
    public class ServiceDAO : BaseDAO<Dto.Service>
    {
        protected override string GetTableName()
        {
            return "service";
        }

        protected override Dto.Service ParseLine(DbDataReader reader)
        {
            return new Dto.Service(
                reader.GetInt32(0),     // IdService
                reader.GetString(1),    // Name
                reader.GetDecimal(2),   // ServiceFee
                reader.GetDecimal(3)    // Labour
            );
        }

        protected override MySqlCommand ComposeDeleteCommand(Dto.Service service, MySqlConnection conn)
        {
            string query = "DELETE FROM service WHERE IdService=@IdService";
            MySqlCommand command = new MySqlCommand(query, conn);
            command.Parameters.AddWithValue("@IdService", service.IdService);
            return command;
        }

        protected override MySqlCommand ComposeGetByIdCommand(Dto.Service service, MySqlConnection conn)
        {
            string query = "SELECT * FROM service WHERE IdService=@IdService";
            MySqlCommand command = new MySqlCommand(query, conn);
            command.Parameters.AddWithValue("@IdService", service.IdService);
            return command;
        }

        protected override MySqlCommand ComposeInsertCommand(Dto.Service service, MySqlConnection conn)
        {
            string query = @"INSERT INTO service (Name, ServiceFee, Labour) 
                             VALUES (@Name, @ServiceFee, @Labour)";
            MySqlCommand command = new MySqlCommand(query, conn);
            command.Parameters.AddWithValue("@Name", service.Name);
            command.Parameters.AddWithValue("@ServiceFee", service.ServiceFee);
            command.Parameters.AddWithValue("@Labour", service.Labour);
            return command;
        }

        protected override MySqlCommand ComposeUpdateCommand(Dto.Service service, MySqlConnection conn)
        {
            string query = @"UPDATE service 
                             SET Name=@Name, ServiceFee=@ServiceFee, Labour=@Labour
                             WHERE IdService=@IdService";
            MySqlCommand command = new MySqlCommand(query, conn);
            command.Parameters.AddWithValue("@IdService", service.IdService);
            command.Parameters.AddWithValue("@Name", service.Name);
            command.Parameters.AddWithValue("@ServiceFee", service.ServiceFee);
            command.Parameters.AddWithValue("@Labour", service.Labour);
            return command;
        }
    }
}
