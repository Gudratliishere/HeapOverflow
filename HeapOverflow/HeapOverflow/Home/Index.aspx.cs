using HeapOverflow.Config;
using HeapOverflow.DAO.Inter;
using HeapOverflow.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace HeapOverflow.Home
{
    public partial class Index : Page
    {
        private IPostDAO postDAO = Config.Context.GetPostDAO();

        protected void Page_Load(object sender, EventArgs e)
        {
            CheckAccountButtons();
            FillPosts();
        }

        private void FillPosts()
        {
            var posts = postDAO.GetAll();
            posts.ForEach((post) =>
            {
                var div_status = GetDivStatus();
                var div_subject = GetDivSubject(post);

            });
        }

        private HtmlGenericControl GetDivReplies (Post post)
        {
            HtmlGenericControl replies = new HtmlGenericControl("div");
            return replies;
        }

        private HtmlGenericControl GetDivSubject (Post post)
        {
            HtmlGenericControl a = new HtmlGenericControl("a");
            a.Attributes.Add("href", "PostDetail.aspx?id=" + post.Id);
            a.InnerHtml = post.Topic;

            HtmlGenericControl br = new HtmlGenericControl("br");

            HtmlGenericControl b = new HtmlGenericControl("b");
            b.InnerHtml = post.User.Username;
            HtmlGenericControl span = new HtmlGenericControl("span");
            span.InnerHtml = "Started by ";
            span.Controls.Add(b);

            HtmlGenericControl div_subject = new HtmlGenericControl("div");
            div_subject.Attributes.Add("class", "subjects");
            div_subject.Controls.Add(a);
            div_subject.Controls.Add(br);
            div_subject.Controls.Add(span);

            return div_subject;
        }

        private HtmlGenericControl GetDivStatus ()
        {
            HtmlGenericControl div_status = new HtmlGenericControl("div");
            div_status.Attributes.Add("class", "status");
            div_status.InnerHtml = "Fire";

            return div_status;
        }

        private void CheckAccountButtons()
        {
            if (Session["user"] == null)
            {
                btn_login.Visible = true;
                btn_register.Visible = true;
                btn_logout.Visible = false;
                btn_account.Visible = false;
            } else
            {
                btn_login.Visible = false;
                btn_register.Visible = false;
                btn_logout.Visible = true;
                btn_account.Visible = true;
            }
        }

        protected void btn_login_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Auth/Login.aspx");
        }

        protected void btn_register_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Auth/Register.aspx");
        }

        protected void btn_logout_Click(object sender, EventArgs e)
        {
            Response.Redirect("Logout.aspx");
        }

        protected void btn_account_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Account/User.aspx?id=" + Session["user"]);
        }

        protected void btn_home_Click(object sender, EventArgs e)
        {
            Response.Redirect("Index.aspx");
        }

        protected void btn_new_Click(object sender, EventArgs e)
        {
            Response.Redirect("NewPost.aspx");
        }
    }
}