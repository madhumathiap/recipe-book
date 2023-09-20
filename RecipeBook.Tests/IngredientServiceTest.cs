using RecipeBook.Data;
using RecipeBook.Services;

namespace RecipeBook.Tests;

public class IngredientServiceTest
{

    private readonly IngredientService _ingredientService;
    RecipeBookContext _context = new();
    public IngredientServiceTest()
    {
        _context.Database.EnsureDeleted();
        _context.Database.EnsureCreated();
        //_context.Database.Migrate();
        _ingredientService = new IngredientService(_context);

    }

    [Fact]
    public async Task NewIngredient_Should_Be_Added_Successfully()
    {
        var ingredients = await _ingredientService.GetIngredientsAsync();
        Assert.Empty(ingredients);
        await _ingredientService.AddIngredientAsync("tomato");
        var ingredients1 = await _ingredientService.GetIngredientsAsync();
        Assert.Single(ingredients1);
        Assert.Equal("tomato", ingredients1[0].IngredientName);
    }
}