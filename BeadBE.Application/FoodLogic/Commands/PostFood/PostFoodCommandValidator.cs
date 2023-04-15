using FluentValidation;

namespace BeadBE.Application.FoodLogic.Commands.PostFood
{
    public class PostFoodCommandValidator : AbstractValidator<PostFoodCommand>
    {
        public PostFoodCommandValidator()
        {
            RuleFor(f => f.EateryId)
                .NotNull()
                .GreaterThan(0);
            RuleFor(f => f.Name).NotEmpty();
            RuleFor(f => f.Price)
                .NotEmpty()
                .GreaterThan(0);
        }
    }
}
