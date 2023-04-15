using FluentValidation;

namespace BeadBE.Application.IngredientLogic.Commands.PostIngredient
{
    public class PostIngredientCommandValidator : AbstractValidator<PostIngredientCommand>
    {
        public PostIngredientCommandValidator()
        {
            RuleFor(c => c.EateryId)
                .NotNull()
                .GreaterThan(0);
            RuleFor(c => c.TableId)
                .GreaterThan(0)
                .When(c => c.TableId.HasValue);
            RuleFor(c => c.X)
                .NotNull()
                .GreaterThan(0);
            RuleFor(c => c.Y)
                .NotNull()
                .GreaterThan(0);
        }
    }
}
