using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

using TruckCentreWF.Model.Dto;
using TruckCentreWF.Model.Dao;
using TruckCentreWF.Util;
using System.Transactions;
using System.Data;

namespace TruckCentreWF.Model.Dao
{
    public class ServiceTicketDAO : BaseDAO<ServiceTicket>
    {
        protected override string GetTableName()
        {
            return "service_ticket";
        }

        protected override ServiceTicket ParseLine(DbDataReader reader)
        {
            return new ServiceTicket(
                reader.GetInt32(0),         // IdServiceTicket
                reader.GetInt32(1),         // IdEmployee
                reader.GetInt32(2),         // IdClient
                reader.GetDateTime(3),      // EntryDate
                reader.GetString(4),        // Details
                reader.GetString(5)        // Status
            );
        }

        protected override MySqlCommand ComposeDeleteCommand(ServiceTicket serviceTicket, MySqlConnection conn)
        {
            string query = "DELETE FROM service_ticket WHERE IdServiceTicket=@IdServiceTicket";
            MySqlCommand command = new MySqlCommand(query, conn);
            command.Parameters.AddWithValue("@IdServiceTicket", serviceTicket.IdServiceTicket);
            return command;
        }

        protected override MySqlCommand ComposeGetByIdCommand(ServiceTicket serviceTicket, MySqlConnection conn)
        {
            string query = "SELECT * FROM service_ticket WHERE IdServiceTicket=@IdServiceTicket";
            MySqlCommand command = new MySqlCommand(query, conn);
            command.Parameters.AddWithValue("@IdServiceTicket", serviceTicket.IdServiceTicket);
            return command;
        }

        protected override MySqlCommand ComposeInsertCommand(ServiceTicket serviceTicket, MySqlConnection conn)
        {
            string query = @"INSERT INTO service_ticket (IdEmployee, IdClient, EntryDate, Details, Status) 
                             VALUES (@IdEmployee, @IdClient, @EntryDate, @Details, @Status)";
            MySqlCommand command = new MySqlCommand(query, conn);
            command.Parameters.AddWithValue("@IdEmployee", serviceTicket.IdEmployee);
            command.Parameters.AddWithValue("@IdClient", serviceTicket.IdClient);
            command.Parameters.AddWithValue("@EntryDate", serviceTicket.EntryDate);
            command.Parameters.AddWithValue("@Details", serviceTicket.Details);
            command.Parameters.AddWithValue("@Status", serviceTicket.Status);
            return command;
        }

        protected override MySqlCommand ComposeUpdateCommand(ServiceTicket serviceTicket, MySqlConnection conn)
        {
            string query = @"UPDATE service_ticket 
                             SET IdEmployee=@IdEmployee, IdClient=@IdClient, EntryDate=@EntryDate, Details=@Details, Status=@Status
                             WHERE IdServiceTicket=@IdServiceTicket";
            MySqlCommand command = new MySqlCommand(query, conn);
            command.Parameters.AddWithValue("@IdServiceTicket", serviceTicket.IdServiceTicket);
            command.Parameters.AddWithValue("@IdEmployee", serviceTicket.IdEmployee);
            command.Parameters.AddWithValue("@IdClient", serviceTicket.IdClient);
            command.Parameters.AddWithValue("@EntryDate", serviceTicket.EntryDate);
            command.Parameters.AddWithValue("@Details", serviceTicket.Details);
            command.Parameters.AddWithValue("@Status", serviceTicket.Status);
            return command;
        }

        protected override Task<int> PreDeleteQuery(ServiceTicket serviceTicket)
        {
            // Additional logic before deleting a service ticket, if needed
            return Task.FromResult(1);
        }

        public async Task<int> GetActiveTicketsCount()
        {
            try
            {
                MySqlConnection conn = ConnectionPool.GetInstance().CheckOut();
                if (conn != null)
                {
                    try
                    {
                        string query = "SELECT COUNT(*) FROM service_ticket WHERE status = true;";
                        MySqlCommand command = new MySqlCommand(query, conn);
                        object result = await command.ExecuteScalarAsync();

                        if (result != null)
                        {
                            return Convert.ToInt32(result);
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.StackTrace);
                    }
                    finally
                    {
                        ConnectionPool.GetInstance().CheckIn(conn);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }

            return 0;
        }

        public async Task<int> GetFinishedTicketsCount()
        {
            try
            {
                MySqlConnection conn = ConnectionPool.GetInstance().CheckOut();
                if (conn != null)
                {
                    try
                    {
                        string query = "SELECT COUNT(*) FROM service_ticket WHERE status = false;";
                        MySqlCommand command = new MySqlCommand(query, conn);
                        object result = await command.ExecuteScalarAsync();

                        if (result != null)
                        {
                            return Convert.ToInt32(result);
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.StackTrace);
                    }
                    finally
                    {
                        ConnectionPool.GetInstance().CheckIn(conn);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }

            return 0;
        }

        public async Task<int> Insert(ServiceTicket serviceTicket)
        {
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                using (var conn = ConnectionPool.GetInstance().CheckOut())
                {
                    if (conn.State != ConnectionState.Open)
                    {
                        await conn.OpenAsync();
                    }

                    try
                    {
                        var command = ComposeInsertCommand(serviceTicket, conn);
                        await command.ExecuteNonQueryAsync();

                        // Retrieve the last inserted ID
                        var getLastInsertIdCommand = new MySqlCommand("SELECT LAST_INSERT_ID()", conn);
                        var lastInsertedId = await getLastInsertIdCommand.ExecuteScalarAsync();

                        scope.Complete();

                        // Check if the lastInsertedId is a valid integer
                        if (int.TryParse(lastInsertedId.ToString(), out int id))
                        {
                            return id;
                        }
                        else
                        {
                            // Log or handle the error appropriately
                            return -1;
                        }
                    }
                    catch (Exception ex)
                    {
                        // Log or handle the exception appropriately
                        return -1;
                    }
                }
            }
        }
    }
}
