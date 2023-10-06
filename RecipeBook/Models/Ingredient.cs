using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace RecipeBook.Models
{
    public class Ingredient
    {
        [Key]
        public int Id { get; set; }
        public string IngredientName { get; set; } = string.Empty;

        [JsonIgnore]
        public ICollection<RecipeIngredient> RecipeIngredients { get; } = new List<RecipeIngredient>();
    }

}