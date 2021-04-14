using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RecipeStorage.Common.Dto.Requests;
using RecipeStorage.Common.Dto.Responses;
using RecipeStorage.Common.Exceptions;
using RecipeStorage.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeStorage.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeController : ControllerBase
    {
        private readonly IRecipeService _recipeService;
        private readonly ILogger<RecipeController> _logger;

        public RecipeController(IRecipeService recipeService, ILogger<RecipeController> logger)
        {
            _recipeService = recipeService;
            _logger = logger;
        }

        /// <summary>
        ///     Get recipe details
        /// </summary>
        /// <param name="recipeId">Id of the recipe</param>
        /// <returns><see cref="GetRecipeResponseDto"/></returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /api/recipe?recipeId=1
        ///
        /// </remarks>
        /// <response code="200">Returns the recipe details</response>
        /// <response code="400">If recipe id is invalid</response>
        /// <response code="404">If the recipe id return no information</response>
        /// <response code="500">If an error occured on the server.</response>
        [HttpGet]
        public async Task<IActionResult> Get(int recipeId)
        {
            if (recipeId <= 0)
            {
                return BadRequest("Invalid Recipe Id.");
            }

            try
            {
                var result = await _recipeService.GetRecipeAsync(new Common.Dto.Requests.GetRecipeRequestDto { RecipeId = recipeId });
                return Ok(result);
            }
            catch (RecipeNotFoundException ex)
            {
                _logger.LogWarning($"Invalid request. No data found for recipe with id {recipeId}");
                return NotFound(recipeId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error retrieving recipe with id {recipeId}");
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        /// <summary>
        ///     Get recipe details
        /// </summary>
        /// <param name="dto"><see cref="PostRecipeRequestDto"/></param>
        /// <returns></returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /api/recipe
        ///     
        ///     {
        ///         "name" : "recipe_name",
        ///         "shortDescription" : "short description"
        ///     }
        ///
        /// </remarks>
        /// <response code="201">The recipe is succesfully created</response>
        /// <response code="400">The request is invalid or a recipe with that name already exists</response>
        /// <response code="500">If an error occured on the server.</response>
        [HttpPost]
        //[Authorize(Roles = "User, Adminstrator")]
        public async Task<IActionResult> Post([FromBody] PostRecipeRequestDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Name and description are required."); // Add some custom error handling
            }

            try
            {
                var result = await _recipeService.CreateRecipeAsync(dto);
                return new StatusCodeResult(StatusCodes.Status201Created);
            }
            catch(DuplicateRecipeException ex)
            {
                return BadRequest("A recipe with this name already exists");
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, $"Error creating new recipe");
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }
    }
}