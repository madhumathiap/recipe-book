using RecipeBook.Models;
using RecipeBook.Requests;

namespace RecipeBook.Services;

public interface IRecipeService
{
    Task<bool> AddRecipeAsync(AddRecipeRequest addRecipeRequest);
    Task<List<Recipe>> GetRecipesAsync();
}