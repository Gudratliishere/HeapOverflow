using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HeapOverflow.Home
{
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
                Response.Redirect("Index.aspx");
        }

        protected void btn_logoutConfirm_Click(object sender, EventArgs e)
        {
            Session["user"] = null;
            Response.Redirect("Index.aspx");
        }
    }
}