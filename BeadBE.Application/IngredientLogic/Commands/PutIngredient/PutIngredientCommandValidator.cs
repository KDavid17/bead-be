using FluentValidation;

namespace BeadBE.Application.IngredientLogic.Commands.PutIngredient
{
    public class PutIngredientCommandValidator : AbstractValidator<PutIngredientCommand>
    {
        public PutIngredientCommandValidator()
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
