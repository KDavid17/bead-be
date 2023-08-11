using BeadBE.Application.IngredientLogic.Common;
using MediatR;

namespace BeadBE.Application.IngredientLogic.Commands.PostIngredient
{
    public record PostIngredientCommand(
        string Name,
        bool IsAllergen) : IRequest<IngredientResult>;
}
