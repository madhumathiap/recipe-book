using Microsoft.AspNetCore.Mvc;
using RecipeBook.Api.Client;
using RecipeBook.Web.Models;
using System.Diagnostics;

namespace RecipeBook.Web.Controllers;
public class RecipeController : Controller
{
    private readonly ILogger<RecipeController> _logger;
    private readonly RecipeBookApiClient _recipeBookApiClient;
    public RecipeController(ILogger<RecipeController> logger, RecipeBookApiClient recipeBookApiClient)
    {
        _logger = logger;
        _recipeBookApiClient = recipeBookApiClient;
    }

    public async Task<ViewResult> ViewRecipes()
    {
        var recipes = await _recipeBookApiClient.RecipesAsync(1, 10, "", new List<string>(), CancellationToken.None);
        return View(recipes);
    }
    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
