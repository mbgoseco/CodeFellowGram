using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeFellowGram.Models.Interfaces
{
    public interface IComment
    {
        // Save
        Task SaveAsync(Comment comment);
    }
}
