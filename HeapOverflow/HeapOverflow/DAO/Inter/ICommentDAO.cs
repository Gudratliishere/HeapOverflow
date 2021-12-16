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
        List<Comment> GetCommentsByPost(Post post);
		Comment GetCommentById(int id);
        Comment AddComment(Comment comment);
        Comment UpdateComment(Comment comment);
        void RemoveComment(int id);
        void RemoveCommentByPost(int postId);
    }
}
