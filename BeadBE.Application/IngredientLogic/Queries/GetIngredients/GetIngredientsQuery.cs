using BeadBE.Application.IngredientLogic.Common;
using MediatR;

namespace BeadBE.Application.IngredientLogic.Queries.GetIngredient
{
    public record GetIngredientsQuery() : IRequest<IngredientsResult>;
}
