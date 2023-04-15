using FluentValidation;

namespace BeadBE.Application.FoodIngredientLogic.Commands.PostFoodIngredient
{
    public class PostFoodIngredientCommandValidator : AbstractValidator<PostFoodIngredientCommand>
    {
        public PostFoodIngredientCommandValidator()
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
