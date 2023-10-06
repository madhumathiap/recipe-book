using Microsoft.EntityFrameworkCore;
using RecipeBook.Data;
using RecipeBook.Models;

namespace RecipeBook.Services;

public class IngredientService : IIngredientService
{
    private readonly RecipeBookContext _recipeBookContext;
    public IngredientService(RecipeBookContext recipeBookContext)
    {
        _recipeBookContext = recipeBookContext;
    }

    //Adding Ingredient 
    public async Task<bool> AddIngredientAsync(string name)
    {
        var ingredient = new Ingredient();
        try
        {
            ingredient.IngredientName = name;

            await _recipeBookContext.Ingredients.AddAsync(ingredient);
            await _recipeBookContext.SaveChangesAsync();

            return true;
        }
        catch
        {
            return false;
        }
    }

    //Adding Ingredient 
    public async Task<int> GetOrAddIngredientAsync(string name)
    {
        var existingIngredient = await _recipeBookContext.Ingredients.FirstOrDefaultAsync(x => x.IngredientName == name);
        if (existingIngredient != null)
        {
            return existingIngredient.Id;
        }
        else
        {
            var ingredient = new Ingredient();
            ingredient.IngredientName = name;
            await _recipeBookContext.Ingredients.AddAsync(ingredient);
            await _recipeBookContext.SaveChangesAsync();
            return ingredient.Id;
        }
    }

    //Get Ingredients
    public async Task<List<Ingredient>> GetIngredientsAsync()
    {
        return await _recipeBookContext.Ingredients.ToListAsync();
    }
}
