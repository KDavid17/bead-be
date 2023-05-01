using BeadBE.Application.FoodLogic.Common;
using MediatR;

namespace BeadBE.Application.FoodLogic.Queries.GetFoods
{
    public record GetFoodsQuery() : IRequest<FoodsResult>;
}
