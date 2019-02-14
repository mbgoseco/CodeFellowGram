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
    public class ManageModel : PageModel
    {
        private readonly IPost _post;

        public ManageModel(IPost post)
        {
            _post = post;
        }

        [FromRoute]
        public int? ID { get; set; }
        [BindProperty]
        public Post Post { get; set; }

        public async Task OnGetAsync()
        {
            Post = await _post.FindPost(ID.GetValueOrDefault()) ?? new Post();
        }

        public async Task<IActionResult> OnPost()
        {
            var post = await _post.FindPost(ID.GetValueOrDefault()) ?? new Post();

            post.Author = Post.Author;
            post.ImageURL = Post.ImageURL;
            post.Caption = Post.Caption;

            await _post.SaveAsync(post);
            return RedirectToPage("/PostDetails/Index", new { id = post.ID });
        }

        public async Task<IActionResult> OnPostDelete()
        {
            if (ID != null)
            {
                await _post.DeleteAsync(ID.Value);
            }
            return RedirectToPage("/Index");
        }
    }
}