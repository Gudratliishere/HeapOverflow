using HeapOverflow.DAO.Inter;
using HeapOverflow.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HeapOverflow.DAO.Impl.RAM
{
	public class PostRAMDAO : IPostDAO
	{
		private static List<Post> posts = new List<Post>();

		public Post AddPost(Post post)
		{
			post.Id = posts.Count;
			posts.Add(post);
			return post;
		}

		public List<Post> GetAll()
		{
			return posts;
		}

		public List<Post> GetAllByPagination(int offset, int next)
		{
			List<Post> resultPosts = new List<Post>();
			try
			{
				for (int i = offset; i < offset + next; i++)
					resultPosts.Add(posts.ElementAt(i));
			}
			catch
			{
				return resultPosts;
			}
			return resultPosts;
		}

		public Post GetPostById(int id)
		{
			foreach (Post post in posts)
				if (post.Id == id)
					return post;
			return null;
		}

		public List<Post> GetPostByUser(Users user)
		{
			List<Post> resultPosts = new List<Post>();
			foreach (Post post in posts)
				if (post.User.Id == user.Id)
					resultPosts.Add(post);
			return resultPosts;
		}

		public List<Post> GetPostWhereNameContain(string key, int offset, int next)
		{
			List<Post> seacrhedPosts = new List<Post>();
			foreach (Post post in posts)
				if (post.Name.Contains(key))
					seacrhedPosts.Add(post);

			List<Post> resultPosts = new List<Post>();
			try
			{
				for (int i = offset; i < offset + next; i++)
					resultPosts.Add(seacrhedPosts.ElementAt(i));
			}
			catch
			{
				return resultPosts;
			}
			return resultPosts;
		}

		public List<Post> GetPostWhereNameOrTopicContain(string key, int offset, int next)
		{
			List<Post> seacrhedPosts = new List<Post>();
			foreach (Post post in posts)
				if (post.Name.Contains(key) || post.Topic.Contains(key))
					seacrhedPosts.Add(post);

			List<Post> resultPosts = new List<Post>();
			try
			{
				for (int i = offset; i < offset + next; i++)
					resultPosts.Add(seacrhedPosts.ElementAt(i));
			}
			catch
			{
				return resultPosts;
			}
			return resultPosts;
		}

		public List<Post> GetPostWhereTopicContain(string key, int offset, int next)
		{
			List<Post> seacrhedPosts = new List<Post>();
			foreach (Post post in posts)
				if (post.Topic.Contains(key))
					seacrhedPosts.Add(post);

			List<Post> resultPosts = new List<Post>();
			try
			{
				for (int i = offset; i < offset + next; i++)
					resultPosts.Add(seacrhedPosts.ElementAt(i));
			}
			catch
			{
				return resultPosts;
			}
			return resultPosts;
		}

		public int GetSize()
		{
			return posts.Count;
		}

		public Post RemovePost(Post post)
		{
			foreach (Post rpost in posts)
				if (rpost.Id == post.Id)
				{
					posts.Remove(rpost);
					break;
				}
			return post;
		}

		public Post UpdatePost(Post post)
		{
			throw new NotImplementedException();
		}
	}
}