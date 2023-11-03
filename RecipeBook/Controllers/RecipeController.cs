using Microsoft.AspNetCore.Mvc;
using RecipeBook.Helper;
using RecipeBook.Requests;
using RecipeBook.Response;
using RecipeBook.Services;

namespace RecipeBook.Controllers;
[ApiController]
public class RecipeController : ControllerBase
{
    private readonly IRecipeService _recipeService;

    public RecipeController(IRecipeService recipeService)
    {
        _recipeService = recipeService;
    }

    [HttpPost]
    [Route("api/recipe")]
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
    [Route("api/recipes")]
    [ProducesResponseType<PaginatedRecipeResponseModel>(200)]
    public async Task<ActionResult> GetAvailableRecipes(int? page, int? pageSize, string? searchTerm, [FromQuery] string[]? ingredients)
    {
        var recipeList = MapToRecipeResponseModel(await _recipeService.GetRecipesAsync(page, pageSize, searchTerm, ingredients));
        return Ok(recipeList);
    }

    private PaginatedRecipeResponseModel MapToRecipeResponseModel(PaginatedList<Models.Recipe> paginatedRecipes)
    {
        var recipesResponse = new List<Recipe>();
        foreach (var recipe in paginatedRecipes)
        {
            var recipes = new Recipe
            {
                Id = recipe.Id,
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
            recipes.Ingredients = ingredients;
            recipesResponse.Add(recipes);
        }
        var paginatedRecipesResponseModel = new PaginatedRecipeResponseModel()
        {
            TotalPages = paginatedRecipes.TotalPages,
            PageIndex = paginatedRecipes.PageIndex,
            Recipes = recipesResponse
        };
        return paginatedRecipesResponseModel;
    }
}
