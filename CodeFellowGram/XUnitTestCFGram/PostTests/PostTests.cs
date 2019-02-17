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

namespace XUnitTestCFGram.PostTests
{
    public class PostTests
    {
        /// <summary>
        /// Create Tests
        /// </summary>
        [Fact]
        public async void CanCreatePost()
        {
            DbContextOptions<PostDbContext> options = new DbContextOptionsBuilder<PostDbContext>().UseInMemoryDatabase("CreatePost").Options;

            using (PostDbContext context = new PostDbContext(options))
            {
                Post post = new Post();
                post.Author = "Bob";
                post.ImageURL = "test.img";
                post.Caption = "Hello world!";

                PostManager postService = new PostManager(context);
                await postService.SaveAsync(post);
                Post result = await context.Posts.FirstOrDefaultAsync(h => h.ID == post.ID);

                Assert.Equal(post, result);
            }
        }

        [Fact]
        public async void CanCreateEmptyPost()
        {
            DbContextOptions<PostDbContext> options = new DbContextOptionsBuilder<PostDbContext>().UseInMemoryDatabase("CreateEmptyPost").Options;

            using (PostDbContext context = new PostDbContext(options))
            {
                Post post = new Post();

                PostManager postService = new PostManager(context);
                await postService.SaveAsync(post);
                Post result = await context.Posts.FirstOrDefaultAsync(h => h.ID == post.ID);

                Assert.Null(result.Author);
            }
        }

        /// <summary>
        /// Read Tests
        /// </summary>
        [Fact]
        public async void CanReadSinglePost()
        {
            DbContextOptions<PostDbContext> options = new DbContextOptionsBuilder<PostDbContext>().UseInMemoryDatabase("ReadPost").Options;

            using (PostDbContext context = new PostDbContext(options))
            {
                PostManager postService = new PostManager(context);
                Post post = new Post();
                post.Author = "John";
                post.ImageURL = "test.img";
                post.Caption = "Read me!";
                await postService.SaveAsync(post);

                Post result = await postService.FindPost(post.ID);

                Assert.Equal(post, result);
            }
        }

        [Fact]
        public async void CanReadAllPosts()
        {
            DbContextOptions<PostDbContext> options = new DbContextOptionsBuilder<PostDbContext>().UseInMemoryDatabase("ReadAllPosts").Options;

            using (PostDbContext context = new PostDbContext(options))
            {
                PostManager postService = new PostManager(context);
                Post post = new Post();
                post.Author = "John";
                post.ImageURL = "test.img";
                post.Caption = "Read me!";
                await postService.SaveAsync(post);

                Post postTwo = new Post();
                postTwo.Author = "Bob";
                postTwo.ImageURL = "new.img";
                postTwo.Caption = "Hello world!";
                await postService.SaveAsync(postTwo);

                Post postThree = new Post();
                postThree.Author = "Tim";
                postThree.ImageURL = "house.img";
                postThree.Caption = "Hi!";
                await postService.SaveAsync(postThree);

                var result = await postService.GetPosts();
                int count = result.Count;

                Assert.Equal(3, count);
            }
        }

        [Fact]
        public async void CanReadEmptyPostTable()
        {
            DbContextOptions<PostDbContext> options = new DbContextOptionsBuilder<PostDbContext>().UseInMemoryDatabase("EmptyPost").Options;

            using (PostDbContext context = new PostDbContext(options))
            {
                PostManager postService = new PostManager(context);

                var result = await postService.GetPosts();
                int count = result.Count;

                Assert.Equal(0, count);
            }
        }

        /// <summary>
        /// Edit Tests
        /// </summary>
        [Fact]
        public async void CanEditPost()
        {
            DbContextOptions<PostDbContext> options = new DbContextOptionsBuilder<PostDbContext>().UseInMemoryDatabase("EditPost").Options;

            using (PostDbContext context = new PostDbContext(options))
            {
                PostManager postService = new PostManager(context);
                Post post = new Post();
                post.Author = "Bob";
                post.ImageURL = "test.img";
                post.Caption = "Hello world!";
                await postService.SaveAsync(post);

                Post edit = new Post();
                edit.Caption = "Edited data";
                post.Caption = edit.Caption;
                await postService.SaveAsync(post);
                Post result = await context.Posts.FirstOrDefaultAsync(h => h.ID == post.ID);

                Assert.Equal("Edited data", result.Caption);
            }
        }

        /// <summary>
        /// Delete Tests
        /// </summary>
        [Fact]
        public async void CanDeletePost()
        {
            DbContextOptions<PostDbContext> options = new DbContextOptionsBuilder<PostDbContext>().UseInMemoryDatabase("DeletePost").Options;

            using (PostDbContext context = new PostDbContext(options))
            {
                PostManager postService = new PostManager(context);
                Post post = new Post();
                post.Author = "John";
                post.ImageURL = "test.img";
                post.Caption = "Read me!";
                await postService.SaveAsync(post);

                Post postTwo = new Post();
                postTwo.Author = "Bob";
                postTwo.ImageURL = "new.img";
                postTwo.Caption = "Hello world!";
                await postService.SaveAsync(postTwo);

                Post postThree = new Post();
                postThree.Author = "Tim";
                postThree.ImageURL = "house.img";
                postThree.Caption = "Hi!";
                await postService.SaveAsync(postThree);

                await postService.DeleteAsync(postTwo.ID);
                var result = await context.Posts.FirstOrDefaultAsync(p => p.ID == postTwo.ID);

                Assert.Null(result);
            }
        }

        [Fact]
        public async void CannotDeletePost()
        {
            DbContextOptions<PostDbContext> options = new DbContextOptionsBuilder<PostDbContext>().UseInMemoryDatabase("CanotDeletePost").Options;

            using (PostDbContext context = new PostDbContext(options))
            {
                PostManager postService = new PostManager(context);
                Post post = new Post();
                post.Author = "John";
                post.ImageURL = "test.img";
                post.Caption = "Read me!";
                await postService.SaveAsync(post);

                Post postTwo = new Post();
                postTwo.Author = "Bob";
                postTwo.ImageURL = "new.img";
                postTwo.Caption = "Hello world!";
                await postService.SaveAsync(postTwo);

                Post postThree = new Post();
                postThree.Author = "Tim";
                postThree.ImageURL = "house.img";
                postThree.Caption = "Hi!";
                await postService.SaveAsync(postThree);

                await postService.DeleteAsync(4);
                var result = await context.Posts.ToListAsync();

                Assert.Equal(3, result.Count);
            }
        }
    }
}
