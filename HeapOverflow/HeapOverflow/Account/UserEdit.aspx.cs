using HeapOverflow.Config;
using HeapOverflow.DAO.Inter;
using HeapOverflow.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HeapOverflow.Account
{
    public partial class UserEdit : Page
    {
        private IUsersDAO usersDAO = Config.Context.GetUsersDAO();
        private IUserLoginDAO loginDAO = Config.Context.GetUserLoginDAO();
        private Users user;
        private int loginId;
        private UserLogin login;

        private static bool allowLoad = true;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
                Response.Redirect("../Auth/Login.aspx");

            FillUserInformation();
        }

        private void FillUserInformation()
        {
            var parse = int.TryParse(Session["user"].ToString(), out loginId);
            if (parse)
            {
                login = loginDAO.GetUserLoginById(loginId);
                user = login.User;
                if (user != null && allowLoad)
                {
                    tb_name.Text = user.Name;
                    tb_surname.Text = user.Surname;
                    tb_description.Text = user.Description;
                    if (user.Photo.Length != 0)
                        img_profilePhoto.ImageUrl = "data:image;base64," + Convert.ToBase64String(user.Photo);

                    allowLoad = false;
                }
            }
        }

        protected void btn_account_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Account/User.aspx?id=" + Session["user"]);
        }

        protected void btn_home_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Home/Index.aspx");
        }

        protected void btn_save_Click(object sender, EventArgs e)
        {
            if (user != null)
            {
                user.Name = tb_name.Text.Trim();
                user.Surname = tb_surname.Text.Trim();
                user.Description = tb_description.Text.Trim();

                string photoPath;
                if (fup_profilePhoto.HasFile)
                {
                    photoPath = Configuration.GetConfig()._imagesDirectory + "\\" + login.Username + "_" + DateTime.Now.ToString("yyyy-MM-dd_hh-mm-ss");
                    fup_profilePhoto.SaveAs(photoPath);

                }
                else
                    photoPath = Configuration.GetConfig()._defaultImage;

                FileStream fs = new FileStream(photoPath, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                user.Photo = br.ReadBytes((int)fs.Length);
                br.Close();
                fs.Close();

                usersDAO.UpdateUser(user);
                allowLoad = true;
                Response.Redirect("User.aspx?id=" + loginId);
            }
        }
    }
}