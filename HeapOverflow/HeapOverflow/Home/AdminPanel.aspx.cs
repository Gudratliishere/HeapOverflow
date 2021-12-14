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
    public partial class AdminPanel : System.Web.UI.Page
    {
        private IUserLoginDAO loginDAO = Config.Context.GetUserLoginDAO();
        private IRoleDAO roleDAO = Config.Context.GetRoleDAO();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["admin"] == null)
                Response.Redirect("Index.aspx");

            FillUsers(loginDAO.GetAll());
        }

        private void FillUsers(List<UserLogin> logins)
        {
            ph_users.Controls.Clear();
            logins.ForEach((login) =>
            {
                ph_users.Controls.Add(GetUserItem(login));
            });
        }

        private HtmlGenericControl GetUserItem(UserLogin login)
        {
            HtmlGenericControl user_item = new HtmlGenericControl("div");
            user_item.Attributes.Add("class", "table-row");
            user_item.Controls.Add(GetUsernameSpan(login));
            user_item.Controls.Add(GetStatusSpan(login));
            user_item.Controls.Add(GetRoleSpan(login));
            user_item.Controls.Add(GetEditButton(login));

            return user_item;
        }

        private HtmlGenericControl GetUsernameSpan(UserLogin login)
        {
            HtmlGenericControl span = new HtmlGenericControl("div");
            span.Attributes.Add("class", "username");
            span.InnerHtml = login.Username;

            return span;
        }

        private HtmlGenericControl GetStatusSpan(UserLogin login)
        {
            HtmlGenericControl span = new HtmlGenericControl("div");
            span.Attributes.Add("class", "status");
            span.InnerHtml = login.Status.ToString();

            return span;
        }

        private HtmlGenericControl GetRoleSpan(UserLogin login)
        {
            HtmlGenericControl span = new HtmlGenericControl("div");
            span.Attributes.Add("class", "role");
            span.InnerHtml = login.Role.Name;

            return span;
        }

        private Button GetEditButton(UserLogin login)
        {
            Button button = new Button();
            button.CssClass = "btn-edit";
            button.Text = "Edit";
            button.Click += delegate (object sender, EventArgs e)
            {
                Response.Redirect("AdminUserEdit.aspx?id=" + login.Id);
            };

            return button;
        }

        protected void btn_search_Click(object sender, EventArgs e)
        {
            var login = loginDAO.GetUserLoginByUsername(tb_search.Text.Trim());
            if (login != null)
                FillUsers(new List<UserLogin> { login });
            else
                FillUsers(loginDAO.GetAll());
        }

        protected void btn_searchByStatus_Click(object sender, EventArgs e)
        {
            FillUsers(loginDAO.GetUserLoginByStatus(int.Parse(ddl_status.SelectedValue)));
        }

        protected void btn_searchByRole_Click(object sender, EventArgs e)
        {
            if (ddl_role.SelectedIndex == 0)
                FillUsers(loginDAO.GetUserLoginByRole(roleDAO.GetUserRole()));
            else
                FillUsers(loginDAO.GetUserLoginByRole(roleDAO.GetModeratorRole()));
        }
    }
}