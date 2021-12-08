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
        public int LikeCount { get; set; }
        public int DislikeCount { get; set; }
        public Users User { get; set; }
        public DateTime PostDate { get; set; }

        public override string ToString()
        {
            return string.Format("Post({0}, {1}, {2}, {3}, {4}, {5}, {6})", Id, Name, Topic, LikeCount, DislikeCount, User, PostDate);
        }
    }
}