using System.ComponentModel.DataAnnotations;

namespace RecipeBook.Models
{
    public class Recipe
    {
        [Key]
        public int Id { get; set; }
        public string RecipeName { get; set; }
        public int ServingSize { get; set; }
        public string RecipeSteps { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public ICollection<RecipeIngredient> RecipeIngredients { get; } = new List<RecipeIngredient>();
    }
}

