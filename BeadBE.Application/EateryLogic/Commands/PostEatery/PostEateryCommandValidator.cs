using FluentValidation;

namespace BeadBE.Application.EateryLogic.Commands.PostEatery
{
    public class PostEateryCommandValidator : AbstractValidator<PostEateryCommand>
    {
        public PostEateryCommandValidator()
        {
            RuleFor(e => e.UserId)
                .NotNull()
                .GreaterThan(0);
            RuleFor(e => e.Name)
                .NotEmpty()
                .MaximumLength(128);
            RuleFor(e => e.Height)
                .NotNull()
                .GreaterThan(0);
            RuleFor(e => e.Width)
                .NotNull()
                .GreaterThan(0);
        }
    }
}
