using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission7_ejake370.Models
{
    public class MovieSubmissionContext : DbContext
    {
        //Constructor
        public MovieSubmissionContext(DbContextOptions<MovieSubmissionContext> options) : base(options)
        {
            //Leave blank for now
        }

        public DbSet<Movie> movies { get; set; }
        public DbSet<Category> categories { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Category>().HasData(
                new Category { CategoryId = 1, CategoryName = "Action/Adventure"},
                new Category { CategoryId = 2, CategoryName = "Comedy"},
                new Category { CategoryId = 3, CategoryName = "Drama"},
                new Category { CategoryId = 4, CategoryName = "Family"},
                new Category { CategoryId = 5, CategoryName = "Horror/Suspense"},
                new Category { CategoryId = 6, CategoryName = "Miscellaneous"},
                new Category { CategoryId = 7, CategoryName = "Television"},
                new Category { CategoryId = 8, CategoryName = "VHS"}
                );
            mb.Entity<Movie>().HasData(
                new Movie
                {
                    MovieId = 1,
                    CategoryId = 1,
                    title = "Batman Begins",
                    year = "2005",
                    director = "Christopher Nolan",
                    rating = "PG-13",
                    edited = true,
                    lentTo = "",
                    notes = "Amazing movie"
                },
                new Movie
                {
                    MovieId = 2,
                    CategoryId = 1,
                    title = "The Dark Knight",
                    year = "2008",
                    director = "Christopher Nolan",
                    rating = "PG-13",
                    edited = true,
                    lentTo = "",
                    notes = "eveeen better movie!"
                },
                new Movie
                {
                    MovieId = 3,
                    CategoryId = 3,
                   
                    title = "Les Miserables",
                    year = "1998",
                    director = "Billie August",
                    rating = "PG-13",
                    edited = false,
                    lentTo = "Dave",
                    notes = "An honest tear-jerker"
                }
             );
        }
    }
}
