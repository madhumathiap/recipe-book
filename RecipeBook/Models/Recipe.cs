using System.ComponentModel.DataAnnotations;

namespace RecipeBook.Models
{
    public class Recipe
    {
        [Key]
        public int RecipeId { get; set; }

        public string RecipeName { get; set; }

        public int ServingSize { get; set; }

        public DateTime CreatedAt { get; set; }

        public string CreatedBy { get; set; }

    }

}

