using HeapOverflow.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeapOverflow.DAO.Inter
{
    public interface ICommentDAO
    {
        List<Comment> GetCommentsByUser(Users user);
        List<Comment> GetCommentsByPost(Post post);
        Comment AddComment(Comment comment);
        Comment UpdateComment(Comment comment);
        Comment RemoveComment(Comment comment);
    }
}
