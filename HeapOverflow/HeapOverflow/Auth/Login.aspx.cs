using HeapOverflow.Config;
using HeapOverflow.DAO.Inter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HeapOverflow.Auth
{
    public partial class Login : System.Web.UI.Page
    {
        private IUserLoginDAO loginDAO = Config.Context.GetUserLoginDAO();

        protected void Page_Load(object sender, EventArgs e)
        {
            CheckAccountButtons();
        }

        protected void btn_home_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Home/Index.aspx");
        }

        private void CheckAccountButtons()
        {
            if (Session["user"] == null)
            {
                btn_login.Visible = true;
                btn_register.Visible = true;
                btn_logout.Visible = false;
            } else
            {
                Response.Redirect("../Home/Index.aspx");
            }
        }

        protected void btn_login_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

        protected void cb_show_CheckedChanged(object sender, EventArgs e)
        {
            tb_password.TextMode = tb_password.TextMode == TextBoxMode.Password ? TextBoxMode.SingleLine : TextBoxMode.Password;
        }

        protected void btn_register_Click(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx");
        }

        protected void btn_loginBody_Click(object sender, EventArgs e)
        {
            var login = loginDAO.GetUserLoginByUsername(tb_username.Text.Trim());
            if (login == null)
                GiveMessage("Username doesn't exists", tb_username);
            else
            {
                ClearMessage(tb_username);

                if (!login.Password.Equals(Cryption.Encrypt(tb_password.Text)))
                    GiveMessage("Password is wrong", tb_password);
                else
                {
                    ClearMessage(tb_password);

                    Session["user"] = login.Id;
                    Response.Redirect("../Home/Index.aspx");
                }
            }
        }

        private void GiveMessage (string message, TextBox textBox)
        {
            lbl_message.Text = message;
            textBox.BorderColor = System.Drawing.Color.Red;
        }

        private void ClearMessage (TextBox textBox)
        {
            lbl_message.Text = string.Empty;
            textBox.BorderColor = System.Drawing.Color.Silver;
        }
    }
}