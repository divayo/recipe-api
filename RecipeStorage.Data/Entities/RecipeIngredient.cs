using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeStorage.Data.Entities
{
    public class RecipeIngredient
    {
        /// <summary>
        ///     Id of the recipe
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        /// <summary>
        ///     Recipe Id
        /// </summary>
        [Required]
        [ForeignKey("Recipe")]
        public long RecipeId { get;set; }

        /// <summary>
        ///     Ingredient Id
        /// </summary>
        [Required]
        [ForeignKey("Ingredient")]
        public long IngredientId { get; set; }

        /// <summary>
        ///     Quantity of the ingredient
        /// </summary>
        /// <remarks>
        ///     2 US cups, 500 ml, 50 gr., 1 tsp etc
        /// </remarks>
        [Required]
        [StringLength(32)]
        public string Quantity { get; set; }

        /// <summary>
        ///     Remarks about the ingredient
        /// </summary>
        /// <remarks>
        ///     For example: "Chopped" or "Melted"
        /// </remarks>
        [StringLength(128)]
        public string Note { get; set; }

        /// <summary>
        ///     If the ingredient is optional
        /// </summary>
        public bool IsOptional { get; set; }

        public virtual Recipe Recipe { get; set; }

        public virtual Ingredient Ingredient { get; set; }
    }
}
