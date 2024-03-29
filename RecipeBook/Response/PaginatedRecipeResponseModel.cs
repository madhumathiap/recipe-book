﻿namespace RecipeBook.Response;
public class PaginatedRecipeResponseModel
{
    public List<Recipe> Recipes { get; set; }
    public int PageIndex { get; set; }
    public int TotalPages { get; set; }
}
public class Recipe
{
    public int Id { get; set; }
    public string RecipeName { get; set; }
    public int ServingSize { get; set; }
    public string CreatedBy { get; set; }
    public DateTime CreatedAt { get; set; }
    public string Steps { get; set; }
    public List<Ingredients> Ingredients { get; set; }
}
public class Ingredients
{
    public string Name { get; set; }
    public double Quantity { get; set; }
    public string Unit { get; set; }
}
