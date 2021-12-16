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
    public partial class RemovePost : System.Web.UI.Page
    {
        private IPostDAO postDAO = Config.Context.GetPostDAO();
        private ICommentDAO commentDAO = Config.Context.GetCommentDAO();
        private IUserLoginDAO loginDAO = Config.Context.GetUserLoginDAO();
        private IUsersDAO usersDAO = Config.Context.GetUsersDAO();
        private IVotesDAO votesDAO = Config.Context.GetVotesDAO();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
                Response.Redirect("Index.aspx");
        }

        protected void btn_remove_Click(object sender, EventArgs e)
        {
            var parse = int.TryParse(Request.Params["id"], out int id);
            if (parse)
            {
                var post = postDAO.GetPostById(id);
                if (post != null)
                {
                    var parseSession = int.TryParse(Session["user"].ToString(), out int loginId);
                    if (parseSession)
                    {
                        var login = loginDAO.GetUserLoginById(loginId);
                        if (login == null || (postDAO.GetPostById(id).User.Id != login.Id && login.Role.Name.Equals("USER")))
                            Response.Redirect("Index.aspx");
                    }

                    var user = post.User.User;
                    user.Post--;
                    usersDAO.UpdateUser(user);

                    votesDAO.RemoveVotesByPost(post.Id);
                    commentDAO.RemoveCommentByPost(post.Id);
                    postDAO.RemovePost(post);
                    Response.Redirect("Index.aspx");
                }
            }
        }
    }
}