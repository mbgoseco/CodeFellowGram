using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeFellowGram.Models;
using CodeFellowGram.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CodeFellowGram.Pages.PostDetails
{
    public class AddCommentModel : PageModel
    {
        private readonly IPost _post;
        private readonly IComment _comment;

        public AddCommentModel(IPost post)
        {
            _post = post;
        }

        public AddCommentModel(IComment comment)
        {
            _comment = comment;
        }

        [FromRoute]
        public int ID { get; set; }
        public Post Post { get; set; }
        [BindProperty]
        public Comment Comment { get; set; }

        public void OnGet()
        {
            Comment = new Comment();
        }

        public async Task<IActionResult> OnPost()
        {
            var comment = new Comment();

            comment.PostID = ID;
            comment.User = Comment.User;
            comment.UserComment = Comment.UserComment;

            await _comment.SaveAsync(comment);
            return RedirectToPage("/PostDetails/Index", ID);
        }
    }
}