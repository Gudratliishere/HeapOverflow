using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HeapOverflow.Entity
{
    public class Post
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Topic { get; set; }
        public UserLogin User { get; set; }
        public DateTime PostDate { get; set; }

        public override string ToString()
        {
            return string.Format("Post({0}, {1}, {2}, {3}, {4})", Id, Name, Topic, User, PostDate);
        }
    }
}