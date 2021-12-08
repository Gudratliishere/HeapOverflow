using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HeapOverflow.Entity
{
    public class Admin
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Status { get; set; }

        public override string ToString()
        {
            return string.Format("Admin({0}, {1}, {2}, {3}, {4}, {5}", Id, Name, Surname, Email, Password, Status);
        }
    }
}