using Microsoft.EntityFrameworkCore;
using RecipeBook.Data;
using RecipeBook.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<RecipeBookContext>(options =>
                options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IIngredientService, IngredientService>();
builder.Services.AddScoped<IRecipeService, RecipeService>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<RecipeBookContext>();
    await dbContext.Database.MigrateAsync();
}
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
