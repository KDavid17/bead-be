using BeadBE.Application.FoodIngredientLogic.Common;
using MediatR;

namespace BeadBE.Application.FoodIngredientLogic.Commands.DeleteFoodIngredient
{
    public record DeleteFoodIngredientCommand(int Id) : IRequest<FoodIngredientResult>;
}
