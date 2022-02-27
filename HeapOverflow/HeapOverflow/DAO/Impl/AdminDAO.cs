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
	public class AdminDAO : IAdminDAO
	{
		private readonly Logger _log = new Logger("AdminDAO");

		private Configuration config;
		private MySqlConnection con;

		public AdminDAO()
		{
			InitializeComponents();
		}

		private void InitializeComponents()
		{
			config = Configuration.GetConfig();
			con = new MySqlConnection(config.GetConnection().GenerateString());
			con.Open();
		}

		public Admin AddAdmin(Admin admin)
		{
			try
			{
				string query = "insert into admin (name, surname, email, password, status) values (@name, @surname, @email, @password, @status); " +
					"select LAST_INSERT_ID()";

				using (MySqlCommand cmd = new MySqlCommand(query, con))
				{
					cmd.Parameters.AddWithValue("@name", admin.Name);
					cmd.Parameters.AddWithValue("@surname", admin.Surname);
					cmd.Parameters.AddWithValue("@email", admin.Email);
					cmd.Parameters.AddWithValue("@password", admin.Password);
					cmd.Parameters.AddWithValue("@status", admin.Status);

					int id = Convert.ToInt32(cmd.ExecuteScalar());
					if (id > 0)
					{
						admin.Id = id;
						return admin;
					}
					else
						throw new Exception("Error occured while new Admin inserting!");
				}
			}
			catch (Exception ex)
			{
				_log.Log(ex.Message + "\r\n" + ex.StackTrace);
				return null;
			}
		}

		public List<Admin> GetAdminByStatus(int status)
		{
			try
			{
				string query = "select * from admin where status = @status";

				using (MySqlCommand cmd = new MySqlCommand(query, con))
				{
					cmd.Parameters.AddWithValue("@status", status);

					var mdr = cmd.ExecuteReader();
					List<Admin> admins = new List<Admin>();
					while (mdr.Read())
					{
						Admin admin = new Admin();
						FillAdminWithMDR(admin, mdr);
						admins.Add(admin);
					}
					return admins;
				}
			}
			catch (Exception ex)
			{
				_log.Log(ex.Message + "\r\n" + ex.StackTrace);
				return null;
			}
		}

		public Admin GetAdminByEmail(string email)
		{
			try
			{
				string query = "select * from admin where email = @email";

				using (MySqlCommand cmd = new MySqlCommand(query, con))
				{
					cmd.Parameters.AddWithValue("@email", email);

					var mdr = cmd.ExecuteReader();
					if (mdr.Read())
					{
						Admin admin = new Admin();
						FillAdminWithMDR(admin, mdr);
						return admin;
					}
					return null;
				}
			}
			catch (Exception ex)
			{
				_log.Log(ex.Message + "\r\n" + ex.StackTrace);
				return null;
			}
		}

		public Admin GetAdminById(int id)
		{
			try
			{
				string query = "select * from admin where id = @id";

				using (MySqlCommand cmd = new MySqlCommand(query, con))
				{
					cmd.Parameters.AddWithValue("@id", id);

					var mdr = cmd.ExecuteReader();
					Admin admin = null;
					if (mdr.Read())
					{
						admin = new Admin();
						FillAdminWithMDR(admin, mdr);
					}
					return admin;
				}
			}
			catch (Exception ex)
			{
				_log.Log(ex.Message + "\r\n" + ex.StackTrace);
				return null;
			}
		}

		private void FillAdminWithMDR(Admin admin, MySqlDataReader mdr)
		{
			admin.Id = Convert.ToInt32(mdr.GetString(mdr.GetOrdinal("id")));
			admin.Name = mdr.GetString(mdr.GetOrdinal("name"));
			admin.Surname = mdr.GetString(mdr.GetOrdinal("surname"));
			admin.Email = mdr.GetString(mdr.GetOrdinal("email"));
			admin.Password = mdr.GetString(mdr.GetOrdinal("password"));
			admin.Status = Convert.ToInt32(mdr.GetString(mdr.GetOrdinal("status")));
		}

		public Admin RemoveAdmin(Admin admin)
		{
			try
			{
				string query = "delete from admin where id = @id";

				using (MySqlCommand cmd = new MySqlCommand(query, con))
				{
					cmd.Parameters.AddWithValue("@id", admin.Id);
					cmd.ExecuteNonQuery();

					return admin;
				}
			}
			catch (Exception ex)
			{
				_log.Log(ex.Message + "\r\n" + ex.StackTrace);
				return null;
			}
		}

		public Admin UpdateAdmin(Admin admin)
		{
			try
			{
				string query = "update admin set name = @name, surname = @surname, email = @email, password = @password, status = @status where id = @id";

				using (MySqlCommand cmd = new MySqlCommand(query, con))
				{
					cmd.Parameters.AddWithValue("@id", admin.Id);
					cmd.Parameters.AddWithValue("@name", admin.Name);
					cmd.Parameters.AddWithValue("@surname", admin.Surname);
					cmd.Parameters.AddWithValue("@email", admin.Email);
					cmd.Parameters.AddWithValue("@password", admin.Password);
					cmd.Parameters.AddWithValue("@status", admin.Status);

					cmd.ExecuteNonQuery();

					return admin;
				}
			}
			catch (Exception ex)
			{
				_log.Log(ex.Message + "\r\n" + ex.StackTrace);
				return null;
			}
		}
	}
}