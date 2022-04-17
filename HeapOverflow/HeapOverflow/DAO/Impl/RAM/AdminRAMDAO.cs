using HeapOverflow.Config;
using HeapOverflow.DAO.Inter;
using HeapOverflow.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HeapOverflow.DAO.Impl
{
	public class AdminRAMDAO : IAdminDAO
	{
		private static List<Admin> admins = new List<Admin>();

		public AdminRAMDAO ()
		{
			Admin admin = new Admin
			{
				Name = "Dunay",
				Surname = "Qudretli",
				Email = "admin",
				Status = 1,
				Password = Cryption.Encrypt("admin")
			};
			admins.Add(admin);
		}

		public Admin AddAdmin(Admin admin)
		{
			admin.Id = admins.Count;
			admins.Add(admin);
			return admin;
		}

		public Admin GetAdminByEmail(string email)
		{
			foreach (Admin admin in admins)
				if (admin.Email == email)
					return admin;
			return null;
		}

		public Admin GetAdminById(int id)
		{
			foreach (Admin admin in admins)
				if (admin.Id == id)
					return admin;
			return null;
		}

		public List<Admin> GetAdminByStatus(int status)
		{
			throw new NotImplementedException();
		}

		public Admin RemoveAdmin(Admin admin)
		{
			throw new NotImplementedException();
		}

		public Admin UpdateAdmin(Admin admin)
		{
			throw new NotImplementedException();
		}
	}
}