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
	public class PostDAO : IPostDAO
	{
		private readonly Logger _log = new Logger("PostDAO");

		private Configuration config;
		private MySqlConnection con;

		private IUserLoginDAO loginDAO;

		public PostDAO()
		{
			InitializeComponents();
		}

		private void InitializeComponents()
		{
			config = Configuration.GetConfig();
			con = new MySqlConnection(config.GetConnection().GenerateString());
			con.Open();

			loginDAO = Context.GetUserLoginDAO();
		}

		public Post AddPost(Post post)
		{
			try
			{
				string query = "insert into post (name, topic, user, post_date) values (@name, @topic, " +
					"@user, @post_date); select LAST_INSERT_ID()";

				if (con.State == System.Data.ConnectionState.Closed)
					con.Open();
				using (MySqlCommand cmd = new MySqlCommand(query, con))
				{
					cmd.Parameters.AddWithValue("@name", post.Name);
					cmd.Parameters.AddWithValue("@topic", post.Topic);
					cmd.Parameters.AddWithValue("@user", post.User.Id);
					cmd.Parameters.AddWithValue("@post_date", post.PostDate);

					int id = Convert.ToInt32(cmd.ExecuteScalar());
					if (id > 0)
					{
						post.Id = id;
						return post;
					}
					else
						throw new Exception("Error occured while new Post inserting!");
				}
			}
			catch (Exception ex)
			{
				_log.Log(ex.Message + "\r\n" + ex.StackTrace);
				return null;
			}
		}

		public List<Post> GetAll()
		{
			try
			{
				string query = "select * from post order by post_date desc";

				if (con.State == System.Data.ConnectionState.Closed)
					con.Open();
				using (MySqlCommand cmd = new MySqlCommand(query, con))
				{
					var mdr = cmd.ExecuteReader();
					List<Post> posts = new List<Post>();
					while (mdr.Read())
					{
						Post post = new Post();
						FillPostWithMDR(post, mdr);
						posts.Add(post);
					}
					return posts;
				}
			}
			catch (Exception ex)
			{
				_log.Log(ex.Message + "\r\n" + ex.StackTrace);
				return null;
			}
		}

		public Post GetPostById(int id)
		{
			try
			{
				string query = "select * from post where id = @id";

				if (con.State == System.Data.ConnectionState.Closed)
					con.Open();
				using (MySqlCommand cmd = new MySqlCommand(query, con))
				{
					cmd.Parameters.AddWithValue("@id", id);

					var mdr = cmd.ExecuteReader();
					Post post = null;
					if (mdr.Read())
					{
						post = new Post();
						FillPostWithMDR(post, mdr);
					}
					return post;
				}
			}
			catch (Exception ex)
			{
				_log.Log(ex.Message + "\r\n" + ex.StackTrace);
				return null;
			}
		}

		public List<Post> GetPostByUser(Users user)
		{
			try
			{
				string query = "select * from post where user = @user order by post_date desc";

				if (con.State == System.Data.ConnectionState.Closed)
					con.Open();
				using (MySqlCommand cmd = new MySqlCommand(query, con))
				{
					cmd.Parameters.AddWithValue("@user", user.Id);

					var mdr = cmd.ExecuteReader();
					List<Post> posts = new List<Post>();
					while (mdr.Read())
					{
						Post post = new Post();
						FillPostWithMDR(post, mdr);
						posts.Add(post);
					}
					return posts;
				}
			}
			catch (Exception ex)
			{
				_log.Log(ex.Message + "\r\n" + ex.StackTrace);
				return null;
			}
		}

		public List<Post> GetPostWhereNameContain(string key, int offset, int next)
		{
			key = "%" + key + "%";
			try
			{
				string query = "select * from post where name like @key order by post_date desc limit @offset, @next";

				if (con.State == System.Data.ConnectionState.Closed)
					con.Open();
				using (MySqlCommand cmd = new MySqlCommand(query, con))
				{
					cmd.Parameters.AddWithValue("@key", key);
					cmd.Parameters.AddWithValue("@offset", offset);
					cmd.Parameters.AddWithValue("@next", next);

					var mdr = cmd.ExecuteReader();
					List<Post> posts = new List<Post>();
					while (mdr.Read())
					{
						Post post = new Post();
						FillPostWithMDR(post, mdr);
						posts.Add(post);
					}
					return posts;
				}
			}
			catch (Exception ex)
			{
				_log.Log(ex.Message + "\r\n" + ex.StackTrace);
				return null;
			}
		}

		public List<Post> GetPostWhereTopicContain(string key, int offset, int next)
		{
			key = "%" + key + "%";
			try
			{
				string query = "select * from post where topic like @key order by post_date desc limit @offset, @next";

				if (con.State == System.Data.ConnectionState.Closed)
					con.Open();
				using (MySqlCommand cmd = new MySqlCommand(query, con))
				{
					cmd.Parameters.AddWithValue("@key", key);
					cmd.Parameters.AddWithValue("@offset", offset);
					cmd.Parameters.AddWithValue("@next", next);

					var mdr = cmd.ExecuteReader();
					List<Post> posts = new List<Post>();
					while (mdr.Read())
					{
						Post post = new Post();
						FillPostWithMDR(post, mdr);
						posts.Add(post);
					}
					return posts;
				}
			}
			catch (Exception ex)
			{
				_log.Log(ex.Message + "\r\n" + ex.StackTrace);
				return null;
			}
		}

		public List<Post> GetPostWhereNameOrTopicContain(string key, int offset, int next)
		{
			key = "%" + key + "%";
			try
			{
				string query = "select * from post where name or topic like @key order by post_date desc limit @offset, @next";

				if (con.State == System.Data.ConnectionState.Closed)
					con.Open();
				using (MySqlCommand cmd = new MySqlCommand(query, con))
				{
					cmd.Parameters.AddWithValue("@key", key);
					cmd.Parameters.AddWithValue("@offset", offset);
					cmd.Parameters.AddWithValue("@next", next);

					var mdr = cmd.ExecuteReader();
					List<Post> posts = new List<Post>();
					while (mdr.Read())
					{
						Post post = new Post();
						FillPostWithMDR(post, mdr);
						posts.Add(post);
					}
					return posts;
				}
			}
			catch (Exception ex)
			{
				_log.Log(ex.Message + "\r\n" + ex.StackTrace);
				return null;
			}
		}

		public List<Post> GetAllByPagination(int offset, int next)
		{
			try
			{
				string query = "select * from post order by post_date desc limit @offset, @next";

				if (con.State == System.Data.ConnectionState.Closed)
					con.Open();
				using (MySqlCommand cmd = new MySqlCommand(query, con))
				{
					cmd.Parameters.AddWithValue("@offset", offset);
					cmd.Parameters.AddWithValue("@next", next);

					var mdr = cmd.ExecuteReader();
					List<Post> posts = new List<Post>();
					while (mdr.Read())
					{
						Post post = new Post();
						FillPostWithMDR(post, mdr);
						posts.Add(post);
					}
					return posts;
				}
			}
			catch (Exception ex)
			{
				_log.Log(ex.Message + "\r\n" + ex.StackTrace);
				return null;
			}
		}

		private void FillPostWithMDR(Post post, MySqlDataReader mdr)
		{
			post.Id = Convert.ToInt32(mdr.GetString(mdr.GetOrdinal("id")));
			post.Name = mdr.GetString(mdr.GetOrdinal("name"));
			post.Topic = mdr.GetString(mdr.GetOrdinal("topic"));

			int userId = Convert.ToInt32(mdr.GetString(mdr.GetOrdinal("user")));
			post.User = loginDAO.GetUserLoginById(userId);
		}

		public Post RemovePost(Post post)
		{
			try
			{
				string query = "delete from post where id = @id";

				if (con.State == System.Data.ConnectionState.Closed)
					con.Open();
				using (MySqlCommand cmd = new MySqlCommand(query, con))
				{
					cmd.Parameters.AddWithValue("@id", post.Id);

					if (cmd.ExecuteNonQuery() == 0)
						throw new Exception("Error occured while deleting data with this id: " + post.Id);
					return post;
				}
			}
			catch (Exception ex)
			{
				_log.Log(ex.Message + "\r\n" + ex.StackTrace);
				return null;
			}
		}

		public Post UpdatePost(Post post)
		{
			try
			{
				string query = "update post set name = @name, topic = @topic, user = @user, " +
					"post_date = @post_date where id = @id";

				if (con.State == System.Data.ConnectionState.Closed)
					con.Open();
				using (MySqlCommand cmd = new MySqlCommand(query, con))
				{
					cmd.Parameters.AddWithValue("@id", post.Id);
					cmd.Parameters.AddWithValue("@name", post.Name);
					cmd.Parameters.AddWithValue("@topic", post.Topic);
					cmd.Parameters.AddWithValue("@user", post.User.Id);
					cmd.Parameters.AddWithValue("@post_date", post.PostDate);

					if (cmd.ExecuteNonQuery() == 0)
						throw new Exception("Error occured while updating data with this id: " + post.Id);
					return post;
				}
			}
			catch (Exception ex)
			{
				_log.Log(ex.Message + "\r\n" + ex.StackTrace);
				return null;
			}
		}

		public int GetSize()
		{
			try
			{
				string query = "select count(id) from post";

				if (con.State == System.Data.ConnectionState.Closed)
					con.Open();
				using (MySqlCommand cmd = new MySqlCommand(query, con))
				{
					int size = Convert.ToInt32(cmd.ExecuteScalar());
					return size;
				}
			}
			catch (Exception ex)
			{
				_log.Log(ex.Message + "\r\n" + ex.StackTrace);
				return 0;
			}
		}
	}
}