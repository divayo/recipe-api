using Microsoft.EntityFrameworkCore;
using RecipeStorage.Data.Entities;
using System;

namespace RecipeStorage.Data
{
    public class RecipeStorageDbContext : DbContext
    {
        public RecipeStorageDbContext(DbContextOptions options)
            : base(options)
        {

        }

        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<RecipeIngredient> RecipeIngredients { get; set; }
        public DbSet<RecipeRating> RecipeRatings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Ingredient>().HasIndex(e => e.Name).IsUnique(); // unique name
            modelBuilder.Entity<Recipe>().HasIndex(e => e.Name).IsUnique(); // unique name
            modelBuilder.Entity<RecipeRating>().HasIndex(e => new { e.RecipeId, e.UserId }).IsUnique(); // user has one rating per recipe
        }
    }
}
