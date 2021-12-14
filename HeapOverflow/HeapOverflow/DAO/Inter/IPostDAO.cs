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
        int GetSize();
        List<Post> GetAll();
        List<Post> GetAllByPagination(int offset, int next);
        List<Post> GetPostByUser(Users user);
        List<Post> GetPostWhereNameContain(string key, int offset, int next);
        List<Post> GetPostWhereTopicContain(string key, int offset, int next);
        List<Post> GetPostWhereNameOrTopicContain(string key, int offset, int next);
        Post GetPostById(int id);
        Post AddPost(Post post);
        Post UpdatePost(Post post);
        Post RemovePost(Post post);
    }
}
