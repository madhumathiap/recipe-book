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

    //Get Ingredients
    public async Task<List<Ingredient>> GetIngredientsAsync()
    {
        List<Ingredient> ingredientList = [];
        try
        {
            foreach (var item in await _recipeBookContext.Ingredients.ToListAsync())
            {
                var ingredient = new Ingredient
                {
                    IngredientId = item.IngredientId,
                    IngredientName = item.IngredientName
                };
                ingredientList.Add(ingredient);
            }
            return ingredientList;
        }
        catch
        {
            return ingredientList;
        }
    }
}
