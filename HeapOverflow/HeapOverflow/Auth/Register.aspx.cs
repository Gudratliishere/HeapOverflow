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
    public partial class Register : System.Web.UI.Page
    {
        private IUserLoginDAO loginDAO = Config.Context.GetUserLoginDAO();
        private IUsersDAO usersDAO = Config.Context.GetUsersDAO();
        private IRoleDAO roleDAO = Config.Context.GetRoleDAO();

        private static EmailSender emailSender;
        private static UserLogin login;

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
            }
            else
            {
                Response.Redirect("../Home/Index.aspx");
            }
        }

        protected void btn_register_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Auth/Register.aspx");
        }

        protected void btn_login_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Auth/Login.aspx");
        }

        protected void btn_registerBody_Click(object sender, EventArgs e)
        {
            if (!EmptyFieldExists() && CheckPasswordMatch() && !CheckUsernameExists() && !CheckEmailExists())
            {
                login = PrepareUserLogin();

				Users user = new Users();
				usersDAO.AddUser(user);
				login.User = user;
				loginDAO.AddUserLogin(login);

				Session["user"] = login.Id;
				Response.Redirect("../Account/UserEdit.aspx");

				//emailSender = new EmailSender();
				//emailSender.Email = tb_email.Text.Trim();
				//emailSender.SendEmail();
				//btn_registerBody.Enabled = false;
				//pnl_emailConfirm.Visible = true;
				//btn_register.Visible = false;
            }
        }

        private UserLogin PrepareUserLogin()
        {
            UserLogin login = new UserLogin();
            login.Username = tb_username.Text.Trim();
            login.Email = tb_email.Text.Trim();
            login.Password = Cryption.Encrypt(tb_password.Text);
            login.Status = 1;
            login.Role = roleDAO.GetUserRole();

            return login;
        }

        private bool CheckEmailExists()
        {
            if (IsEmailExists())
            {
                GiveMessage("User exists with this email!", tb_email);
                return true;
            }
            else
                ClearMessage(tb_email);
            return false;
        }

        private bool CheckUsernameExists()
        {
            if (IsUsernameExists())
            {
                GiveMessage("This username is already taken, choose another one", tb_username);
                return true;
            }
            else
                ClearMessage(tb_username);
            return false;
        }
        private bool CheckPasswordMatch()
        {
            if (!tb_password.Text.Equals(tb_cpassword.Text))
            {
                GiveMessage("Password doesn't match!", tb_cpassword);
                return false;
            }
            else
                ClearMessage(tb_cpassword);

            return true;
        }

        private bool EmptyFieldExists()
        {
            if (tb_username.Text.Trim().Equals(""))
                GiveMessage("Fill username", tb_username);
            else
            {
                if (tb_email.Text.Trim().Equals(""))
                    GiveMessage("Fill email", tb_email);
                else
                {
                    ClearMessage(tb_email);
                    if (tb_password.Text.Trim().Equals(""))
                        GiveMessage("Fill password", tb_password);
                    else
                    {
                        ClearMessage(tb_password);
                        return false;
                    }
                }

            }
            return true;
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

        private bool IsUsernameExists()
        {
            var username = tb_username.Text.Trim();
            return loginDAO.GetUserLoginByUsername(username) != null;
        }

        private bool IsEmailExists()
        {
            var email = tb_email.Text.Trim();
            return loginDAO.GetUserLoginByEmail(email) != null;
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
                    Users user = new Users();
                    usersDAO.AddUser(user);
                    login.User = user;
                    loginDAO.AddUserLogin(login);

                    Session["user"] = login.Id;
                    Response.Redirect("../Account/UserEdit.aspx");
                }
            }
            pnl_emailConfirm.Visible = false;
            btn_register.Enabled = true;
        }
    }
}