using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeStorage.Data.Entities
{
    public class Recipe
    {
        /// <summary>
        ///     Id of the recipe
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        /// <summary>
        ///     Name of the recipe
        /// </summary>
        [Required]
        [StringLength(128)]
        public string Name { get; set; }

        /// <summary>
        ///     Short description of the recipe
        /// </summary>
        [StringLength(256)]
        public string ShortDescription { get; set; }
    }
}
