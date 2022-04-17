using HeapOverflow.DAO.Inter;
using HeapOverflow.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HeapOverflow.DAO.Impl.RAM
{
	public class CommentRAMDAO : ICommentDAO
	{
		private static List<Comment> comments = new List<Comment>();

		public Comment AddComment(Comment comment)
		{
			comment.Id = comments.Count;
			comments.Add(comment);
			return comment;
		}

		public Comment GetCommentById(int id)
		{
			foreach (Comment comment in comments)
				if (comment.Id == id)
					return comment;
			return null;
		}

		public List<Comment> GetCommentsByPost(Post post)
		{
			List<Comment> commentsByPost = new List<Comment>();
			foreach (Comment comment in comments)
				if (comment.Post.Id == post.Id)
					commentsByPost.Add(comment);
			return commentsByPost;
		}

		public int GetCommentsSizeByPost(Post post)
		{
			int count = 0;
			foreach (Comment comment in comments)
				if (comment.Post.Id == post.Id)
					count++;
			return count;
		}

		public void RemoveComment(int id)
		{
			foreach (Comment comment in comments)
				if (comment.Id == id)
				{
					comments.Remove(comment);
					break;
				}
		}

		public void RemoveCommentByPost(int postId)
		{
			bool exist = true;
			while (exist)
			{
				exist = false;
				foreach (Comment comment in comments)
					if (comment.Post.Id == postId)
					{
						exist = true;
						comments.Remove(comment);
						break;
					}
			}
		}

		public Comment UpdateComment(Comment comment)
		{
			throw new NotImplementedException();
		}
	}
}