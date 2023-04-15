using BeadBE.Application.FoodLogic.Common;
using MediatR;

namespace BeadBE.Application.FoodLogic.Queries.GetFoodsDetails
{
    public record GetFoodsDetailsQuery() : IRequest<FoodsDetailsResult>;
}
