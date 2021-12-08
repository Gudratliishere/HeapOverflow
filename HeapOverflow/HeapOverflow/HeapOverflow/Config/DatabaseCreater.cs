using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HeapOverflow.Config
{
    public class DatabaseCreater
    {
        private static readonly Logger _log = new Logger("DatabaseCreater");

        public static Connection Connection { get; set; }

        public static void CreateDatabase()
        {
            try
            {
                string query = String.Format("CREATE DATABASE IF NOT EXISTS {0}", Connection.Database);
                string conString = String.Format("host = {0}; port = {1}; username = {2}; password = {3};", Connection.Host, Connection.Port,
                    Connection.Decrypt(Connection.Username), Connection.Decrypt(Connection.Password));
                using (var con = new MySqlConnection(conString))
                {
                    con.Open();
                    using (var cmd = new MySqlCommand(query, con))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                _log.Log(ex.Message + "\r\n" + ex.StackTrace);
                return;
            }
        }
    }
}