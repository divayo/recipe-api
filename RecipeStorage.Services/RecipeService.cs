using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RecipeStorage.Common.Dto.Requests;
using RecipeStorage.Common.Dto.Responses;
using RecipeStorage.Common.Exceptions;
using RecipeStorage.Data;
using System;
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
        ///     Get recipe
        /// </summary>
        /// <param name="dto"><see cref="GetRecipeRequestDto"/></param>
        /// <returns><see cref="GetRecipeResponseDto"/></returns>
        /// <exception cref="RecipeNotFoundException">When there's no data found for given recipe id.</exception>
        /// <exception cref="Exception">General exception</exception>
        public async Task<GetRecipeResponseDto> GetRecipeAsync(GetRecipeRequestDto dto)
        {
            var result = await _dbContext.Recipes.FirstOrDefaultAsync(x => x.Id == dto.RecipeId);

            if (result == null) throw new RecipeNotFoundException();

            return new GetRecipeResponseDto
            {
                Id = result.Id,
                Name = result.Name,
                ShortDescription = result.ShortDescription
            };
        }
    }
}
