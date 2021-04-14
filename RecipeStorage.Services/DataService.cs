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

            dbContext.Ingredients.Add(new Data.Entities.Ingredient { Id = 1, Name = "Apples" });
            dbContext.Ingredients.Add(new Data.Entities.Ingredient { Id = 2, Name = "Granma's love" });
            dbContext.Ingredients.Add(new Data.Entities.Ingredient { Id = 3, Name = "Cinnamon" });

            dbContext.RecipeIngredients.Add(new Data.Entities.RecipeIngredient { Id = 1, IngredientId = 1, RecipeId = 1, Quantity = "6", Note = "Sliced" });
            dbContext.RecipeIngredients.Add(new Data.Entities.RecipeIngredient { Id = 2, IngredientId = 2, RecipeId = 1, Quantity = "As much as possible" });
            dbContext.RecipeIngredients.Add(new Data.Entities.RecipeIngredient { Id = 3, IngredientId = 3, RecipeId = 1, Quantity = "1 teaspoon" });

            dbContext.RecipeRatings.Add(new Data.Entities.RecipeRating { Id = 1, RecipeId = 1, RatingValue = 10, UserId = Guid.NewGuid() });

            dbContext.SaveChanges();
        }
    }
}
