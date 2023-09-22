using Microsoft.EntityFrameworkCore;
using RecipeBook.Models;

namespace RecipeBook.Data;

public class RecipeBookContext : DbContext
{

    public DbSet<Recipe> Recipes { get; set; }
    public DbSet<Ingredient> Ingredients { get; set; }
    public DbSet<RecipeIngredient> RecipeIngredients { get; set; }

    public RecipeBookContext(DbContextOptions<RecipeBookContext> options) : base(options)
    {
    }

    public RecipeBookContext()
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlite("Filename=MyTestDatabase.db");
        }
    }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Ingredient>()
            .HasIndex(u => u.IngredientName)
            .IsUnique();
        builder.Entity<Recipe>()
            .HasIndex(u => u.RecipeName)
            .IsUnique();

    }
}
