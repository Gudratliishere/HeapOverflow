using HeapOverflow.DAO.Inter;
using HeapOverflow.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HeapOverflow.DAO.Impl.RAM
{
	public class UsersRAMDAO : IUsersDAO
	{
		private static List<Users> users = new List<Users>();

		public Users AddUser(Users user)
		{
			user.Id = users.Count;
			users.Add(user);
			return user;
		}

		public Users GetUserById(int id)
		{
			foreach (Users user in users)
				if (user.Id == id)
					return user;
			return null;
		}

		public Users RemoveUser(Users user)
		{
			foreach (Users ruser in users)
				if (ruser.Id == user.Id)
				{
					users.Remove(ruser);
					break;
				}
			return user;
		}

		public Users UpdateUser(Users user)
		{
			foreach (Users updateUser in users)
				if (updateUser.Id == user.Id)
				{
					updateUser.Name = user.Name;
					updateUser.Surname = user.Surname;
					if (user.Photo.Length != 0)
						updateUser.Photo = user.Photo;
					updateUser.Description = user.Description;
					updateUser.Post = user.Post;
				}
			return user;
		}
	}
}