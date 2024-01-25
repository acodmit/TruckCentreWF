using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Threading.Tasks;
using TruckCentreWF.Model.Dto;

namespace TruckCentreWF.Model.Dao
{
    public class ItemPartDAO : BaseDAO<ItemPart>
    {
        // Specify the table name for the "item_part" entity
        protected override string GetTableName()
        {
            return "item_part";
        }

        // Parse a single row from the database reader into an ItemPart object
        protected override ItemPart ParseLine(DbDataReader reader)
        {
            return new ItemPart(
                reader.GetInt32(0),     // SerialNumber
                reader.GetInt32(1),     // IdServiceTicket
                reader.GetString(2),    // Name
                reader.GetDecimal(3),   // UnitPrice
                reader.GetInt32(4),     // Quantity
                reader.GetDecimal(5)    // ItemPrice
            );
        }

        // Compose a SQL command to delete an item_part by SerialNumber and IdServiceTicket
        protected override MySqlCommand ComposeDeleteCommand(ItemPart itemPart, MySqlConnection conn)
        {
            string query = "DELETE FROM item_part WHERE SerialNumber=@SerialNumber AND IdServiceTicket=@IdServiceTicket";
            MySqlCommand command = new MySqlCommand(query, conn);
            command.Parameters.AddWithValue("@SerialNumber", itemPart.SerialNumber);
            command.Parameters.AddWithValue("@IdServiceTicket", itemPart.IdServiceTicket);
            return command;
        }

        // Compose a SQL command to retrieve an item_part by SerialNumber and IdServiceTicket
        protected override MySqlCommand ComposeGetByIdCommand(ItemPart itemPart, MySqlConnection conn)
        {
            string query = "SELECT * FROM item_part WHERE SerialNumber=@SerialNumber AND IdServiceTicket=@IdServiceTicket";
            MySqlCommand command = new MySqlCommand(query, conn);
            command.Parameters.AddWithValue("@SerialNumber", itemPart.SerialNumber);
            command.Parameters.AddWithValue("@IdServiceTicket", itemPart.IdServiceTicket);
            return command;
        }

        // Compose a SQL command to insert a new item_part
        protected override MySqlCommand ComposeInsertCommand(ItemPart itemPart, MySqlConnection conn)
        {
            string query = @"INSERT INTO item_part (SerialNumber, IdServiceTicket, Name, UnitPrice, Quantity) 
                             VALUES (@SerialNumber, @IdServiceTicket, @Name, @UnitPrice, @Quantity)";
            MySqlCommand command = new MySqlCommand(query, conn);
            command.Parameters.AddWithValue("@SerialNumber", itemPart.SerialNumber);
            command.Parameters.AddWithValue("@IdServiceTicket", itemPart.IdServiceTicket);
            command.Parameters.AddWithValue("@Name", itemPart.Name);
            command.Parameters.AddWithValue("@UnitPrice", itemPart.UnitPrice);
            command.Parameters.AddWithValue("@Quantity", itemPart.Quantity);
            return command;
        }

        // Compose a SQL command to update an existing item_part
        protected override MySqlCommand ComposeUpdateCommand(ItemPart itemPart, MySqlConnection conn)
        {
            string query = @"UPDATE item_part 
                             SET Name=@Name, UnitPrice=@UnitPrice, Quantity=@Quantity
                             WHERE SerialNumber=@SerialNumber AND IdServiceTicket=@IdServiceTicket";
            MySqlCommand command = new MySqlCommand(query, conn);
            command.Parameters.AddWithValue("@SerialNumber", itemPart.SerialNumber);
            command.Parameters.AddWithValue("@IdServiceTicket", itemPart.IdServiceTicket);
            command.Parameters.AddWithValue("@Name", itemPart.Name);
            command.Parameters.AddWithValue("@UnitPrice", itemPart.UnitPrice);
            command.Parameters.AddWithValue("@Quantity", itemPart.Quantity);
            return command;
        }

        protected override Task<int> PreDeleteQuery(ItemPart itemPart)
        {
            // Additional logic before deleting an item_part, if needed
            return Task.FromResult(1);
        }

        // Retrieve item_parts by IdServiceTicket
        public async Task<List<ItemPart>> GetByServiceTicketId(int idServiceTicket)
        {
            List<ItemPart> result = new List<ItemPart>();

            using (MySqlConnection conn = Util.ConnectionPool.GetInstance().CheckOut())
            {
                string query = "SELECT * FROM item_part WHERE IdServiceTicket=@IdServiceTicket";
                MySqlCommand command = new MySqlCommand(query, conn);
                command.Parameters.AddWithValue("@IdServiceTicket", idServiceTicket);

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ItemPart itemPart = new ItemPart
                        {
                            // Map columns from the reader to itemPart properties
                            SerialNumber = Convert.ToInt32(reader["SerialNumber"]),
                            IdServiceTicket = Convert.ToInt32(reader["IdServiceTicket"]),
                            Name = reader["Name"].ToString(),
                            UnitPrice = Convert.ToDecimal(reader["UnitPrice"]),
                            Quantity = Convert.ToInt32(reader["Quantity"]),
                            ItemPrice = Convert.ToDecimal(reader["ItemPrice"])
                        };
                        result.Add(itemPart);
                    }
                }
            }
            return result;
        }
    }
}

