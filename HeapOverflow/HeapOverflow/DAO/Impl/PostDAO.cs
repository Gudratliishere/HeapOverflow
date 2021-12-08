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
        private MySqlCommand cmd;

        private IUsersDAO usersDAO;

        public PostDAO()
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
        }

        public Post AddPost(Post post)
        {
            try
            {
                string query = "insert into post (name, topic, like_count, dislike_count, user, post_date) values (@name, @topic, @like_count, @dislike_count, " +
                    "@user, @post_date); select LAST_INSERT_ID()";

                con.Open();
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@name", post.Name);
                cmd.Parameters.AddWithValue("@topic", post.Topic);
                cmd.Parameters.AddWithValue("@like_count", post.LikeCount);
                cmd.Parameters.AddWithValue("@dislike_count", post.DislikeCount);
                cmd.Parameters.AddWithValue("@user", post.User.Id);
                cmd.Parameters.AddWithValue("@post_date", post.PostDate);

                int id = Convert.ToInt32(cmd.ExecuteScalar());
                if (id > 0)
                {
                    post.Id = id;
                    con.Close();
                    return post;
                }
                else
                    throw new Exception("Error occured while new Post inserting!");
            }
            catch (Exception ex)
            {
                _log.Log(ex.Message + "\r\n" + ex.StackTrace);
                con.Close();
                return null;
            }
        }

        public List<Post> GetAll()
        {
            try
            {
                string query = "select * from post";

                con.Open();
                cmd.CommandText = query;

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
            catch (Exception ex)
            {
                _log.Log(ex.Message + "\r\n" + ex.StackTrace);
                con.Close();
                return null;
            }
        }

        public Post GetPostById(int id)
        {
            try
            {
                string query = "select * from post where id = @id";

                con.Open();
                cmd.CommandText = query;
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
            catch (Exception ex)
            {
                _log.Log(ex.Message + "\r\n" + ex.StackTrace);
                con.Close();
                return null;
            }
        }

        public List<Post> GetPostByUser(Users user)
        {
            try
            {
                string query = "select * from post where user = @user";

                con.Open();
                cmd.CommandText = query;
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
            catch (Exception ex)
            {
                _log.Log(ex.Message + "\r\n" + ex.StackTrace);
                con.Close();
                return null;
            }
        }

        private void FillPostWithMDR(Post post, MySqlDataReader mdr)
        {
            post.Id = Convert.ToInt32(mdr.GetString(mdr.GetOrdinal("id")));
            post.Name = mdr.GetString(mdr.GetOrdinal("name"));
            post.Topic = mdr.GetString(mdr.GetOrdinal("topic"));
            post.LikeCount = Convert.ToInt32(mdr.GetString(mdr.GetOrdinal("like_count")));
            post.DislikeCount = Convert.ToInt32(mdr.GetString(mdr.GetOrdinal("dislike_count")));

            int userId = Convert.ToInt32(mdr.GetString(mdr.GetOrdinal("user")));
            post.User = usersDAO.GetUserById(userId);
        }

        public Post RemovePost(Post post)
        {
            try
            {
                string query = "delete from post where id = @id";

                con.Open();
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@id", post.Id);

                if (cmd.ExecuteNonQuery() == 0)
                    throw new Exception("Error occured while deleting data with this id: " + post.Id);
                return post;
            }
            catch (Exception ex)
            {
                _log.Log(ex.Message + "\r\n" + ex.StackTrace);
                con.Close();
                return null;
            }
        }

        public Post UpdatePost(Post post)
        {
            try
            {
                string query = "update post set name = @name, topic = @topic, like_count = @like_count, dislike_count = @dislike_count, user = @user, " +
                    "post_date = @post_date where id = @id";

                con.Open();
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@id", post.Id);
                cmd.Parameters.AddWithValue("@name", post.Name);
                cmd.Parameters.AddWithValue("@topic", post.Topic);
                cmd.Parameters.AddWithValue("@like_count", post.LikeCount);
                cmd.Parameters.AddWithValue("@dislike_count", post.DislikeCount);
                cmd.Parameters.AddWithValue("@user", post.User.Id);
                cmd.Parameters.AddWithValue("@post_date", post.PostDate);

                if (cmd.ExecuteNonQuery() == 0)
                    throw new Exception("Error occured while updating data with this id: " + post.Id);
                return post;
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