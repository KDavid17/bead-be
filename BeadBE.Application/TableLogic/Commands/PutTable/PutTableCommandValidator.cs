using FluentValidation;

namespace BeadBE.Application.TableLogic.Commands.PutTable
{
    public class PutTableCommandValidator : AbstractValidator<PutTableCommand>
    {
        public PutTableCommandValidator()
        {
            RuleFor(t => t.Seats)
                .NotNull()
                .GreaterThan(0);
        }
    }
}
