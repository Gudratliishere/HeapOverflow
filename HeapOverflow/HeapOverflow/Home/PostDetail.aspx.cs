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
    public partial class PostDetail : Page
    {
        private IUserLoginDAO loginDAO = Config.Context.GetUserLoginDAO();
        private IRoleDAO roleDAO = Config.Context.GetRoleDAO();
        private IPostDAO postDAO = Config.Context.GetPostDAO();
        private ICommentDAO commentDAO = Config.Context.GetCommentDAO();

        private Post post;

        protected void Page_Load(object sender, EventArgs e)
        {
            CheckAccountButtons();
            CheckRemoveButton();
            FillPostInformation();
            FillComments();
        }

        private void FillComments()
        {
            if (post != null)
            {
                List<Comment> comments = commentDAO.GetCommentsByPost(post);
                comments.ForEach((comment) =>
                {
                    HtmlGenericControl control = new HtmlGenericControl("div");
                    control.Attributes.Add("class", "comment-item");
                    control.Controls.Add(GetCommentUsernameButton(comment));
                    control.Controls.Add(GetCommentTopicLabel(comment));
                    ph_comment_item.Controls.Add(control);
                });
            }
        }

        private Label GetCommentTopicLabel (Comment comment)
        {
            Label lbl_topic = new Label();
            lbl_topic.ID = "lbl_comment" + comment.Id;
            lbl_topic.CssClass = "lbl_comment";
            lbl_topic.Text = comment.Topic;
            return lbl_topic;
        }

        private Button GetCommentUsernameButton (Comment comment)
        {
            Button button = new Button();
            button.ID = "btn_usernameComment" + comment.Id;
            button.CssClass = "btn_usernameComment";
            button.Text = comment.User.Username + ": ";
            button.Click += delegate (object sender, EventArgs e)
            {
                Response.Redirect("../Account/User.aspx?id=" + comment.User.Id);
            };
            return button;
        }

        private void FillPostInformation()
        {
            int id;
            var parse = int.TryParse(Request.Params["id"], out id);
            if (parse)
            {
                post = postDAO.GetPostById(id);
                if (post != null)
                {
                    lbl_name.Text = post.Name;
                    lbl_topic.Text = post.Topic;
                    btn_username.Text = post.User.Username;
                }
            }
        }

        private void CheckRemoveButton()
        {
            if (Session["user"] == null)
                btn_removePost.Visible = false;
            else
            {
                int id;
                var parse = int.TryParse(Session["user"].ToString(), out id);
                if (parse)
                {
                    var login = loginDAO.GetUserLoginById(id);
                    if (login != null)
                    {
                        if (login.Role == roleDAO.GetUserRole())
                            btn_removePost.Visible = false;
                        else
                            btn_removePost.Visible = true;
                    }
                }
            }
        }

        protected void btn_home_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Home/Index.aspx");
        }

        protected void btn_account_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Account/User.aspx?id=" + Session["user"]);
        }

        private void CheckAccountButtons()
        {
            if (Session["user"] == null)
            {
                btn_login.Visible = true;
                btn_register.Visible = true;
                btn_logout.Visible = false;
                btn_account.Visible = false;
            }
            else
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

        protected void btn_postLike_Click(object sender, EventArgs e)
        {
            if (Session["user"] == null)
                Response.Redirect("../Auth/Login.aspx");
        }

        protected void btn_postDislike_Click(object sender, EventArgs e)
        {
            if (Session["user"] == null)
                Response.Redirect("../Auth/Login.aspx");
        }

        protected void btn_postComment_Click(object sender, EventArgs e)
        {
            if (Session["user"] == null)
                Response.Redirect("../Auth/Login.aspx");

            Comment comment = new Comment();
            comment.Post = post;
            comment.Topic = tb_comment.Text;
            comment.PostDate = DateTime.Now;

            var parse = int.TryParse(Session["user"].ToString(), out int loginId);
            if (parse)
                comment.User = loginDAO.GetUserLoginById(loginId);

            commentDAO.AddComment(comment);
            Response.Redirect("PostDetail.aspx?id=" + post.Id);
        }

        protected void btn_removePost_Click(object sender, EventArgs e)
        {
            Response.Redirect("RemovePost.aspx?id=" + post.Id);
        }

        protected void btn_username_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Account/User.aspx?id=" + post.User.Id);
        }
    }
}