using RecipeBook.Data;
using RecipeBook.Requests;
using RecipeBook.Services;

namespace RecipeBook.Tests;
public class RecipeServiceTest
{
    private readonly IRecipeService _recipeService;
    private readonly RecipeBookContext _recipeBookContext = new RecipeBookContext();
    private readonly IIngredientService _ingredientService = new IngredientService(new RecipeBookContext());

    public RecipeServiceTest()
    {
        _recipeBookContext.Database.EnsureDeleted();
        _recipeBookContext.Database.EnsureCreated();

        _recipeService = new RecipeService(_recipeBookContext, _ingredientService);
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
        var addedRecipe = await _recipeService.GetRecipesAsync();

        // Assert
        Assert.Single(addedRecipe);
        Assert.Equal(newRecipe.RecipeName, addedRecipe[0].RecipeName);
        Assert.Equal(newRecipe.RecipeIngredients.Count, addedRecipe[0].RecipeIngredients.Count);
        Assert.Equal(newRecipe.RecipeIngredients[0].Name, addedRecipe[0].RecipeIngredients.FirstOrDefault().Ingredient.IngredientName);
    }
}
