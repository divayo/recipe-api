using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeStorage.Common.Dto.Requests
{
    /// <summary>
    ///     Contains the values for a request for recipe details
    /// </summary>
    public class GetRecipeRequestDto
    {
        /// <summary>
        ///     Id of the recipe to retrieve
        /// </summary>
        public int RecipeId { get; set; }
    }
}
