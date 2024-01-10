using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data.MySqlClient;

using TruckCentreWF.Util;

namespace TruckCentreWF.Model.Dao
{
    public abstract class BaseDAO<T>
    {
        protected abstract string GetTableName();

        protected abstract T ParseLine(DbDataReader reader);

        protected abstract MySqlCommand ComposeGetByIdCommand(T t, MySqlConnection conn);

        protected abstract MySqlCommand ComposeInsertCommand(T t, MySqlConnection conn);

        protected abstract MySqlCommand ComposeUpdateCommand(T t, MySqlConnection conn);

        protected abstract MySqlCommand ComposeDeleteCommand(T t, MySqlConnection conn);

        public async Task<T> GetById(T t)
        {
            MySqlConnection conn = ConnectionPool.GetInstance().CheckOut();
            if (conn != null)
            {
                try
                {
                    MySqlCommand command = ComposeGetByIdCommand(t, conn);
                    DbDataReader reader = await command.ExecuteReaderAsync();

                    if (reader.Read())
                    {
                        return ParseLine(reader);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.StackTrace);
                    return default(T);
                }
                finally
                {
                    ConnectionPool.GetInstance().CheckIn(conn);
                }
            }
            return default(T);
        }

        public async Task<List<T>> GetAll()
        {
            MySqlConnection conn = ConnectionPool.GetInstance().CheckOut();
            if (conn != null)
            {
                List<T> list = new List<T>();

                try
                {
                    string query = "SELECT * FROM " + GetTableName() + ";";
                    MySqlCommand command = new MySqlCommand(query, conn);
                    DbDataReader reader = await command.ExecuteReaderAsync();

                    while (reader.Read())
                    {
                        list.Add(ParseLine(reader));
                    }

                    return list;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.StackTrace);
                    return null;
                }
                finally
                {
                    ConnectionPool.GetInstance().CheckIn(conn);
                }
            }
            else
            {
                Console.WriteLine("No connection.");
            }

            return null;
        }

        public async Task<int> Insert(T t)
        {
            MySqlConnection conn = ConnectionPool.GetInstance().CheckOut();
            int result = 0;
            if (conn != null)
            {
                try
                {
                    MySqlCommand command = ComposeInsertCommand(t, conn);
                    result = await command.ExecuteNonQueryAsync();

                    if (result > 0) await PostInsertQuery(t, command.LastInsertedId, conn);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.StackTrace);
                    result = -1;
                }
                finally
                {
                    ConnectionPool.GetInstance().CheckIn(conn);
                }
            }
            return result;
        }

        protected async virtual Task PostInsertQuery(T t, long lastInsertedId, MySqlConnection conn)
        {
            // Implements post-insert logic if needed
        }

        public async Task<int> Update(T t)
        {
            MySqlConnection conn = ConnectionPool.GetInstance().CheckOut();
            int result = 0;
            if (conn != null)
            {
                try
                {
                    MySqlCommand command = ComposeUpdateCommand(t, conn);
                    result = await command.ExecuteNonQueryAsync();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.StackTrace);
                    result = -1;
                }
                finally
                {
                    ConnectionPool.GetInstance().CheckIn(conn);
                }
            }
            return result;
        }

        protected virtual Task<int> PreDeleteQuery(T t)
        {
            // Task result is '1' by default, allowing the deletion to proceed
            return Task.FromResult(1);
        }

        public async Task<int> Delete(T t)
        {
            int preQueryResult = await PreDeleteQuery(t);
            if (preQueryResult != 1)
                return 0;

            MySqlConnection conn = ConnectionPool.GetInstance().CheckOut();
            int result = 0;
            if (conn != null)
            {
                try
                {
                    MySqlCommand command = ComposeDeleteCommand(t, conn);
                    result = await command.ExecuteNonQueryAsync();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.StackTrace);
                    result = -1;
                }
                finally
                {
                    ConnectionPool.GetInstance().CheckIn(conn);
                }
            }
            return result;
        }
    }
}
