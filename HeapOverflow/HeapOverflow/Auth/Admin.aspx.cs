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
    public partial class Admin : System.Web.UI.Page
    {
        private IAdminDAO adminDAO = Config.Context.GetAdminDAO();

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btn_loginBody_Click(object sender, EventArgs e)
        {
            var admin = adminDAO.GetAdminByEmail(tb_username.Text.Trim());
            if (admin == null)
                GiveMessage("There is not any account with this email", tb_username);
            else
            {
                ClearMessage(tb_username);

                if (!admin.Password.Equals(Cryption.Encrypt(tb_password.Text)))
                    GiveMessage("Password is wrong!", tb_password);
                else
                {
                    ClearMessage(tb_password);

                    Session["admin"] = admin.Id;

                    Response.Redirect("../Home/AdminPanel.aspx");
                }
            }
        }

        private void GiveMessage(string message, TextBox textBox)
        {
            lbl_message.Text = message;
            textBox.BorderColor = System.Drawing.Color.Red;
        }

        private void ClearMessage(TextBox textBox)
        {
            lbl_message.Text = string.Empty;
            textBox.BorderColor = System.Drawing.Color.Silver;
        }
    }
}