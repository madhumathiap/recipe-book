using Microsoft.Extensions.DependencyInjection;
using RecipeBook.Requests;
using RecipeBook.Services;

namespace RecipeBook.Tests;

[Collection("Seq")]
public class RecipeServiceTest : CreateService
{
    private readonly IRecipeService _recipeService;

    public RecipeServiceTest()
    {
        _recipeService = serviceProvider.GetRequiredService<IRecipeService>();
    }

    [Fact]
    public async Task When_New_Recipe_Is_Added_It_Should_Be_Added_Successfully()
    {
        // Arrange
        var newRecipe = new AddRecipeRequest
        {
            RecipeName = "Test",
            ServingSize = 1,
            CreatedBy = "Madhu",
            Steps = "blah blah",
            RecipeIngredients = new List<RecipeIngredients>()
            {
                new RecipeIngredients
                {
                    Name = "Milk",
                    Quantity = 1,
                    Unit = "litre"
                },
                new RecipeIngredients
                {
                    Name = "Sugar",
                    Quantity = 250,
                    Unit = "grams"
                }
            }
        };

        // Act
        var result = await _recipeService.AddRecipeAsync(newRecipe);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public async Task When_NewRecipe_Is_Added_Then_It_Should_Be_Retrieved_Successfully()
    {
        // Arrange
        var newRecipe = new AddRecipeRequest
        {
            RecipeName = "Test",
            ServingSize = 1,
            CreatedBy = "Madhu",
            Steps = "blah blah",
            RecipeIngredients = new List<RecipeIngredients>()
            {
                new RecipeIngredients
                {
                    Name = "Milk",
                    Quantity = 1,
                    Unit = "litre"
                },
                new RecipeIngredients
                {
                    Name = "Sugar",
                    Quantity = 250,
                    Unit = "grams"
                }
            }
        };
        await _recipeService.AddRecipeAsync(newRecipe);

        // Act
        var addedRecipe = await _recipeService.GetRecipesAsync(null, null, null, null);

        // Assert
        Assert.Single(addedRecipe);
        Assert.Equal(newRecipe.RecipeName, addedRecipe[0].RecipeName);
        Assert.Equal(newRecipe.RecipeIngredients.Count, addedRecipe[0].RecipeIngredients.Count);
        Assert.Equal(newRecipe.RecipeIngredients[0].Name, addedRecipe[0].RecipeIngredients.FirstOrDefault().Ingredient.IngredientName);
    }
}
