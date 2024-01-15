using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using TruckCentreWF.Model.Dto;
using TruckCentreWF.Util;

namespace TruckCentreWF.Model.Dao
{
    public class PartDAO : BaseDAO<Part>
    {
        protected override string GetTableName()
        {
            return "part";
        }

        protected override Part ParseLine(DbDataReader reader)
        {
            return new Part(
                reader.GetInt32(0),     // SerialNumber
                reader.GetString(1),    // Name
                reader.GetDecimal(2)    // UnitPrice
            );
        }

        protected override MySqlCommand ComposeDeleteCommand(Part part, MySqlConnection conn)
        {
            string query = "DELETE FROM part WHERE SerialNumber=@SerialNumber";
            MySqlCommand command = new MySqlCommand(query, conn);
            command.Parameters.AddWithValue("@SerialNumber", part.SerialNumber);
            return command;
        }

        protected override MySqlCommand ComposeGetByIdCommand(Part part, MySqlConnection conn)
        {
            string query = "SELECT * FROM part WHERE SerialNumber=@SerialNumber";
            MySqlCommand command = new MySqlCommand(query, conn);
            command.Parameters.AddWithValue("@SerialNumber", part.SerialNumber);
            return command;
        }

        protected override MySqlCommand ComposeInsertCommand(Part part, MySqlConnection conn)
        {
            string query = @"INSERT INTO part (Name, UnitPrice) 
                             VALUES (@Name, @UnitPrice)";
            MySqlCommand command = new MySqlCommand(query, conn);
            command.Parameters.AddWithValue("@Name", part.Name);
            command.Parameters.AddWithValue("@UnitPrice", part.UnitPrice);
            return command;
        }

        protected override MySqlCommand ComposeUpdateCommand(Part part, MySqlConnection conn)
        {
            string query = @"UPDATE part 
                             SET Name=@Name, UnitPrice=@UnitPrice
                             WHERE SerialNumber=@SerialNumber";
            MySqlCommand command = new MySqlCommand(query, conn);
            command.Parameters.AddWithValue("@SerialNumber", part.SerialNumber);
            command.Parameters.AddWithValue("@Name", part.Name);
            command.Parameters.AddWithValue("@UnitPrice", part.UnitPrice);
            return command;
        }
    }
}
