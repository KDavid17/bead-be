using FluentValidation;

namespace BeadBE.Application.FoodLogic.Commands.PutFood
{
    public class PutFoodCommandValidator : AbstractValidator<PutFoodCommand>
    {
        public PutFoodCommandValidator()
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
