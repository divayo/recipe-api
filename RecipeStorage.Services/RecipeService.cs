using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RecipeStorage.Common.Dto.Requests;
using RecipeStorage.Common.Dto.Responses;
using RecipeStorage.Common.Exceptions;
using RecipeStorage.Data;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeStorage.Services
{
    public class RecipeService : IRecipeService
    {
        private readonly RecipeStorageDbContext _dbContext;
        private readonly ILogger<RecipeService> _logger;

        public RecipeService(RecipeStorageDbContext dbContext, ILogger<RecipeService> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        /// <summary>
        ///     Create new recipe
        /// </summary>
        /// <param name="dto"><see cref="PostRecipeRequestDto"/></param>
        /// <returns>true or false</returns>
        /// <exception cref="DuplicateRecipeException">If the recipe name already exists</exception>
        /// <exception cref="Exception">General exception</exception>
        public async Task<bool> CreateRecipeAsync(PostRecipeRequestDto dto)
        {
            var recipe = await _dbContext.Recipes.FirstOrDefaultAsync(r => r.Name.ToLower() == dto.Name.ToLower());

            if (recipe != null) throw new DuplicateRecipeException();

            var added =  await _dbContext.Recipes.AddAsync(new Data.Entities.Recipe { Name = dto.Name, ShortDescription = dto.ShortDescription });
            var result = await _dbContext.SaveChangesAsync();

            return result == 1;
        }

        /// <summary>
        ///     Get recipe
        /// </summary>
        /// <param name="dto"><see cref="GetRecipeRequestDto"/></param>
        /// <returns><see cref="GetRecipeResponseDto"/></returns>
        /// <exception cref="RecipeNotFoundException">When there's no data found for given recipe id.</exception>
        /// <exception cref="Exception">General exception</exception>
        public async Task<GetRecipeResponseDto> GetRecipeAsync(GetRecipeRequestDto dto)
        {
            var result = await _dbContext.Recipes
                                            .Include(r => r.RecipeIngredients).ThenInclude(ri => ri.Ingredient)
                                            .Include(r => r.RecipeRatings)
                                            .FirstOrDefaultAsync(x => x.Id == dto.RecipeId);

            if (result == null) throw new RecipeNotFoundException();

            return new GetRecipeResponseDto
            {
                Id = result.Id,
                Name = result.Name,
                ShortDescription = result.ShortDescription,
                NumberOfRatings = result.RecipeRatings.Count,
                Ingredients = result.RecipeIngredients.Select(x => new Common.Dto.RecipeIngredientDto { Id =x.Id, Name = x.Ingredient.Name, Note = x.Note, Quanity = x.Quantity })
            };
        }
    }
}
