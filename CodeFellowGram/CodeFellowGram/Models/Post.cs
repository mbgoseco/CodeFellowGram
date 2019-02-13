using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeFellowGram.Models
{
    public class Post
    {
        public int ID { get; set; }
        public string Author { get; set; }
        public string ImageURL { get; set; }
        public string Caption { get; set; }
        public ICollection<string> Comments { get; set; }
    }
}
