using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeStorage.Common.Dto.Responses
{
    public class GetRecipeResponseDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
    }
}
