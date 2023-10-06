using Microsoft.AspNetCore.Mvc;
using RecipeBook.Models;
using RecipeBook.Requests;
using RecipeBook.Response;
using RecipeBook.Services;

namespace RecipeBook.Controllers;
[Route("api/[controller]")]
[ApiController]
public class RecipeController : ControllerBase
{
    private readonly IRecipeService _recipeService;

    public RecipeController(IRecipeService recipeService)
    {
        _recipeService = recipeService;
    }

    [HttpPost]
    public async Task<ActionResult> AddRecipe(AddRecipeRequest request)
    {
        var isSuccess = await _recipeService.AddRecipeAsync(request);

        var model = new ResponseModel
        {
            IsSuccess = isSuccess,
            Message = isSuccess ? "Recipe addition successful" : "Recipe addition unsuccessful"
        };

        return isSuccess ? Ok(model) : BadRequest(model);
    }

    [HttpGet]
    public async Task<ActionResult> GetAvailableRecipes()
    {
        var recipeList = MapToRecipeResponseModel(await _recipeService.GetRecipesAsync());
        return Ok(recipeList);
    }

    private List<RecipeResponseModel> MapToRecipeResponseModel(List<Recipe> recipes)
    {
        var recipesResponse = new List<RecipeResponseModel>();
        foreach (var recipe in recipes)
        {
            var recipeResponseModel = new RecipeResponseModel
            {
                RecipeName = recipe.RecipeName,
                CreatedBy = recipe.CreatedBy,
                CreatedAt = recipe.CreatedAt,
                Steps = recipe.RecipeSteps,
                ServingSize = recipe.ServingSize
            };
            var ingredients = new List<Ingredients>();
            foreach (var recipeIngredient in recipe.RecipeIngredients)
            {
                var ingredient = new Ingredients
                {
                    Name = recipeIngredient.Ingredient.IngredientName,
                    Unit = recipeIngredient.Unit,
                    Quantity = recipeIngredient.Quantity
                };
                ingredients.Add(ingredient);
            }
            recipeResponseModel.Ingredients = ingredients;
            recipesResponse.Add(recipeResponseModel);
        }
        return recipesResponse;
    }
}
