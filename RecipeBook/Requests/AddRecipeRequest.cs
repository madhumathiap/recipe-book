namespace RecipeBook.Requests;

public class AddRecipeRequest
{
    public string RecipeName { get; set; }
    public int ServingSize { get; set; }
    public string CreatedBy { get; set; }
    public string Steps { get; set; }
    public List<RecipeIngredients> RecipeIngredients { get; set; }
}
public class RecipeIngredients
{
    public string Name { get; set; }
    public double Quantity { get; set; }
    public string Unit { get; set; }
}