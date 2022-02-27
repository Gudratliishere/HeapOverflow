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
	public class CommentDAO : ICommentDAO
	{
		private readonly Logger _log = new Logger("CommentDAO");

		private Configuration config;
		private MySqlConnection con;

		private IUserLoginDAO loginDAO;
		private IPostDAO postDAO;

		public CommentDAO()
		{
			InitializeComponents();
		}

		private void InitializeComponents()
		{
			config = Configuration.GetConfig();
			con = new MySqlConnection(config.GetConnection().GenerateString());
			con.Open();

			loginDAO = Context.GetUserLoginDAO();
			postDAO = Context.GetPostDAO();
		}

		public Comment AddComment(Comment comment)
		{
			try
			{
				string query = "insert into comment (user, post, topic, post_date) values (@user, @post, @topic, @post_date); select LAST_INSERT_ID()";

				using (MySqlCommand cmd = new MySqlCommand(query, con))
				{
					cmd.Parameters.AddWithValue("@user", comment.User.Id);
					cmd.Parameters.AddWithValue("@post", comment.Post.Id);
					cmd.Parameters.AddWithValue("@topic", comment.Topic);
					cmd.Parameters.AddWithValue("@post_date", comment.PostDate);

					int id = Convert.ToInt32(cmd.ExecuteScalar());
					if (id > 0)
					{
						comment.Id = id;
						return comment;
					}
					else
						throw new Exception("Error occured while new Comment inserting!");
				}
			}
			catch (Exception ex)
			{
				_log.Log(ex.Message + "\r\n" + ex.StackTrace);
				return null;
			}
		}

		public List<Comment> GetCommentsByPost(Post post)
		{
			try
			{
				string query = "select * from comment where post = @post order by post_date";

				using (MySqlCommand cmd = new MySqlCommand(query, con))
				{
					cmd.Parameters.AddWithValue("@post", post.Id);

					var mdr = cmd.ExecuteReader();
					List<Comment> comments = new List<Comment>();
					while (mdr.Read())
					{
						Comment comment = new Comment();
						FillCommentWithMDR(comment, mdr);
						comments.Add(comment);
					}
					return comments;
				}
			}
			catch (Exception ex)
			{
				_log.Log(ex.Message + "\r\n" + ex.StackTrace);
				return null;
			}
		}

		public int GetCommentsSizeByPost(Post post)
		{
			try
			{
				string query = "select count(id) from comment where post = @post";

				using (MySqlCommand cmd = new MySqlCommand(query, con))
				{
					cmd.Parameters.AddWithValue("@post", post.Id);

					var mdr = cmd.ExecuteReader();
					if (mdr.Read())
					{
						return int.Parse(mdr.GetString(0));
					}
					else
						throw new Exception("Can not fetch count of comments.");
				}
			}
			catch (Exception ex)
			{
				_log.Log(ex.Message + "\r\n" + ex.StackTrace);
				return 0;
			}
		}

		private void FillCommentWithMDR(Comment comment, MySqlDataReader mdr)
		{
			comment.Id = Convert.ToInt32(mdr.GetString(mdr.GetOrdinal("id")));
			comment.Topic = mdr.GetString(mdr.GetOrdinal("topic"));

			int userId = Convert.ToInt32(mdr.GetString(mdr.GetOrdinal("user")));
			comment.User = loginDAO.GetUserLoginById(userId);

			int postId = Convert.ToInt32(mdr.GetString(mdr.GetOrdinal("post")));
			comment.Post = postDAO.GetPostById(postId);
		}

		public void RemoveComment(int id)
		{
			try
			{
				string query = "delete from comment where id = @id";

				using (MySqlCommand cmd = new MySqlCommand(query, con))
				{
					cmd.Parameters.AddWithValue("@id", id);

					if (cmd.ExecuteNonQuery() == 0)
						throw new Exception("Error occured while deleting data with this id: " + id);
				}
			}
			catch (Exception ex)
			{
				_log.Log(ex.Message + "\r\n" + ex.StackTrace);
			}
		}

		public Comment UpdateComment(Comment comment)
		{
			try
			{
				string query = "update comment set user = @user, post = @post, topic = @topic, post_date = @post_date where id = @id";

				using (MySqlCommand cmd = new MySqlCommand(query, con))
				{
					cmd.Parameters.AddWithValue("@id", comment.Id);
					cmd.Parameters.AddWithValue("@user", comment.User.Id);
					cmd.Parameters.AddWithValue("@post", comment.Post.Id);
					cmd.Parameters.AddWithValue("@topic", comment.Topic);
					cmd.Parameters.AddWithValue("@post_date", comment.PostDate);

					if (cmd.ExecuteNonQuery() == 0)
						throw new Exception("Error occured while updating data with this id: " + comment.Id);
					return comment;
				}
			}
			catch (Exception ex)
			{
				_log.Log(ex.Message + "\r\n" + ex.StackTrace);
				return null;
			}
		}

		public void RemoveCommentByPost(int postId)
		{
			try
			{
				string query = "delete from comment where post = @post";

				using (MySqlCommand cmd = new MySqlCommand(query, con))
				{
					cmd.Parameters.AddWithValue("@post", postId);

					if (cmd.ExecuteNonQuery() == 0)
						throw new Exception("Error occured while deleting data with this postId: " + postId);
				}
			}
			catch (Exception ex)
			{
				_log.Log(ex.Message + "\r\n" + ex.StackTrace);
			}
		}

		public Comment GetCommentById(int id)
		{
			try
			{
				string query = "select * from comment where id = @id";

				using (MySqlCommand cmd = new MySqlCommand(query, con))
				{
					cmd.Parameters.AddWithValue("@id", id);

					var mdr = cmd.ExecuteReader();
					Comment comment = null;
					if (mdr.Read())
					{
						comment = new Comment();
						FillCommentWithMDR(comment, mdr);
					}
					return comment;
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