using BeadBE.Application.FoodLogic.Common;
using MediatR;

namespace BeadBE.Application.FoodLogic.Queries.GetFoodsDetailsByEateryId
{
    public record GetFoodsDetailsByEateryIdQuery(int Id) : IRequest<FoodsDetailsResult>;
}
