using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeFellowGram.Models.Interfaces
{
    public interface IComment
    {
        // Get All
        Task<List<Comment>> GetComments();

        // Save
        Task SaveAsync(Comment comment);
    }
}
