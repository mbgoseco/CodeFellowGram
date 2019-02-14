using CodeFellowGram.Data;
using CodeFellowGram.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeFellowGram.Models.Services
{
    public class CommentManager : IComment
    {
        private readonly PostDbContext _context;

        public CommentManager(PostDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Adds a new user comment to the Comment table relative to the post it was intended for.
        /// </summary>
        /// <param name="comment">New Comment object</param>
        /// <returns>New Comment object</returns>
        public async Task SaveAsync(Comment comment)
        {
            await _context.Comments.AddAsync(comment);
            await _context.SaveChangesAsync();
        }
    }
}
