using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CodeFellowGram.Models
{
    public class Post
    {
        public int ID { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public string ImageURL { get; set; }
        public string Caption { get; set; }

        // Navigation
        public ICollection<Comment> Comments { get; set; }
    }
}
