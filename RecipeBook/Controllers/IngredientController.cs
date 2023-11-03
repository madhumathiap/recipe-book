using Microsoft.AspNetCore.Mvc;
using RecipeBook.Requests;
using RecipeBook.Response;
using RecipeBook.Services;

namespace RecipeBook.Controllers;
[ApiController]
public class IngredientController : ControllerBase
{
    private readonly IIngredientService _ingredientService;

    public IngredientController(IIngredientService ingredientService)
    {
        _ingredientService = ingredientService;
    }

    [HttpPost]
    [Route("api/ingredient")]
    public async Task<ActionResult> AddIngredient(AddIngredientRequest request)
    {
        var isSuccess = await _ingredientService.AddIngredientAsync(request.Name);

        var model = new ResponseModel
        {
            IsSuccess = isSuccess,
            Message = isSuccess ? "Ingredient addition successful" : "Ingredient addition unsuccessful"
        };

        return isSuccess ? Ok(model) : BadRequest(model);
    }

    [HttpGet]
    [Route("api/ingredients")]
    public async Task<ActionResult> GetAvailableIngredients()
    {
        var ingredientList = await _ingredientService.GetIngredientsAsync();
        return Ok(ingredientList);
    }
}
