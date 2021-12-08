using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HeapOverflow.Entity
{
    public class Users
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhotoPath { get; set; }
        public string Description { get; set; }
        public int Post { get; set; }
        public int Star { get; set; }

        public override string ToString()
        {
            return string.Format("Users({0}, {1}, {2}, {3}, {4}, {5}, {6}", Id, Name, Surname, PhotoPath, Description, Post, Star);
        }
    }
}