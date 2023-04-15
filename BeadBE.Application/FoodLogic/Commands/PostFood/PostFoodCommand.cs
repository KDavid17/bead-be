using BeadBE.Application.FoodLogic.Common;
using MediatR;

namespace BeadBE.Application.FoodLogic.Commands.PostFood
{
    public record PostFoodCommand(
        int EateryId,
        string Name,
        decimal Price) : IRequest<FoodResult>;
}
