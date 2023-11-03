using Microsoft.Extensions.DependencyInjection;
using RecipeBook.Services;

namespace RecipeBook.Tests;

[Collection("Seq")]
public class IngredientServiceTest : CreateService
{
    private readonly IIngredientService _ingredientService;

    public IngredientServiceTest()
    {
        _ingredientService = serviceProvider.GetRequiredService<IIngredientService>();
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
