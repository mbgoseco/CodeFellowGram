using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeFellowGram.Models
{
    public class Comment
    {
        public int ID { get; set; }
        public int PostID { get; set; }
        public string User { get; set; }
        public string UserComment { get; set; }

        // Navigation
        //public Post Post { get; set; }
    }
}
