using RecipeBook.Models;

namespace RecipeBook.Services;

public interface IIngredientService
{
    Task<bool> AddIngredientAsync(string name);
    Task<List<Ingredient>> GetIngredientsAsync();
}
