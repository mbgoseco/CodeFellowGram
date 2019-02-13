using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeFellowGram.Models.Interfaces
{
    public interface IPost
    {
        // Delete
        Task DeleteAsync(int id);

        // Find
        Task<Post> FindPost(int id);

        // Get All
        Task<List<Post>> GetPosts();

        // Save
        Task SaveAsync(Post Post);
    }
}
