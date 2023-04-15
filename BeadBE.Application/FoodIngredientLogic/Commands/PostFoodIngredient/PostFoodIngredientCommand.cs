using BeadBE.Application.FoodIngredientLogic.Common;
using MediatR;

namespace BeadBE.Application.FoodIngredientLogic.Commands.PostFoodIngredient
{
    public record PostFoodIngredientCommand(
        int FoodId,
        int IngredientId) : IRequest<FoodIngredientResult>;
}
