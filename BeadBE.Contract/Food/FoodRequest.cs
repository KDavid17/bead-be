using BeadBE.Contract.Ingredient;

namespace BeadBE.Contract.Food
{
    public record FoodRequest(
        int EateryId,
        string Name,
        decimal Price,
        IEnumerable<IngredientResponse>? Ingredients);
}
