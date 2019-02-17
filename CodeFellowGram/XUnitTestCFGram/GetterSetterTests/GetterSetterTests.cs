using System;
using Xunit;
using CodeFellowGram.Data;
using CodeFellowGram.Models;
using CodeFellowGram.Pages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace XUnitTestCFGram.GetterSetterTests
{
    public class GetterSetterTests
    {
        /// <summary>
        /// Post model getter/setter tests
        /// </summary>
        [Fact]
        public void CanGetAuthor()
        {
            Post post = new Post();

            post.Author = "Mike";

            Assert.Equal("Mike", post.Author);
        }

        [Fact]
        public void CanSetAuthor()
        {
            Post post = new Post();
            post.Author = "Mike";

            post.Author = "Bobby";

            Assert.Equal("Bobby", post.Author);
        }

        [Fact]
        public void CanGetImageURL()
        {
            Post post = new Post();

            post.ImageURL = "test.img";

            Assert.Equal("test.img", post.ImageURL);
        }

        [Fact]
        public void CanSetImageURL()
        {
            Post post = new Post();
            post.ImageURL = "test.img";

            post.ImageURL = "newImage.img";

            Assert.Equal("newImage.img", post.ImageURL);
        }

        [Fact]
        public void CanGetCaption()
        {
            Post post = new Post();

            post.Caption = "This is my post.";

            Assert.Equal("This is my post.", post.Caption);
        }

        [Fact]
        public void CanSetCaption()
        {
            Post post = new Post();
            post.Caption = "This is my post.";

            post.Caption = "There are many like it, but this one is mine.";

            Assert.Equal("There are many like it, but this one is mine.", post.Caption);
        }


        /// <summary>
        /// Comment model getter/setter tests
        /// </summary>
        [Fact]
        public void CanGetPostID()
        {
            Comment comment = new Comment();

            comment.PostID = 1;

            Assert.Equal(1, comment.PostID);
        }

        [Fact]
        public void CanSetPostID()
        {
            Comment comment = new Comment();
            comment.PostID = 1;

            comment.PostID = 2;

            Assert.Equal(2, comment.PostID);
        }

        [Fact]
        public void CanGetUser()
        {
            Comment comment = new Comment();

            comment.User = "Tommy";

            Assert.Equal("Tommy", comment.User);
        }

        [Fact]
        public void CanSetUser()
        {
            Comment comment = new Comment();
            comment.User = "Tommy";

            comment.User = "Joe123";

            Assert.Equal("Joe123", comment.User);
        }

        [Fact]
        public void CanGetUserComment()
        {
            Comment comment = new Comment();

            comment.UserComment = "This post sux!";

            Assert.Equal("This post sux!", comment.UserComment);
        }

        [Fact]
        public void CanSetUserComment()
        {
            Comment comment = new Comment();
            comment.UserComment = "This post sux!";

            comment.UserComment = "This post is awesome!";

            Assert.Equal("This post is awesome!", comment.UserComment);
        }
    }
}
