using BeadBE.Domain.Entities;

namespace BeadBE.Application.IngredientLogic.Common
{
    public record IngredientsResult(IEnumerable<Ingredient> Ingredients);
}
