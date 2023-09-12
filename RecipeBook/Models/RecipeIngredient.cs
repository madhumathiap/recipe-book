using System.ComponentModel.DataAnnotations;

namespace RecipeBook.Models
{
    public class RecipeIngredient
    {
        [Key]
        public int RecipeIngredientId { get; set; }

        public int Quantity { get; set; }

        public string Unit { get; set; }

        public Recipe Recipe { get; set; }

        public Ingredient Ingredient { get; set; }

    }

}