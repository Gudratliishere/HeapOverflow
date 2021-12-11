using HeapOverflow.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeapOverflow.DAO.Inter
{
    public interface IRoleDAO
    {
        Role GetRoleById(int id);
        Role GetUserRole();
        Role GetModeratorRole();
    }
}
