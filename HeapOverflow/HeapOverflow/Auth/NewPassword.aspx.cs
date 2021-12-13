using HeapOverflow.Config;
using HeapOverflow.DAO.Inter;
using HeapOverflow.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HeapOverflow.Auth
{
    public partial class NewPassword : System.Web.UI.Page
    {
        private IUserLoginDAO loginDAO = Config.Context.GetUserLoginDAO();
        private UserLogin login;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["confirm"] == null)
                Response.Redirect("../Home/Index.aspx");

            GetLogin();
        }

        private void GetLogin()
        {
            var parse = int.TryParse(Session["confirm"].ToString(), out int id);
            if (parse)
                login = loginDAO.GetUserLoginById(id);
        }

        protected void btn_confirm_Click(object sender, EventArgs e)
        {
            if (!tb_password.Text.Trim().Equals(tb_cpassword.Text.Trim()))
                lbl_message.Text = "Password doesn't match!";
            else
            {
                login.Password = Cryption.Encrypt(tb_password.Text.Trim());
                loginDAO.UpdateUserLogin(login);
                Response.Redirect("Login.aspx");
            }
        }

        protected void btn_home_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Home/Index.aspx");
        }
    }
}