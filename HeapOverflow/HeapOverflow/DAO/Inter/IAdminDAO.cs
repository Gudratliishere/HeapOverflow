using HeapOverflow.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeapOverflow.DAO.Inter
{
    public interface IAdminDAO
    {
        List<Admin> GetAdminByStatus(int status);
        Admin GetAdminById(int id);
        Admin GetAdminByEmail(string email);
        Admin AddAdmin(Admin admin);
        Admin UpdateAdmin(Admin admin);
        Admin RemoveAdmin(Admin admin);
    }
}
