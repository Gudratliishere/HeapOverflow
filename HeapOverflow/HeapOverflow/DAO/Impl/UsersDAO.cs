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
    public class UsersDAO : IUsersDAO
    {
        private readonly Logger _log = new Logger("UsersDAO");

        private Configuration config;
        private MySqlConnection con;
        private MySqlCommand cmd;

        public UsersDAO()
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

        public Users AddUser(Users user)
        {
            try
            {
                string query = "insert into users (name, surname, photo, description, post) values (@name, @surname, @photo, @description, " +
                    "@post); select LAST_INSERT_ID()";

                con.Open();
                cmd.Parameters.Clear();
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@name", user.Name);
                cmd.Parameters.AddWithValue("@surname", user.Surname);
                cmd.Parameters.AddWithValue("@photo", user.Photo);
                cmd.Parameters.AddWithValue("@description", user.Description);
                cmd.Parameters.AddWithValue("@post", user.Post);

                int id = Convert.ToInt32(cmd.ExecuteScalar());
                if (id > 0)
                {
                    user.Id = id;
                    con.Close();
                    return user;
                }
                else
                    throw new Exception("Error occured while new User inserting!");
            }
            catch (Exception ex)
            {
                _log.Log(ex.Message + "\r\n" + ex.StackTrace);
                con.Close();
                return null;
            }
        }

        public Users GetUserById(int id)
        {
            try
            {
                string query = "select * from users where id = @id";

                con.Open();
                cmd.Parameters.Clear();
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@id", id);

                var mdr = cmd.ExecuteReader();
                Users user = null;
                if (mdr.Read())
                {
                    user = new Users();
                    FillUserWithMDRWith(user, mdr);
                }
                con.Close();
                return user;
            }
            catch (Exception ex)
            {
                _log.Log(ex.Message + "\r\n" + ex.StackTrace);
                con.Close();
                return null;
            }
        }

        private void FillUserWithMDRWith(Users user, MySqlDataReader mdr)
        {
            user.Id = Convert.ToInt32(mdr.GetString(mdr.GetOrdinal("id")));
            user.Name = mdr.GetString(mdr.GetOrdinal("name"));
            user.Surname = mdr.GetString(mdr.GetOrdinal("surname"));
            user.Photo = (byte[])mdr["photo"];
            user.Description = mdr.GetString(mdr.GetOrdinal("description"));
            user.Post = Convert.ToInt32(mdr.GetString(mdr.GetOrdinal("post")));
        }

        public Users RemoveUser(Users user)
        {
            try
            {
                string query = "delete from users where id = @id";

                con.Open();
                cmd.Parameters.Clear();
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@id", user.Id);
                cmd.ExecuteNonQuery();

                con.Close();
                return user;
            }
            catch (Exception ex)
            {
                _log.Log(ex.Message + "\r\n" + ex.StackTrace);
                con.Close();
                return null;
            }
        }

        public Users UpdateUser(Users user)
        {
            try
            {
                string query = "update users set name = @name, surname = @surname, photo = @photo, description = @description, post = @post " +
                    "where id = @id";

                con.Open();
                cmd.Parameters.Clear();
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@id", user.Id);
                cmd.Parameters.AddWithValue("@name", user.Name);
                cmd.Parameters.AddWithValue("@surname", user.Surname);
                cmd.Parameters.AddWithValue("@photo", user.Photo);
                cmd.Parameters.AddWithValue("@description", user.Description);
                cmd.Parameters.AddWithValue("@post", user.Post);
                cmd.ExecuteNonQuery();

                con.Close();
                return user;
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