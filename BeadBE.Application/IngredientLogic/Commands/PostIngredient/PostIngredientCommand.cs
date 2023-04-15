using BeadBE.Application.IngredientLogic.Common;
using MediatR;

namespace BeadBE.Application.IngredientLogic.Commands.PostIngredient
{
    public record PostIngredientCommand(
        int EateryId,
        int? TableId,
        int X,
        int Y) : IRequest<IngredientResult>;
}
