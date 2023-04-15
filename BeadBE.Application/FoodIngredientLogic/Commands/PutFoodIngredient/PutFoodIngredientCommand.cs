using BeadBE.Application.FoodIngredientLogic.Common;
using MediatR;

namespace BeadBE.Application.FoodIngredientLogic.Commands.PutFoodIngredient
{
    public record PutFoodIngredientCommand(
        int Id,
        int FoodId,
        int IngredientId) : IRequest<FoodIngredientResult>;
}
