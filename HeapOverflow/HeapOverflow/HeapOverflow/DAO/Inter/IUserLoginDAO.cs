using HeapOverflow.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeapOverflow.DAO.Inter
{
    public interface IUserLoginDAO
    {
        List<UserLogin> GetAll();
        List<UserLogin> GetUserLoginByStatus(string email);
        List<UserLogin> GetUserLoginByRole(Role role);
        UserLogin GetUserLoginById(int id);
        UserLogin GetUserLoginByUsername(string username);
        UserLogin GetUserLoginByEmail(string email);
        UserLogin GetUserLoginByUser(Users user);
        UserLogin AddUserLogin(UserLogin login);
        UserLogin UpdateUserLogin(UserLogin login);
        UserLogin RemoveUserLogin(UserLogin login);
    }
}
