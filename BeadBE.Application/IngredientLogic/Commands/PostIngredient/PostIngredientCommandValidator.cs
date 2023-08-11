using FluentValidation;

namespace BeadBE.Application.IngredientLogic.Commands.PostIngredient
{
    public class PostIngredientCommandValidator : AbstractValidator<PostIngredientCommand>
    {
        public PostIngredientCommandValidator()
        {
            RuleFor(c => c.IsAllergen)
                .NotNull();
            RuleFor(c => c.Name)
                .NotEmpty();
        }
    }
}
