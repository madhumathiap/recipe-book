using RecipeBook.Helper;
using RecipeBook.Models;
using RecipeBook.Requests;

namespace RecipeBook.Services;

public interface IRecipeService
{
    Task<bool> AddRecipeAsync(AddRecipeRequest addRecipeRequest);
    Task<PaginatedList<Recipe>> GetRecipesAsync(int? page, int? pageSize, string? searchTerm, string[]? ingredients);
}