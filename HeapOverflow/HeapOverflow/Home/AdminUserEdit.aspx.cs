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
    public partial class AdminUserEdit : System.Web.UI.Page
    {
        private IUserLoginDAO loginDAO = Config.Context.GetUserLoginDAO();
        private IRoleDAO roleDAO = Config.Context.GetRoleDAO();
        private UserLogin login;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["admin"] == null)
                Response.Redirect("Index.aspx");

            FillUserInformation();
        }

        private void FillUserInformation()
        {
            var parse = int.TryParse(Request.Params["id"], out int id);
            if (parse)
            {
                login = loginDAO.GetUserLoginById(id);
                if (login != null)
                {
                    lbl_username.Text = login.Username + ": ";
                    ddl_status.SelectedValue = login.Status.ToString();
                    ddl_role.SelectedValue = login.Role.Name;
                }
            }
        }

        protected void btn_save_Click(object sender, EventArgs e)
        {
            if (login != null)
            {
                login.Status = int.Parse(ddl_status.SelectedValue);
                login.Role = (ddl_role.SelectedIndex == 0) ? roleDAO.GetUserRole() : roleDAO.GetModeratorRole();
                loginDAO.UpdateUserLogin(login);
                Response.Redirect("AdminPanel.aspx");
            }
        }
    }
}