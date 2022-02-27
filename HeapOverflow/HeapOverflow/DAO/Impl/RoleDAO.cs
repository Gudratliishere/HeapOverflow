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

		private Role userRole = null;
		private Role moderatorRole = null;

		public RoleDAO()
		{
			InitializeComponents();
		}

		private void InitializeComponents()
		{
			config = Configuration.GetConfig();
			con = new MySqlConnection(config.GetConnection().GenerateString());
			con.Open();
		}

		public Role GetRoleById(int id)
		{
			try
			{
				string query = "select * from role where id = @id";

				using (MySqlCommand cmd = new MySqlCommand(query, con))
				{
					cmd.Parameters.AddWithValue("@id", id);

					var mdr = cmd.ExecuteReader();
					if (mdr.Read())
					{
						Role role = new Role();
						FillRoleWithMDR(role, mdr);
						return role;
					}
					else
						throw new Exception("There is no any role with this id!");
				}
			}
			catch (Exception ex)
			{
				_log.Log(ex.Message + "\r\n" + ex.StackTrace);
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
			if (userRole != null)
				return userRole;

			userRole = new Role();
			try
			{
				string query = "select * from role where name = @name";

				using (MySqlCommand cmd = new MySqlCommand(query, con))
				{
					cmd.Parameters.AddWithValue("@name", "USER");

					var mdr = cmd.ExecuteReader();
					if (mdr.Read())
					{
						FillRoleWithMDR(userRole, mdr);
						return userRole;
					}
					else
						throw new Exception("There is no USER role!");
				}
			}
			catch (Exception ex)
			{
				_log.Log(ex.Message + "\r\n" + ex.StackTrace);
				return null;
			}
		}

		public Role GetModeratorRole()
		{
			if (moderatorRole != null)
				return moderatorRole;

			moderatorRole = new Role();
			try
			{
				string query = "select * from role where name = @name";

				using (MySqlCommand cmd = new MySqlCommand(query, con))
				{
					cmd.Parameters.AddWithValue("@name", "MODERATOR");

					var mdr = cmd.ExecuteReader();
					if (mdr.Read())
					{
						FillRoleWithMDR(moderatorRole, mdr);
						return moderatorRole;
					}
					else
						throw new Exception("There is no MODERATOR role!");
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