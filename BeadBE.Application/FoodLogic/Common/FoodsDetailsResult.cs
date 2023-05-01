using BeadBE.Domain.Models;

namespace BeadBE.Application.FoodLogic.Common
{
    public record FoodsDetailsResult(IEnumerable<FoodDetails> FoodsDetails);
}
