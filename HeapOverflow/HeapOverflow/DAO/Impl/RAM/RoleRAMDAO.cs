using HeapOverflow.DAO.Inter;
using HeapOverflow.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HeapOverflow.DAO.Impl.RAM
{
	public class RoleRAMDAO : IRoleDAO
	{
		private static Role moderatorRole = null;
		private static Role userRole = null;

		public Role GetModeratorRole()
		{
			if (moderatorRole == null)
			{
				moderatorRole = new Role
				{
					Id = 1,
					Name = "MODERATOR"
				};
			}
			return moderatorRole;
		}

		public Role GetRoleById(int id)
		{
			throw new NotImplementedException();
		}

		public Role GetUserRole()
		{
			if (userRole == null)
			{
				userRole = new Role
				{
					Id = 1,
					Name = "USER"
				};
			}
			return userRole;
		}
	}
}