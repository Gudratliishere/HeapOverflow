using HeapOverflow.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeapOverflow.DAO.Inter
{
    public interface IPostDAO
    {
        List<Post> GetAll();
        List<Post> GetPostByUser(Users user);
        Post GetPostById(int id);
        Post AddPost(Post post);
        Post UpdatePost(Post post);
        Post RemovePost(Post post);
    }
}
