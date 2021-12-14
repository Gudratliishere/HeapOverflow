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
    public class UserLoginDAO : IUserLoginDAO
    {
        private readonly Logger _log = new Logger("UserLoginDAO");

        private Configuration config;
        private MySqlConnection con;
        private MySqlCommand cmd;

        private IRoleDAO roleDAO;
        private IUsersDAO usersDAO;

        public UserLoginDAO()
        {
            InitializeComponents();
        }

        private void InitializeComponents()
        {
            config = Configuration.GetConfig();
            con = new MySqlConnection(config.GetConnection().GenerateString());
            cmd = new MySqlCommand();
            cmd.Connection = con;

            roleDAO = Context.GetRoleDAO();
            usersDAO = Context.GetUsersDAO();
        }

        public UserLogin AddUserLogin(UserLogin login)
        {
            try
            {
                string query = "insert into user_login (username, email, password, status, role, user) values (@username, @email, @password, @status, " +
                    "@role, @user); select LAST_INSERT_ID()";

                con.Open();
                cmd.Parameters.Clear();
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@username", login.Username);
                cmd.Parameters.AddWithValue("@email", login.Email);
                cmd.Parameters.AddWithValue("@password", login.Password);
                cmd.Parameters.AddWithValue("@status", login.Status);
                cmd.Parameters.AddWithValue("@role", login.Role.Id);
                cmd.Parameters.AddWithValue("@user", login.User.Id);

                int id = Convert.ToInt32(cmd.ExecuteScalar());
                if (id > 0)
                {
                    login.Id = id;
                    con.Close();
                    return login;
                }
                else
                    throw new Exception("Error occured while new UserLogin inserting!");
            }
            catch (Exception ex)
            {
                _log.Log(ex.Message + "\r\n" + ex.StackTrace);
                con.Close();
                return null;
            }
        }

        public List<UserLogin> GetAll()
        {
            try
            {
                string query = "select * from user_login";

                con.Open();
                cmd.Parameters.Clear();
                cmd.CommandText = query;

                var mdr = cmd.ExecuteReader();
                List<UserLogin> logins = new List<UserLogin>();
                while (mdr.Read())
                {
                    UserLogin login = new UserLogin();
                    FillUserLoginWithMDR(login, mdr);
                    logins.Add(login);
                }
                con.Close();
                return logins;
            }
            catch (Exception ex)
            {
                _log.Log(ex.Message + "\r\n" + ex.StackTrace);
                con.Close();
                return null;
            }
        }

        public UserLogin GetUserLoginByEmail(string email)
        {
            try
            {
                string query = "select * from user_login where email = @email";

                con.Open();
                cmd.Parameters.Clear();
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@email", email);

                var mdr = cmd.ExecuteReader();
                UserLogin login = null;
                if (mdr.Read())
                {
                    login = new UserLogin();
                    FillUserLoginWithMDR(login, mdr);
                }
                con.Close();
                return login;
            }
            catch (Exception ex)
            {
                _log.Log(ex.Message + "\r\n" + ex.StackTrace);
                con.Close();
                return null;
            }
        }

        public UserLogin GetUserLoginById(int id)
        {
            try
            {
                string query = "select * from user_login where id = @id";

                con.Open();
                cmd.Parameters.Clear();
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@id", id);

                var mdr = cmd.ExecuteReader();
                UserLogin login = null;
                if (mdr.Read())
                {
                    login = new UserLogin();
                    FillUserLoginWithMDR(login, mdr);
                }
                con.Close();
                return login;
            }
            catch (Exception ex)
            {
                _log.Log(ex.Message + "\r\n" + ex.StackTrace);
                con.Close();
                return null;
            }
        }

        public List<UserLogin> GetUserLoginByRole(Role role)
        {
            try
            {
                string query = "select * from user_login where role = @role";

                con.Open();
                cmd.Parameters.Clear();
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@role", role.Id);

                var mdr = cmd.ExecuteReader();
                List<UserLogin> logins = new List<UserLogin>();
                while (mdr.Read())
                {
                    UserLogin login = new UserLogin();
                    FillUserLoginWithMDR(login, mdr);
                    logins.Add(login);
                }
                con.Close();
                return logins;
            }
            catch (Exception ex)
            {
                _log.Log(ex.Message + "\r\n" + ex.StackTrace);
                con.Close();
                return null;
            }
        }

        public List<UserLogin> GetUserLoginByStatus(int status)
        {
            try
            {
                string query = "select * from user_login where status = @status";

                con.Open();
                cmd.Parameters.Clear();
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@status", status);

                var mdr = cmd.ExecuteReader();
                List<UserLogin> logins = new List<UserLogin>();
                while (mdr.Read())
                {
                    UserLogin login = new UserLogin();
                    FillUserLoginWithMDR(login, mdr);
                    logins.Add(login);
                }
                con.Close();
                return logins;
            }
            catch (Exception ex)
            {
                _log.Log(ex.Message + "\r\n" + ex.StackTrace);
                con.Close();
                return null;
            }
        }

        public UserLogin GetUserLoginByUser(Users user)
        {
            try
            {
                string query = "select * from user_login where user = @user";

                con.Open();
                cmd.Parameters.Clear();
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@user", user.Id);

                var mdr = cmd.ExecuteReader();
                UserLogin login = null;
                if (mdr.Read())
                {
                    login = new UserLogin();
                    FillUserLoginWithMDR(login, mdr);
                }
                con.Close();
                return login;
            }
            catch (Exception ex)
            {
                _log.Log(ex.Message + "\r\n" + ex.StackTrace);
                con.Close();
                return null;
            }
        }

        public UserLogin GetUserLoginByUsername(string username)
        {
            try
            {
                string query = "select * from user_login where username = @username";

                con.Open();
                cmd.Parameters.Clear();
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@username", username);

                var mdr = cmd.ExecuteReader();
                UserLogin login = null;
                if (mdr.Read())
                {
                    login = new UserLogin();
                    FillUserLoginWithMDR(login, mdr);
                }
                con.Close();
                return login;
            }
            catch (Exception ex)
            {
                _log.Log(ex.Message + "\r\n" + ex.StackTrace);
                con.Close();
                return null;
            }
        }

        private void FillUserLoginWithMDR(UserLogin login, MySqlDataReader mdr)
        {
            login.Id = Convert.ToInt32(mdr.GetString(mdr.GetOrdinal("id")));
            login.Username = mdr.GetString(mdr.GetOrdinal("username"));
            login.Email = mdr.GetString(mdr.GetOrdinal("email"));
            login.Password = mdr.GetString(mdr.GetOrdinal("password"));
            login.Status = Convert.ToInt32(mdr.GetString(mdr.GetOrdinal("status")));

            int roleId, userId;
            if (!int.TryParse(mdr.GetString(mdr.GetOrdinal("role")), out roleId))
                throw new Exception("Role id is null or is not integer!");
            login.Role = roleDAO.GetRoleById(roleId);

            if (!int.TryParse(mdr.GetString(mdr.GetOrdinal("user")), out userId))
                throw new Exception("User id is null or is not integer!");
            login.User = usersDAO.GetUserById(userId);

        }

        public UserLogin RemoveUserLogin(UserLogin login)
        {
            try
            {
                string query = "delete from user_login where id = @id";

                con.Open();
                cmd.Parameters.Clear();
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@id", login.Id);

                if (cmd.ExecuteNonQuery() == 0)
                    throw new Exception("Error occured while deleting column with this id: " + login.Id);

                con.Close();
                return login;
            }
            catch (Exception ex)
            {
                _log.Log(ex.Message + "\r\n" + ex.StackTrace);
                con.Close();
                return null;
            }
        }

        public UserLogin UpdateUserLogin(UserLogin login)
        {
            try
            {
                string query = "update user_login set username = @username, email = @email, password = @password, status = @status, role = @role, user = @user " +
                    "where id = @id";

                con.Open();
                cmd.Parameters.Clear();
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@id", login.Id);
                cmd.Parameters.AddWithValue("@username", login.Username);
                cmd.Parameters.AddWithValue("@email", login.Email);
                cmd.Parameters.AddWithValue("@password", login.Password);
                cmd.Parameters.AddWithValue("@status", login.Status);
                cmd.Parameters.AddWithValue("@role", login.Role.Id);
                cmd.Parameters.AddWithValue("@user", login.User.Id);

                if (cmd.ExecuteNonQuery() == 0)
                    throw new Exception("Error occured while updating column with this id: " + login.Id);

                con.Close();
                return login;
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