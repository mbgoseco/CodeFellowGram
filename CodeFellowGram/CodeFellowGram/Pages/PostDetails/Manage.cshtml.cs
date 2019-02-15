using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CodeFellowGram.Models;
using CodeFellowGram.Models.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage.Blob;

namespace CodeFellowGram.Pages.PostDetails
{
    public class ManageModel : PageModel
    {
        private readonly IPost _post;

        public ManageModel(IPost post, IConfiguration configuration)
        {
            _post = post;
            BlobImage = new Models.Utilities.Blob(configuration);
        }

        [FromRoute]
        public int? ID { get; set; }
        [BindProperty]
        public Post Post { get; set; }
        [BindProperty]
        public IFormFile Image { get; set; }
        public Models.Utilities.Blob BlobImage { get; set; }

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

            if (Image != null)
            {
                // Here be blob stuff
                var filePath = Path.GetTempFileName();

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await Image.CopyToAsync(stream);
                }

                // Get Container
                var container = await BlobImage.GetContainer("images");

                // Upload Image
                BlobImage.UploadFile(container, Image.FileName, filePath);

                // Get uploaded image and add to db
                CloudBlob blob = await BlobImage.GetBlob(Image.FileName, container.Name);
                post.ImageURL = blob.Uri.ToString();

            }

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