using HeapOverflow.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeapOverflow.DAO.Inter
{
    public interface IVotesDAO
    {
        int GetLikesCountByPost(Post post);
        int GetDislikesCountByPost(Post post);
        Votes GetVote(UserLogin login, Post post);
        Votes AddVote(Votes vote);
        Votes UpdateVote(Votes vote);
        Votes RemoveVote(Votes vote);
    }
}
