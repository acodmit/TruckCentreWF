using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

using TruckCentre.Model.Dto;
using TruckCentreWF.Model.Dao;
using TruckCentreWF.Util;

namespace TruckCentre.Model.Dao
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
                reader.GetInt32(1),         // IdAccount
                reader.GetDateTime(2),      // EntryDate
                reader.GetString(3),        // Details
                reader.GetString(4),        // Status
                reader.GetInt32(5)          // EmployeeIdAccount
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
            string query = @"INSERT INTO service_ticket (IdAccount, EntryDate, Details, Status, Employee_IdAccount) 
                             VALUES (@IdAccount, @EntryDate, @Details, @Status, @EmployeeIdAccount)";
            MySqlCommand command = new MySqlCommand(query, conn);
            command.Parameters.AddWithValue("@IdAccount", serviceTicket.IdAccount);
            command.Parameters.AddWithValue("@EntryDate", serviceTicket.EntryDate);
            command.Parameters.AddWithValue("@Details", serviceTicket.Details);
            command.Parameters.AddWithValue("@Status", serviceTicket.Status);
            command.Parameters.AddWithValue("@EmployeeIdAccount", serviceTicket.EmployeeIdAccount);
            return command;
        }

        protected override MySqlCommand ComposeUpdateCommand(ServiceTicket serviceTicket, MySqlConnection conn)
        {
            string query = @"UPDATE service_ticket 
                             SET IdAccount=@IdAccount, EntryDate=@EntryDate, Details=@Details, Status=@Status, Employee_IdAccount=@EmployeeIdAccount 
                             WHERE IdServiceTicket=@IdServiceTicket";
            MySqlCommand command = new MySqlCommand(query, conn);
            command.Parameters.AddWithValue("@IdServiceTicket", serviceTicket.IdServiceTicket);
            command.Parameters.AddWithValue("@IdAccount", serviceTicket.IdAccount);
            command.Parameters.AddWithValue("@EntryDate", serviceTicket.EntryDate);
            command.Parameters.AddWithValue("@Details", serviceTicket.Details);
            command.Parameters.AddWithValue("@Status", serviceTicket.Status);
            command.Parameters.AddWithValue("@EmployeeIdAccount", serviceTicket.EmployeeIdAccount);
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

    }
}
