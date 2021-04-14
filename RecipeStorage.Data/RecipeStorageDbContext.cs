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

        public DbSet<Recipe> Recipes { get; set; }
    }
}
