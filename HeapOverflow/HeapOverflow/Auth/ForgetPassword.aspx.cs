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
    public partial class EmailConfirmation : System.Web.UI.Page
    {
        private IUserLoginDAO loginDAO = Config.Context.GetUserLoginDAO();
        private UserLogin login;
        private EmailSender emailSender;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_send_Click(object sender, EventArgs e)
        {
            if (tb_email.Text.Trim() == "")
                lbl_message.Text = "Fill email!";
            else
            {
                lbl_message.Text = string.Empty;
                CheckEmailExists();
            }
        }

        private void CheckEmailExists()
        {
            login = loginDAO.GetUserLoginByEmail(tb_email.Text.Trim());
            if (login == null)
                lbl_message.Text = "User doesn't exist with this email!";
            else
            {
                lbl_message.Text = string.Empty;
                SendEmail();
            }
        }

        private void SendEmail()
        {
            emailSender = new EmailSender();
            emailSender.Email = tb_email.Text.Trim();
            emailSender.SendEmail();
            pnl_confirm.Visible = true;
            pnl_confirm.Enabled = true;
        }

        protected void btn_confirm_Click(object sender, EventArgs e)
        {
            if (!tb_code.Text.Trim().Equals(emailSender.Code))
                lbl_message.Text = "Code is wrong!";
            else
            {
                lbl_message.Text = string.Empty;
                
                if (DateTime.Now > emailSender.SendTime + TimeSpan.FromMinutes(3))
                    lbl_message.Text = "Time is over!";
                else
                {
                    Session["confirm"] = login.Id;
                    Response.Redirect("NewPassword.aspx");
                }
            }
        }

        protected void btn_home_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Home/Index.aspx");
        }
    }
}