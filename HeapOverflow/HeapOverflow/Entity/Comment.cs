﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HeapOverflow.Entity
{
    public class Comment
    {
        public int Id { get; set; }
        public Users User { get; set; }
        public Post Post { get; set; }
        public string Topic { get; set; }
        public int LikeCount { get; set; }
        public int DislikeCount { get; set; }

        public override string ToString()
        {
            return string.Format("Comment({0}, {1}, {2}, {3}, {4}, {5})", Id, User, Post, Topic, LikeCount, DislikeCount);
        }
    }
}