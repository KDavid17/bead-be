using BeadBE.Application.FoodLogic.Common;
using MediatR;

namespace BeadBE.Application.FoodLogic.Commands.PutFood
{
    public record PutFoodCommand(
        int Id,
        int EateryId,
        string Name,
        decimal Price) : IRequest<FoodResult>;
}
