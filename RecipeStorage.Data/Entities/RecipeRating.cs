using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeStorage.Data.Entities
{
    public class RecipeRating
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
        public long RecipeId { get; set; }

        /// <summary>
        ///     Value of the rating out of 10
        /// </summary>
        [Required]
        public int RatingValue { get; set; }

        /// <summary>
        ///  Id of the user who submitted the rating
        /// </summary>
        [Required]
        public Guid UserId { get; set; }

        public virtual Recipe Recipe { get; set; }
    }
}
