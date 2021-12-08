using HeapOverflow.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeapOverflow.DAO.Inter
{
    public interface IUsersDAO
    {
        Users GetUserById(int id);
        Users AddUser(Users user);
        Users UpdateUser(Users user);
        Users RemoveUser(Users user);
    }
}
