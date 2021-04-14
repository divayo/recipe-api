using RecipeStorage.Common.Dto.Requests;
using RecipeStorage.Common.Dto.Responses;
using RecipeStorage.Common.Exceptions;
using System;
using System.Threading.Tasks;

namespace RecipeStorage.Services
{
    public interface IRecipeService
    {
        /// <summary>
        ///     Get recipe
        /// </summary>
        /// <param name="dto"><see cref="GetRecipeRequestDto"/></param>
        /// <returns><see cref="GetRecipeResponseDto"/></returns>
        /// <exception cref="RecipeNotFoundException">When there's no data found for given recipe id.</exception>
        /// <exception cref="Exception">General exception</exception>
        Task<GetRecipeResponseDto> GetRecipeAsync(GetRecipeRequestDto dto);
    }
}