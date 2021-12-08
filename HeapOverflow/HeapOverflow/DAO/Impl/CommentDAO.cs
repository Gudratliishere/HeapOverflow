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
        private MySqlCommand cmd;

        private IUsersDAO usersDAO;
        private IPostDAO postDAO;

        public CommentDAO()
        {
            InitializeComponents();
        }

        private void InitializeComponents()
        {
            config = Configuration.GetConfig();
            con = new MySqlConnection(config.GetConnection().GenerateString());
            cmd = new MySqlCommand();
            cmd.Connection = con;

            usersDAO = Context.GetUsersDAO();
            postDAO = Context.GetPostDAO();
        }

        public Comment AddComment(Comment comment)
        {
            try
            {
                string query = "insert into comment (user, post, topic, like_count, _dislike_count, post_date) values (@user, @post, @topic, @like_count," +
                    " @dislike_count, @post_date); select LAST_INSERT_ID()";

                con.Open();
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@user", comment.User.Id);
                cmd.Parameters.AddWithValue("@post", comment.Post.Id);
                cmd.Parameters.AddWithValue("@topic", comment.Topic);
                cmd.Parameters.AddWithValue("@like_count", comment.LikeCount);
                cmd.Parameters.AddWithValue("@dislike_count", comment.DislikeCount);
                cmd.Parameters.AddWithValue("@post_date", comment.PostDate);

                int id = Convert.ToInt32(cmd.ExecuteScalar());
                if (id > 0)
                {
                    comment.Id = id;
                    con.Close();
                    return comment;
                }
                else
                    throw new Exception("Error occured while new Comment inserting!");
            }
            catch (Exception ex)
            {
                _log.Log(ex.Message + "\r\n" + ex.StackTrace);
                con.Close();
                return null;
            }
        }

        public List<Comment> GetCommentsByPost(Post post)
        {
            try
            {
                string query = "select * from comment";

                con.Open();
                cmd.CommandText = query;

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
            catch (Exception ex)
            {
                _log.Log(ex.Message + "\r\n" + ex.StackTrace);
                con.Close();
                return null;
            }
        }

        public List<Comment> GetCommentsByUser(Users user)
        {
            try
            {
                string query = "select * from comment where user = @user";

                con.Open();
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@user", user.Id);

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
            catch (Exception ex)
            {
                _log.Log(ex.Message + "\r\n" + ex.StackTrace);
                con.Close();
                return null;
            }
        }

        private void FillCommentWithMDR(Comment comment, MySqlDataReader mdr)
        {
            comment.Id = Convert.ToInt32(mdr.GetString(mdr.GetOrdinal("id")));
            comment.LikeCount = Convert.ToInt32(mdr.GetString(mdr.GetOrdinal("like_count")));
            comment.DislikeCount = Convert.ToInt32(mdr.GetString(mdr.GetOrdinal("dislike_count")));

            int userId = Convert.ToInt32(mdr.GetString(mdr.GetOrdinal("user")));
            comment.User = usersDAO.GetUserById(userId);

            int postId = Convert.ToInt32(mdr.GetString(mdr.GetOrdinal("post")));
            comment.Post = postDAO.GetPostById(postId);
        }

        public Comment RemoveComment(Comment comment)
        {
            try
            {
                string query = "delete from comment where id = @id";

                con.Open();
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@id", comment.Id);

                if (cmd.ExecuteNonQuery() == 0)
                    throw new Exception("Error occured while deleting data with this id: " + comment.Id);
                return comment;
            }
            catch (Exception ex)
            {
                _log.Log(ex.Message + "\r\n" + ex.StackTrace);
                con.Close();
                return null;
            }
        }

        public Comment UpdateComment(Comment comment)
        {
            try
            {
                string query = "update comment set user = @user, post = @post, topic = @topic, like_count = @like_count, dislike_count = @dislike_count " +
                    "post_date = @post_date where id = @id";

                con.Open();
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@id", comment.Id);
                cmd.Parameters.AddWithValue("@user", comment.User.Id);
                cmd.Parameters.AddWithValue("@post", comment.Post.Id);
                cmd.Parameters.AddWithValue("@topic", comment.Topic);
                cmd.Parameters.AddWithValue("@like_count", comment.LikeCount);
                cmd.Parameters.AddWithValue("@dislike_count", comment.DislikeCount);
                cmd.Parameters.AddWithValue("@post_date", comment.PostDate);

                if (cmd.ExecuteNonQuery() == 0)
                    throw new Exception("Error occured while updating data with this id: " + comment.Id);
                return comment;
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