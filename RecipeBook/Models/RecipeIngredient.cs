using System.ComponentModel.DataAnnotations;

namespace RecipeBook.Models
{
    public class RecipeIngredient
    {
        [Key]
        public int Id { get; set; }
        public double Quantity { get; set; }
        public string Unit { get; set; }
        public Recipe Recipe { get; }
        public Ingredient Ingredient { get; set; }
        public int RecipeId { get; set; }
        public int IngredientId { get; set; }
    }
}
