using System.ComponentModel.DataAnnotations;

namespace RecipeBook.Models
{
    public class Ingredient
    {
        [Key]
        public int IngredientId { get; set; }
        public string IngredientName { get; set; } = string.Empty;

    }

}