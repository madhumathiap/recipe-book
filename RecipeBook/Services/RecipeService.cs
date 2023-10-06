using Microsoft.EntityFrameworkCore;
using RecipeBook.Data;
using RecipeBook.Models;
using RecipeBook.Requests;

namespace RecipeBook.Services;

public class RecipeService : IRecipeService
{
    private readonly RecipeBookContext _recipeBookContext;
    private readonly IIngredientService _ingredientService;
    public RecipeService(RecipeBookContext recipeBookContext, IIngredientService ingredientService)
    {
        _recipeBookContext = recipeBookContext;
        _ingredientService = ingredientService;
    }

    public async Task<bool> AddRecipeAsync(AddRecipeRequest addRecipeRequest)
    {
        try
        {
            var recipe = new Recipe()
            {
                RecipeName = addRecipeRequest.RecipeName,
                RecipeSteps = addRecipeRequest.Steps,
                ServingSize = addRecipeRequest.ServingSize,
                CreatedBy = addRecipeRequest.CreatedBy,
                CreatedAt = DateTime.UtcNow,
            };
            foreach (var ingredient in addRecipeRequest.RecipeIngredients)
            {
                recipe.RecipeIngredients.Add(new Models.RecipeIngredient
                {
                    IngredientId = await _ingredientService.GetOrAddIngredientAsync(ingredient.Name),
                    Quantity = ingredient.Quantity,
                    Unit = ingredient.Unit,
                });
            }
            await _recipeBookContext.Recipes.AddAsync(recipe);
            await _recipeBookContext.SaveChangesAsync();
            return true;
        }
        catch
        {
            return false;
        }
    }
    public async Task<List<Recipe>> GetRecipesAsync()
    {
        var recipes = await _recipeBookContext.Recipes.Include(r => r.RecipeIngredients)
                                                      .ThenInclude(ri => ri.Ingredient)
                                                      .ToListAsync();
        return recipes;
    }
}
