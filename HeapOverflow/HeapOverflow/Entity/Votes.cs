using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HeapOverflow.Entity
{
    public class Votes
    {
        public int Id { get; set; }
        public UserLogin User { get; set; }
        public Post Post { get; set; }
        public int Vote { get; set; }

        public override string ToString()
        {
            return string.Format("Votes({0}, {1}, {2}, {3}", Id, User, Post, Vote);
        }
    }
}