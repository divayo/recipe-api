using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeStorage.Common.Dto
{
    public class RecipeIngredientDto
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Quanity { get; set; }

        public string Note { get; set; }
    }
}
