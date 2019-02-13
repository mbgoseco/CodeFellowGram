using CodeFellowGram.Data;
using CodeFellowGram.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeFellowGram.Models.Services
{
    public class PostManager : IPost
    {
        private readonly PostDbContext _contest;

        public PostManager(PostDbContext context)
        {
            _contest = context;
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Post> FindPost(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Post>> GetPosts()
        {
            throw new NotImplementedException();
        }

        public Task SaveAsync(Post Post)
        {
            throw new NotImplementedException();
        }
    }
}
