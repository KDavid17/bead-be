using FluentValidation;

namespace BeadBE.Application.EateryLogic.Commands.PutEatery
{
    public class PutEateryCommandValidator : AbstractValidator<PutEateryCommand>
    {
        public PutEateryCommandValidator()
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
