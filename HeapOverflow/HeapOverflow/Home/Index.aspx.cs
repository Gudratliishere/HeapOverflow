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
        private readonly Logger _log = new Logger("Index.aspx");

        private IPostDAO postDAO = Config.Context.GetPostDAO();
        private ICommentDAO commentDAO = Config.Context.GetCommentDAO();

        private static int offset = 0;
        private static readonly int next = 10;

        private string searchKey;
        private string searchMethod;

        protected void Page_Load(object sender, EventArgs e)
        {
            CheckAccountButtons();
            DefinePagination();
            FillPosts();
        }

        private void FillPosts()
        {
            var search = Request.Params["search"];
            if (search != null)
            {
                var method = Request.Params["method"];
                if (method != null)
                {
                    searchKey = search;
                    searchMethod = method;
                    if (method == "everything")
                        FillPosts(postDAO.GetPostWhereNameOrTopicContain(search, offset, next));
                    else if (method == "title")
                        FillPosts(postDAO.GetPostWhereNameContain(search, offset, next));
                    else if (method == "topic")
                        FillPosts(postDAO.GetPostWhereTopicContain(search, offset, next));
                }
            }
            else
                FillPosts(postDAO.GetAllByPagination(offset, next));
        }

        private void DefinePagination()
        {
            var parse = int.TryParse(Request.Params["page"], out int page);
            offset = (parse) ? page * 10 : 0;

            int pages = postDAO.GetSize() / 10 + 1;
            for (int i = 0; i < pages; i++)
                CreatePageButton(i);
        }

        private void CreatePageButton(int page)
        {
            Button button = new Button();
            button.ID = "btn_page" + page;
            button.Text = (page + 1).ToString();
            button.CssClass = "btn-page";
            button.Click += delegate (object sender, EventArgs e)
            {
                if (searchKey != null && searchMethod != null)
                    Response.Redirect("Index.aspx?search=" + searchKey + "&method=" + searchMethod + "&page=" + page);
                else
                    Response.Redirect("Index.aspx?page=" + page);
            };
            ph_pagination.Controls.Add(button);
        }

        private void FillPosts(List<Post> posts)
        {
            try
            {
                ph_table_row.Controls.Clear();
                posts.ForEach((post) =>
                {
                    var table_row = GetDivTableRow(post);
                    ph_table_row.Controls.Add(table_row);
                });
            } catch (Exception ex)
            {
                _log.Log(ex.Message + "\r\n" + ex.StackTrace);
            }
        }

        private HtmlGenericControl GetDivTableRow(Post post)
        {
            HtmlGenericControl table_row = new HtmlGenericControl("div");
            table_row.Attributes.Add("class", "table-row");
            table_row.Controls.Add(GetDivStatus());
            table_row.Controls.Add(GetDivSubject(post));
            table_row.Controls.Add(GetDivReplies(post));
            table_row.Controls.Add(GetDevider());
            return table_row;
        }

        private HtmlGenericControl GetDevider()
        {
            HtmlGenericControl devider = new HtmlGenericControl("hr");
            devider.Attributes.Add("class", "subforum-devider");
            return devider;
        }

        private HtmlGenericControl GetDivReplies(Post post)
        {
            HtmlGenericControl span = new HtmlGenericControl("span");
            span.InnerHtml = commentDAO.GetCommentsByPost(post).Count.ToString() + " replies\n" + post.LikeCount + " likes";

            HtmlGenericControl replies = new HtmlGenericControl("div");
            replies.Attributes.Add("class", "replies");
            replies.Controls.Add(span);
            return replies;
        }

        private HtmlGenericControl GetDivSubject(Post post)
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

        private HtmlGenericControl GetDivStatus()
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

        protected void btn_search_Click(object sender, EventArgs e)
        {
            var key = tb_search.Text.Trim();
            if (ddl_filter.SelectedIndex == 0)
                Response.Redirect("Index.aspx?search=" + key + "&method=everything");
            else if (ddl_filter.SelectedIndex == 1)
                Response.Redirect("Index.aspx?search=" + key + "&method=title");
            else if (ddl_filter.SelectedIndex == 2)
                Response.Redirect("Index.aspx?search=" + key + "&method=topic");
        }
    }
}