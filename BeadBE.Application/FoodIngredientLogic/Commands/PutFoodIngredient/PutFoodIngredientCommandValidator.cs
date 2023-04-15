using FluentValidation;

namespace BeadBE.Application.FoodIngredientLogic.Commands.PutFoodIngredient
{
    public class PutFoodIngredientCommandValidator : AbstractValidator<PutFoodIngredientCommand>
    {
        public PutFoodIngredientCommandValidator()
        {
            RuleFor(fi => fi.FoodId)
                .NotNull()
                .GreaterThan(0);
            RuleFor(fi => fi.IngredientId)
                .NotNull()
                .GreaterThan(0);
        }
    }
}
