using HeapOverflow.DAO.Inter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HeapOverflow.Account
{
    public partial class User : System.Web.UI.Page
    {
        private IUserLoginDAO loginDAO = Config.Context.GetUserLoginDAO();

        protected void Page_Load(object sender, EventArgs e)
        {
            FillInformation();
        }

        private void FillInformation()
        {
            var param = Request.Params["id"];
            if (param != null)
            {
                int id;
                var parse = int.TryParse(param, out id);
                if (parse)
                {
                    var user =  loginDAO.GetUserLoginById(id).User;
                    lbl_name.Text = user.Name;
                    lbl_surname.Text = user.Surname;
                    lbl_description.Text = user.Description;
                    lbl_post.Text = "Post: " + user.Post;
                    lbl_star.Text = "Star: " + user.Star;
                } 
            }
        }

        protected void btn_home_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Home/Index.aspx");
        }

        protected void btn_edit_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserEdit.aspx");
        }
    }
}