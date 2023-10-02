using RecipeBook.Data;
using RecipeBook.Services;

namespace RecipeBook.Tests;

public class IngredientServiceTest
{
    private readonly IngredientService _ingredientService;
    private readonly RecipeBookContext _recipeBookContext = new RecipeBookContext();

    public IngredientServiceTest()
    {
        _recipeBookContext.Database.EnsureDeleted();
        _recipeBookContext.Database.EnsureCreated();

        _ingredientService = new IngredientService(_recipeBookContext);
    }

    [Fact]
    public async Task When_NewIngredient_Is_Added_Then_It_Should_Be_Retrieved_Successfully()
    {
        // Arrange
        var existingIngredients = await _ingredientService.GetIngredientsAsync();
        Assert.Empty(existingIngredients);

        // Act
        await _ingredientService.AddIngredientAsync("tomato");

        // Assert
        var addedIngredient = await _ingredientService.GetIngredientsAsync();
        Assert.Single(addedIngredient);
        Assert.Equal("tomato", addedIngredient[0].IngredientName);
    }
}
