using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HeapOverflow.Entity
{
    public class Users
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public byte[] Photo { get; set; } = new byte[0];
        public string Description { get; set; } = string.Empty;
        public int Post { get; set; } = 0;

        public override string ToString()
        {
            return string.Format("Users({0}, {1}, {2}, {3}, {4}", Id, Name, Surname, Description, Post);
        }
    }
}