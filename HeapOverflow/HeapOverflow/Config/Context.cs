using HeapOverflow.DAO.Impl;
using HeapOverflow.DAO.Impl.RAM;
using HeapOverflow.DAO.Inter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HeapOverflow.Config
{
    public class Context
    {
        private static IAdminDAO adminDAO = null;
        private static IUserLoginDAO userLoginDAO = null;
        private static IUsersDAO usersDAO = null;
        private static IRoleDAO roleDAO = null;
        private static IPostDAO postDAO = null;
        private static ICommentDAO commentDAO = null;
        private static IVotesDAO votesDAO = null;

        public static IAdminDAO GetAdminDAO ()
        {
            if (adminDAO == null)
                adminDAO = new AdminDAO();

            return adminDAO;
        }

        public static IUserLoginDAO GetUserLoginDAO ()
        {
            if (userLoginDAO == null)
                userLoginDAO = new UserLoginDAO();

            return userLoginDAO;
        }

        public static IUsersDAO GetUsersDAO ()
        {
            if (usersDAO == null)
                usersDAO = new UsersDAO();

            return usersDAO;
        }

        public static IRoleDAO GetRoleDAO ()
        {
            if (roleDAO == null)
                roleDAO = new RoleDAO();

            return roleDAO;
        }

        public static IPostDAO GetPostDAO()
        {
            if (postDAO == null)
                postDAO = new PostDAO();

            return postDAO;
        }

        public static ICommentDAO GetCommentDAO ()
        {
            if (commentDAO == null)
                commentDAO = new CommentDAO();

            return commentDAO;
        }

        public static IVotesDAO GetVotesDAO ()
        {
            if (votesDAO == null)
                votesDAO = new VotesDAO();

            return votesDAO;
        }
    }
}