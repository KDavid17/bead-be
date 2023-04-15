using BeadBE.Contract.Ingredient;

namespace BeadBE.Contract.Food
{
    public record FoodDetailsResponse(
        int Id,
        int EateryId,
        string Name,
        decimal Price,
        IEnumerable<IngredientResponse> Ingredients);
}
