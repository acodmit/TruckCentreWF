using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Threading.Tasks;
using TruckCentreWF.Model.Dto;

namespace TruckCentreWF.Model.Dao
{
    public class ItemServiceDAO : BaseDAO<Model.Dto.ItemService>
    {
        // Specify the table name for the "item_service" entity
        protected override string GetTableName()
        {
            return "item_service";
        }

        // Parse a single row from the database reader into an ItemService object
        protected override Model.Dto.ItemService ParseLine(DbDataReader reader)
        {
            return new Model.Dto.ItemService(
                reader.GetInt32(0),     // IdService
                reader.GetInt32(1),     // IdServiceTicket
                reader.GetString(2),    // Name
                reader.GetDecimal(3),   // ServiceFee
                reader.GetDecimal(4),   // Labour
                reader.GetInt32(5),     // LabourAmount
                reader.GetDecimal(6)    // ItemPrice
            );
        }

        // Compose a SQL command to delete an item_service by IdService and IdServiceTicket
        protected override MySqlCommand ComposeDeleteCommand(Model.Dto.ItemService itemService, MySqlConnection conn)
        {
            string query = "DELETE FROM item_service WHERE IdService=@IdService AND IdServiceTicket=@IdServiceTicket";
            MySqlCommand command = new MySqlCommand(query, conn);
            command.Parameters.AddWithValue("@IdService", itemService.IdService);
            command.Parameters.AddWithValue("@IdServiceTicket", itemService.IdServiceTicket);
            return command;
        }

        // Compose a SQL command to retrieve an item_service by IdService and IdServiceTicket
        protected override MySqlCommand ComposeGetByIdCommand(Model.Dto.ItemService itemService, MySqlConnection conn)
        {
            string query = "SELECT * FROM item_service WHERE IdService=@IdService AND IdServiceTicket=@IdServiceTicket";
            MySqlCommand command = new MySqlCommand(query, conn);
            command.Parameters.AddWithValue("@IdService", itemService.IdService);
            command.Parameters.AddWithValue("@IdServiceTicket", itemService.IdServiceTicket);
            return command;
        }


        // Compose a SQL command to insert a new item_service
        protected override MySqlCommand ComposeInsertCommand(Model.Dto.ItemService itemService, MySqlConnection conn)
        {
            string query = @"INSERT INTO item_service (IdService, IdServiceTicket, Name, ServiceFee, Labour, LabourAmount) 
                     VALUES (@IdService, @IdServiceTicket, @Name, @ServiceFee, @Labour, @LabourAmount)";
            MySqlCommand command = new MySqlCommand(query, conn);
            command.Parameters.AddWithValue("@IdService", itemService.IdService);
            command.Parameters.AddWithValue("@IdServiceTicket", itemService.IdServiceTicket);
            command.Parameters.AddWithValue("@Name", itemService.Name);
            command.Parameters.AddWithValue("@ServiceFee", itemService.ServiceFee);
            command.Parameters.AddWithValue("@Labour", itemService.Labour);
            command.Parameters.AddWithValue("@LabourAmount", itemService.LabourAmount);
            return command;
        }

        // Compose a SQL command to update an existing item_service
        protected override MySqlCommand ComposeUpdateCommand(Model.Dto.ItemService itemService, MySqlConnection conn)
        {
            string query = @"UPDATE item_service 
                     SET IdService=@IdService, IdServiceTicket=@IdServiceTicket, Name=@Name, 
                         ServiceFee=@ServiceFee, Labour=@Labour, LabourAmount=@LabourAmount
                     WHERE IdService=@IdService";
            MySqlCommand command = new MySqlCommand(query, conn);
            command.Parameters.AddWithValue("@IdService", itemService.IdService);
            command.Parameters.AddWithValue("@IdServiceTicket", itemService.IdServiceTicket);
            command.Parameters.AddWithValue("@Name", itemService.Name);
            command.Parameters.AddWithValue("@ServiceFee", itemService.ServiceFee);
            command.Parameters.AddWithValue("@Labour", itemService.Labour);
            command.Parameters.AddWithValue("@LabourAmount", itemService.LabourAmount);
            return command;
        }

        // Retrieve item_services by IdServiceTicket
        public async Task<List<ItemService>> GetByServiceTicketId(int idServiceTicket)
        {
            List<ItemService> result = new List<ItemService>();

            using (MySqlConnection conn = Util.ConnectionPool.GetInstance().CheckOut())
            {
                string query = "SELECT * FROM item_service WHERE IdServiceTicket=@IdServiceTicket";
                MySqlCommand command = new MySqlCommand(query, conn);
                command.Parameters.AddWithValue("@IdServiceTicket", idServiceTicket);

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ItemService itemService = new ItemService
                        {
                            // Map columns from the reader to itemService properties
                            IdService = Convert.ToInt32(reader["IdService"]),
                            IdServiceTicket = Convert.ToInt32(reader["IdServiceTicket"]),
                            Name = reader["Name"].ToString(),
                            ServiceFee = Convert.ToDecimal(reader["ServiceFee"]),
                            Labour = Convert.ToDecimal(reader["Labour"]),
                            LabourAmount = Convert.ToInt32(reader["LabourAmount"]),
                            ItemPrice = Convert.ToDecimal(reader["ItemPrice"])
                        };

                        result.Add(itemService);
                    }
                }
            }
            return result;
        }
    }
}
