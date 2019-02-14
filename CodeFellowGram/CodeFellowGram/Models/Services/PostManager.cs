using CodeFellowGram.Data;
using CodeFellowGram.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeFellowGram.Models.Services
{
    public class PostManager : IPost
    {
        private readonly PostDbContext _context;

        public PostManager(PostDbContext context)
        {
            _context = context;
        }
        
        /// <summary>
        /// Finds a post in the Post database with a matching primary key, stores it as a new Post type variable, and returns it.
        /// </summary>
        /// <param name="id">Primary Key value</param>
        /// <returns>Matching post or null</returns>
        public async Task<Post> FindPost(int id)
        {
            Post post = await _context.Posts.FirstOrDefaultAsync(p => p.ID == id);

            return post;
        }

        /// <summary>
        /// Returns a list of all posts in the Post database.
        /// </summary>
        /// <returns>List of posts</returns>
        public async Task<List<Post>> GetPosts()
        {
            return await _context.Posts.ToListAsync();
        }

        /// <summary>
        /// After receiving a Post object from the form data on a page, it attempts to find a matching primary key in the database. If no match is found the given Post object is added to the table. If a match is found then the properties of the exsisting object are updated with the data from the form.
        /// </summary>
        /// <param name="Post">Post object created from form data</param>
        /// <returns>New or updated Post object</returns>
        public async Task SaveAsync(Post Post)
        {
            if (await _context.Posts.FirstOrDefaultAsync(m => m.ID == Post.ID) == null)
            {
                _context.Posts.Add(Post);
            }
            else
            {
                _context.Posts.Update(Post);
            }
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            Post post = await _context.Posts.FirstOrDefaultAsync(p => p.ID == id);

            if (post != null)
            {
                _context.Posts.Remove(post);
                await _context.SaveChangesAsync();
            }
        }
    }
}
