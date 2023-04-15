using BeadBE.Application.FoodLogic.Common;
using MediatR;

namespace BeadBE.Application.FoodLogic.Queries.GetFood
{
    public record GetFoodQuery(int Id) : IRequest<FoodResult>;
}
