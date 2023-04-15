using BeadBE.Domain.Entities;

namespace BeadBE.Application.FoodLogic.Common
{
    public record FoodsResult(IEnumerable<Food> Foods);
}
