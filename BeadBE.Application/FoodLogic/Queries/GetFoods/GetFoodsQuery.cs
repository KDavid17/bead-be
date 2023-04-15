using BeadBE.Application.FoodLogic.Common;
using MediatR;

namespace BeadBE.Application.FoodLogic.Queries.GetFood
{
    public record GetFoodsQuery() : IRequest<FoodsResult>;
}
