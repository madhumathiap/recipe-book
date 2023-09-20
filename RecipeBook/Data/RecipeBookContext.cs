using Microsoft.EntityFrameworkCore;
using RecipeBook.Models;

namespace RecipeBook.Data;

public class RecipeBookContext : DbContext
{
    public RecipeBookContext(DbContextOptions<RecipeBookContext> options) : base(options)
    {
    }

    public DbSet<Recipe> Recipes { get; set; }
    public DbSet<Ingredient> Ingredients { get; set; }
    public DbSet<RecipeIngredient> RecipeIngredients { get; set; }
}
