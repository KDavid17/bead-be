using BeadBE.Application.FoodLogic.Common;
using BeadBE.Domain.Entities;
using MediatR;

namespace BeadBE.Application.FoodLogic.Commands.PutFood
{
    public record PutFoodCommand(
        int Id,
        int EateryId,
        string Name,
        decimal Price,
        IEnumerable<Ingredient>? Ingredients) : IRequest<FoodResult>;
}
