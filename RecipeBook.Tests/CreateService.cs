using Microsoft.Extensions.DependencyInjection;
using RecipeBook.Data;
using RecipeBook.Services;

namespace RecipeBook.Tests;
public class CreateService
{
    protected ServiceProvider serviceProvider;
    public CreateService()
    {
        CreateServiceCollection();
        InitializeDatabase();
    }
    public void CreateServiceCollection()
    {
        var serviceCollection = new ServiceCollection();
        serviceCollection.AddTransient<IRecipeService, RecipeService>();
        serviceCollection.AddTransient<RecipeBookContext>();
        serviceCollection.AddTransient<IIngredientService, IngredientService>();
        serviceProvider = serviceCollection.BuildServiceProvider();
    }

    public void InitializeDatabase()
    {

        var recipeBookContext = serviceProvider.GetRequiredService<RecipeBookContext>();
        recipeBookContext.Database.EnsureDeleted();
        recipeBookContext.Database.EnsureCreated();

    }
}
