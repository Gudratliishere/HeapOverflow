using HeapOverflow.DAO.Inter;
using HeapOverflow.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HeapOverflow.Home
{
    public partial class NewPost : System.Web.UI.Page
    {
        private IPostDAO postDAO = Config.Context.GetPostDAO();
        private IUserLoginDAO loginDAO = Config.Context.GetUserLoginDAO();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
                Response.Redirect("../Auth/Login.aspx");
        }

        protected void btn_account_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Account/User.aspx?id=" + Session["user"]);
        }

        protected void btn_home_Click(object sender, EventArgs e)
        {
            Response.Redirect("Index.aspx");
        }

        protected void btn_post_Click(object sender, EventArgs e)
        {
            Post post = new Post();
            post.Name = tb_name.Text;
            post.Topic = tb_topic.Text;
            post.PostDate = DateTime.Now;

            int id;
            bool parse = int.TryParse(Session["user"].ToString(), out id);
            if (parse)
            {
                var login = loginDAO.GetUserLoginById(id);
                post.User = login;
            }

            post = postDAO.AddPost(post);
            Response.Redirect("PostDetail.aspx?id=" + post.Id);
        }
    }
}