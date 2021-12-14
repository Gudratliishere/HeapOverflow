﻿using HeapOverflow.DAO.Inter;
using HeapOverflow.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HeapOverflow.Account
{
    public partial class UserEdit : Page
    {
        //Bug while editing information due to page loading

        private IUsersDAO usersDAO = Config.Context.GetUsersDAO();
        private IUserLoginDAO loginDAO = Config.Context.GetUserLoginDAO();
        private Users user;
        private int loginId;

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
                user = loginDAO.GetUserLoginById(loginId).User;
                if (user != null && allowLoad)
                {
                    tb_name.Text = user.Name;
                    tb_surname.Text = user.Surname;
                    tb_description.Text = user.Description;
                    allowLoad = false;
                }
            }
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
            Response.Redirect("../Home/Index.aspx");
        }

        protected void btn_save_Click(object sender, EventArgs e)
        {
            if (user != null)
            {
                user.Name = tb_name.Text.Trim();
                user.Surname = tb_surname.Text.Trim();
                user.Description = tb_description.Text.Trim();
                usersDAO.UpdateUser(user);
                allowLoad = true;
                Response.Redirect("User.aspx?id=" + loginId);
            }
        }
    }
}