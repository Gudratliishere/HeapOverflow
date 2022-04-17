using HeapOverflow.DAO.Inter;
using HeapOverflow.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HeapOverflow.DAO.Impl.RAM
{
	public class UserLoginRAMDAO : IUserLoginDAO
	{
		private static List<UserLogin> logins = new List<UserLogin>();

		public UserLogin AddUserLogin(UserLogin login)
		{
			login.Id = logins.Count;
			logins.Add(login);
			return login;
		}

		public List<UserLogin> GetAll()
		{
			return logins;
		}

		public UserLogin GetUserLoginByEmail(string email)
		{
			foreach (UserLogin login in logins)
				if (login.Email == email)
					return login;
			return null;
		}

		public UserLogin GetUserLoginById(int id)
		{
			foreach (UserLogin login in logins)
				if (login.Id == id)
					return login;
			return null;
		}

		public List<UserLogin> GetUserLoginByRole(Role role)
		{
			List<UserLogin> resultLogins = new List<UserLogin>();
			foreach (UserLogin login in logins)
				if (login.Role.Id == role.Id)
					resultLogins.Add(login);
			return resultLogins;
		}

		public List<UserLogin> GetUserLoginByStatus(int status)
		{
			List<UserLogin> resultLogins = new List<UserLogin>();
			foreach (UserLogin login in logins)
				if (login.Status == status)
					resultLogins.Add(login);
			return resultLogins;
		}

		public UserLogin GetUserLoginByUser(Users user)
		{
			foreach (UserLogin login in logins)
				if (login.User.Id == user.Id)
					return login;
			return null;
		}

		public UserLogin GetUserLoginByUsername(string username)
		{
			foreach (UserLogin login in logins)
				if (login.Username == username)
					return login;
			return null;
		}

		public UserLogin RemoveUserLogin(UserLogin login)
		{
			foreach (UserLogin ulogin in logins)
				if (ulogin.Id == login.Id)
				{
					logins.Remove(login);
					break;
				}
			return null;
		}

		public UserLogin UpdateUserLogin(UserLogin login)
		{
			throw new NotImplementedException();
		}
	}
}