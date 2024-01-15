using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Threading.Tasks;

using TruckCentreWF.Model.Dto;

namespace TruckCentreWF.Model.Dao
{
    public class ClientDAO : BaseDAO<Client>
    {
        // Specify the table name for the "client" entity
        protected override string GetTableName()
        {
            return "client";
        }

        // Parse a single row from the database reader into a Client object
        protected override Client ParseLine(DbDataReader reader)
        {
            return new Client(
                reader.GetInt32(0),          // IdClient
                reader.GetString(1),         // Email
                reader.GetString(2)         // Address
            );
        }

        // Compose a SQL command to delete a client by IdClient
        protected override MySqlCommand ComposeDeleteCommand(Client client, MySqlConnection conn)
        {
            string query = "DELETE FROM client WHERE IdClient=@IdClient";
            MySqlCommand command = new MySqlCommand(query, conn);
            command.Parameters.AddWithValue("@IdClient", client.IdClient);
            return command;
        }

        // Compose a SQL command to retrieve a client by IdClient
        protected override MySqlCommand ComposeGetByIdCommand(Client client, MySqlConnection conn)
        {
            string query = "SELECT * FROM client WHERE IdClient=@IdClient";
            MySqlCommand command = new MySqlCommand(query, conn);
            command.Parameters.AddWithValue("@IdClient", client.IdClient);
            return command;
        }

        // Compose a SQL command to insert a new client
        protected override MySqlCommand ComposeInsertCommand(Client client, MySqlConnection conn)
        {
            string query = @"INSERT INTO client (Email, Address) 
                             VALUES (@Email, @Address)";
            MySqlCommand command = new MySqlCommand(query, conn);
            command.Parameters.AddWithValue("@Email", client.Email);
            command.Parameters.AddWithValue("@Address", client.Address);
            return command;
        }

        // Compose a SQL command to update an existing client
        protected override MySqlCommand ComposeUpdateCommand(Client client, MySqlConnection conn)
        {
            string query = @"UPDATE client 
                             SET Email=@Email, Address=@Address
                             WHERE IdClient=@IdClient";
            MySqlCommand command = new MySqlCommand(query, conn);
            command.Parameters.AddWithValue("@IdClient", client.IdClient);
            command.Parameters.AddWithValue("@Email", client.Email);
            command.Parameters.AddWithValue("@Address", client.Address);
            return command;
        }

        protected override Task<int> PreDeleteQuery(Client client)
        {
            // Additional logic before deleting a client, if needed
            return Task.FromResult(1);
        }
    }
}
