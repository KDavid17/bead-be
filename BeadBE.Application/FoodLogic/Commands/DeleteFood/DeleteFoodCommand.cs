using BeadBE.Application.FoodLogic.Common;
using MediatR;

namespace BeadBE.Application.FoodLogic.Commands.DeleteFood
{
    public record DeleteFoodCommand(int Id) : IRequest<FoodResult>;
}
