using HeapOverflow.Config;
using HeapOverflow.DAO.Inter;
using HeapOverflow.Entity;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace HeapOverflow.DAO.Impl
{
	public class UsersDAO : IUsersDAO
	{
		private readonly Logger _log = new Logger("UsersDAO");

		private Configuration config;
		private MySqlConnection con;

		public UsersDAO()
		{
			InitializeComponents();
		}

		private void InitializeComponents()
		{
			config = Configuration.GetConfig();
			con = new MySqlConnection(config.GetConnection().GenerateString());
			con.Open();
		}

		public Users AddUser(Users user)
		{
			try
			{
				string query = "insert into users (name, surname, photo, description, post) values (@name, @surname, @photo, @description, " +
					"@post); select LAST_INSERT_ID()";

				using (MySqlCommand cmd = new MySqlCommand(query, con))
				{
					cmd.Parameters.AddWithValue("@name", user.Name);
					cmd.Parameters.AddWithValue("@surname", user.Surname);
					cmd.Parameters.AddWithValue("@photo", user.Photo);
					cmd.Parameters.AddWithValue("@description", user.Description);
					cmd.Parameters.AddWithValue("@post", user.Post);

					int id = Convert.ToInt32(cmd.ExecuteScalar());
					if (id > 0)
					{
						user.Id = id;
						return user;
					}
					else
						throw new Exception("Error occured while new User inserting!");
				}
			}
			catch (Exception ex)
			{
				_log.Log(ex.Message + "\r\n" + ex.StackTrace);
				return null;
			}
		}

		public Users GetUserById(int id)
		{
			try
			{
				string query = "select * from users where id = @id";

				using (MySqlCommand cmd = new MySqlCommand(query, con))
				{
					cmd.Parameters.AddWithValue("@id", id);

					var mdr = cmd.ExecuteReader();
					Users user = null;
					if (mdr.Read())
					{
						user = new Users();
						FillUserWithMDRWith(user, mdr);
					}
					return user;
				}
			}
			catch (Exception ex)
			{
				_log.Log(ex.Message + "\r\n" + ex.StackTrace);
				return null;
			}
		}

		private void FillUserWithMDRWith(Users user, MySqlDataReader mdr)
		{
			user.Id = Convert.ToInt32(mdr.GetString(mdr.GetOrdinal("id")));
			user.Name = mdr.GetString(mdr.GetOrdinal("name"));
			user.Surname = mdr.GetString(mdr.GetOrdinal("surname"));

			if (mdr["photo"] == null)
			{
				var photoPath = Configuration.GetConfig()._defaultImage;
				FileStream fs = new FileStream(photoPath, FileMode.Open, FileAccess.Read);
				BinaryReader br = new BinaryReader(fs);
				user.Photo = br.ReadBytes((int)fs.Length);
			}
			else
				user.Photo = (byte[])mdr["photo"];
			user.Description = mdr.GetString(mdr.GetOrdinal("description"));
			user.Post = Convert.ToInt32(mdr.GetString(mdr.GetOrdinal("post")));
		}

		public Users RemoveUser(Users user)
		{
			try
			{
				string query = "delete from users where id = @id";

				using (MySqlCommand cmd = new MySqlCommand(query, con))
				{
					cmd.Parameters.AddWithValue("@id", user.Id);
					cmd.ExecuteNonQuery();

					return user;
				}
			}
			catch (Exception ex)
			{
				_log.Log(ex.Message + "\r\n" + ex.StackTrace);
				return null;
			}
		}

		public Users UpdateUser(Users user)
		{
			try
			{
				string query = "update users set name = @name, surname = @surname, photo = @photo, description = @description, post = @post " +
					"where id = @id";

				using (MySqlCommand cmd = new MySqlCommand(query, con))
				{
					cmd.Parameters.AddWithValue("@id", user.Id);
					cmd.Parameters.AddWithValue("@name", user.Name);
					cmd.Parameters.AddWithValue("@surname", user.Surname);
					cmd.Parameters.AddWithValue("@photo", user.Photo);
					cmd.Parameters.AddWithValue("@description", user.Description);
					cmd.Parameters.AddWithValue("@post", user.Post);
					cmd.ExecuteNonQuery();

					return user;
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