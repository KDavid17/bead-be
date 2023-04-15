using BeadBE.Application.IngredientLogic.Common;
using MediatR;

namespace BeadBE.Application.IngredientLogic.Commands.PutIngredient
{
    public record PutIngredientCommand(
        int Id,
        int EateryId,
        int? TableId,
        int X,
        int Y) : IRequest<IngredientResult>;
}
