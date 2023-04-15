namespace BeadBE.Contract.Ingredient
{
    public record IngredientResponse(
        int Id,
        string Name,
        bool IsAllergen);
}
