using BeadBE.Application.IngredientLogic.Common;
using MediatR;

namespace BeadBE.Application.IngredientLogic.Commands.DeleteIngredient
{
    public record DeleteIngredientCommand(int Id) : IRequest<IngredientResult>;
}
