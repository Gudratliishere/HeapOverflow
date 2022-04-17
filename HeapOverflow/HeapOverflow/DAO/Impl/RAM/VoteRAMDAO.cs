using HeapOverflow.DAO.Inter;
using HeapOverflow.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HeapOverflow.DAO.Impl.RAM
{
	public class VoteRAMDAO : IVotesDAO
	{
		private static List<Votes> votes = new List<Votes>();

		public Votes AddVote(Votes vote)
		{
			vote.Id = votes.Count;
			votes.Add(vote);
			return vote;
		}

		public int GetDislikesCountByPost(Post post)
		{
			int count = 0;
			foreach (Votes vote in votes)
				if (vote.Post.Id == post.Id && vote.Vote == 0)
					count++;
			return count;
		}

		public int GetLikesCountByPost(Post post)
		{
			int count = 0;
			foreach (Votes vote in votes)
				if (vote.Post.Id == post.Id && vote.Vote == 1)
					count++;
			return count;
		}

		public Votes GetVote(UserLogin login, Post post)
		{
			foreach (Votes vote in votes)
				if (vote.Post.Id == post.Id && vote.User.Id == login.Id)
					return vote;
			return null;
		}

		public void RemoveVote(int voteId)
		{
			foreach (Votes vote in votes)
				if (vote.Id == voteId)
				{
					votes.Remove(vote);
					break;
				}
		}

		public void RemoveVotesByPost(int postId)
		{
			bool exist = true;
			while (exist)
			{
				exist = false;
				foreach (Votes vote in votes)
					if (vote.Post.Id == postId)
					{
						exist = true;
						votes.Remove(vote);
						break;
					}
			}
		}

		public Votes UpdateVote(Votes vote)
		{
			foreach (Votes updateVote in votes)
				if (updateVote.Id == vote.Id)
					updateVote.Vote = vote.Vote;
			return vote;
		}
	}
}