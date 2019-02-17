using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CodeFellowGram.Models
{
    public class Comment
    {
        public int ID { get; set; }
        public int PostID { get; set; }
        [Required]
        public string User { get; set; }
        [Required]
        public string UserComment { get; set; }
    }
}
