using HeapOverflow.Config;
using HeapOverflow.DAO.Inter;
using HeapOverflow.Entity;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HeapOverflow.DAO.Impl
{
    public class RoleDAO : IRoleDAO
    {
        private readonly Logger _log = new Logger("RoleDAO");

        private Configuration config;
        private MySqlConnection con;
        private MySqlCommand cmd;

        public RoleDAO()
        {
            InitializeComponents();
        }

        private void InitializeComponents()
        {
            config = Configuration.GetConfig();
            con = new MySqlConnection(config.GetConnection().GenerateString());
            cmd = new MySqlCommand();
            cmd.Connection = con;
        }

        public Role GetRoleById(int id)
        {
            try
            {
                string query = "select * from role where id = @id";

                con.Open();
                cmd.Parameters.Clear();
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@id", id);

                var mdr = cmd.ExecuteReader();
                if (mdr.Read())
                {
                    Role role = new Role();
                    FillRoleWithMDR(role, mdr);
                    con.Close();
                    return role;
                }
                else
                    throw new Exception("There is no any role with this id!");
            }
            catch (Exception ex)
            {
                _log.Log(ex.Message + "\r\n" + ex.StackTrace);
                con.Close();
                return null;
            }
        }

        private void FillRoleWithMDR(Role role, MySqlDataReader mdr)
        {
            role.Id = Convert.ToInt32(mdr.GetString(mdr.GetOrdinal("id")));
            role.Name = mdr.GetString(mdr.GetOrdinal("name"));
            role.Description = mdr.GetString(mdr.GetOrdinal("description"));
        }

        public Role GetUserRole()
        {
            try
            {
                string query = "select * from role where name = @name";

                con.Open();
                cmd.Parameters.Clear();
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@name", "USER");

                var mdr = cmd.ExecuteReader();
                if (mdr.Read())
                {
                    Role role = new Role();
                    FillRoleWithMDR(role, mdr);
                    con.Close();
                    return role;
                }
                else
                    throw new Exception("There is no USER role!");
            }
            catch (Exception ex)
            {
                _log.Log(ex.Message + "\r\n" + ex.StackTrace);
                con.Close();
                return null;
            }
        }

        public Role GetModeratorRole()
        {
            try
            {
                string query = "select * from role where name = @name";

                con.Open();
                cmd.Parameters.Clear();
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@name", "MODERATOR");

                var mdr = cmd.ExecuteReader();
                if (mdr.Read())
                {
                    Role role = new Role();
                    FillRoleWithMDR(role, mdr);
                    con.Close();
                    return role;
                }
                else
                    throw new Exception("There is no MODERATOR role!");
            }
            catch (Exception ex)
            {
                _log.Log(ex.Message + "\r\n" + ex.StackTrace);
                con.Close();
                return null;
            }
        }
    }
}