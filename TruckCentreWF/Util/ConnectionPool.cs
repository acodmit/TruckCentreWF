using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TruckCentreWF.Util
{
    public class ConnectionPool
    {
        private static ConnectionPool s_instance = null;
        private static List<MySqlConnection> s_freeConnections;
        private static List<MySqlConnection> s_usedConnections;

        // Singleton pattern: ensures only one instance of ConnectionPool
        public static ConnectionPool GetInstance()
        {
            if (s_instance == null)
            {
                s_instance = new ConnectionPool();
            }
            return s_instance;
        }

        // Private constructor to enforce Singleton pattern and initialize connection lists
        private ConnectionPool()
        {
            s_freeConnections = new List<MySqlConnection>();
            s_usedConnections = new List<MySqlConnection>();

            // Pre-connect a certain number of connections on pool initialization
            for (int i = 0; i < Constants.PreconnectCount; i++)
            {
                s_freeConnections.Add(new MySqlConnection(Constants.ConnString));
            }
        }

        // Check out a connection from the pool
        public MySqlConnection CheckOut()
        {
            MySqlConnection conn = null;
            if (s_freeConnections.Count > 0)
            {
                conn = s_freeConnections[0];
                conn.Open();
                s_freeConnections.RemoveAt(0);
                s_usedConnections.Add(conn);
            }
            else
            {
                // If no free connections, create a new one
                conn = new MySqlConnection(Constants.ConnString);
                conn.Open();
                s_usedConnections.Add(conn);
            }
            return conn;
        }

        // Check in a connection back to the pool
        public void CheckIn(MySqlConnection conn)
        {
            if (conn == null)
            {
                return;
            }

            // If the connection was in use, close it and return it to the free connections list
            if (s_usedConnections.Remove(conn))
            {
                conn.Close();
                s_freeConnections.Add(new MySqlConnection(Constants.ConnString));

                // Ensure the number of free connections doesn't exceed the maximum allowed
                while (s_freeConnections.Count > Constants.MaxIdleConnections)
                {
                    int lastOne = s_freeConnections.Count - 1;
                    MySqlConnection c = s_freeConnections[lastOne];
                    s_freeConnections.RemoveAt(lastOne);
                    c.Close();
                }
            }
        }
    }

}
