using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HeapOverflow.Entity
{
    public class UserLogin
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Status { get; set; }
        public Role Role { get; set; }
        public Users User { get; set; }

        public override string ToString()
        {
            return string.Format("UserLogin({0}, {1}, {2}, {3}, {4}, {5}, {6})", Id, Username, Email, Status, Role, User);
        }
    }
}