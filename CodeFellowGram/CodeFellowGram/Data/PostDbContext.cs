using CodeFellowGram.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeFellowGram.Data
{
    public class PostDbContext : DbContext
    {
        public PostDbContext(DbContextOptions<PostDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>().HasData(
                new Post
                {
                    ID = 1,
                    Author = "Mike G",
                    ImageURL = "https://via.placeholder.com/400?text=CodeFellowGram",
                    Caption = "First post!!!"
                },
                new Post
                {
                    ID = 2,
                    Author = "Mike F",
                    ImageURL = "https://via.placeholder.com/400?text=CodeFellowGram",
                    Caption = "DJ Mike"
                },
                new Post
                {
                    ID = 3,
                    Author = "Reeeeeegan",
                    ImageURL = "https://via.placeholder.com/400?text=CodeFellowGram",
                    Caption = "Never skip leg day!"
                },
                new Post
                {
                    ID = 4,
                    Author = "Nasty Nate",
                    ImageURL = "https://via.placeholder.com/400?text=CodeFellowGram",
                    Caption = "Gimme that fruit cup!"
                },
                new Post
                {
                    ID = 5,
                    Author = "HunterT",
                    ImageURL = "https://via.placeholder.com/400?text=CodeFellowGram",
                    Caption = "We can't stop here. This is bat country!"
                }
            );
        }

        public DbSet<Post> Posts { get; set; }
    }
}
