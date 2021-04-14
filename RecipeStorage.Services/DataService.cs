using RecipeStorage.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeStorage.Services
{
    public class DataService
    {
        /// <summary>
        ///     Add seed data to database
        /// </summary>
        /// <param name="dbContext"><see cref="RecipeStorageDbContext"/></param>
        /// <remarks>
        ///     Adds 2 recipes
        /// </remarks>
        public static void AddSeedData(RecipeStorageDbContext dbContext)
        {
            dbContext.Recipes.Add(new Data.Entities.Recipe { Id = 1, Name = "Granma's apple pie", ShortDescription = "Everyone's favourite." });
            dbContext.Recipes.Add(new Data.Entities.Recipe { Id = 2, Name = "Tomato soup", ShortDescription = "Nice with bread" });

            dbContext.SaveChanges();
        }
    }
}
