using System;
using Xunit;
using CodeFellowGram.Data;
using CodeFellowGram.Models;
using CodeFellowGram.Pages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using CodeFellowGram.Models.Services;
using System.Threading.Tasks;

namespace XUnitTestCFGram.CommentTets
{
    public class CommentTests
    {
        [Fact]
        public async void CanCreateComment()
        {
            DbContextOptions<PostDbContext> options = new DbContextOptionsBuilder<PostDbContext>().UseInMemoryDatabase("CreateComment").Options;

            using (PostDbContext context = new PostDbContext(options))
            {
                CommentManager CommentService = new CommentManager(context);
                Comment message = new Comment();
                message.PostID = 1;
                message.User = "Mike";
                message.UserComment = "Nice post!";

                await CommentService.SaveAsync(message);
                Comment result = await context.Comments.FirstOrDefaultAsync(h => h.ID == message.ID);

                Assert.Equal(message, result);
            }
        }

        [Fact]
        public async void CanCreateEmptyComment()
        {
            DbContextOptions<PostDbContext> options = new DbContextOptionsBuilder<PostDbContext>().UseInMemoryDatabase("CreateEmptyComment").Options;

            using (PostDbContext context = new PostDbContext(options))
            {
                CommentManager CommentService = new CommentManager(context);
                Comment message = new Comment();

                await CommentService.SaveAsync(message);
                Comment result = await context.Comments.FirstOrDefaultAsync(h => h.ID == message.ID);

                Assert.Null(result.UserComment);
            }
        }

        /// <summary>
        /// Read Tests
        /// </summary>
        [Fact]
        public async void CanReadAllComments()
        {
            DbContextOptions<PostDbContext> options = new DbContextOptionsBuilder<PostDbContext>().UseInMemoryDatabase("ReadAllComments").Options;

            using (PostDbContext context = new PostDbContext(options))
            {
                CommentManager CommentService = new CommentManager(context);
                Comment message = new Comment();
                message.PostID = 1;
                message.User = "Mike";
                message.UserComment = "Nice post!";
                await CommentService.SaveAsync(message);

                Comment messageTwo = new Comment();
                messageTwo.PostID = 1;
                messageTwo.User = "Tim";
                messageTwo.UserComment = "I agree!";
                await CommentService.SaveAsync(messageTwo);

                Comment messageThree = new Comment();
                messageThree.PostID = 2;
                messageThree.User = "Bob";
                messageThree.UserComment = "Comment belonging to different post";
                await CommentService.SaveAsync(messageThree);

                var result = await CommentService.GetComments();
                int count = result.Count;

                Assert.Equal(3, count);
            }
        }

        [Fact]
        public async void CanReadEmptyCommentTable()
        {
            DbContextOptions<PostDbContext> options = new DbContextOptionsBuilder<PostDbContext>().UseInMemoryDatabase("ReadEmptyCommentTable").Options;

            using (PostDbContext context = new PostDbContext(options))
            {
                CommentManager CommentService = new CommentManager(context);

                var result = await CommentService.GetComments();
                int count = result.Count;

                Assert.Equal(0, count);
            }
        }
    }
}
