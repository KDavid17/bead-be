using FluentValidation;

namespace BeadBE.Application.CellLogic.Commands.PutCell
{
    public class PutCellCommandValidator : AbstractValidator<PutCellCommand>
    {
        public PutCellCommandValidator()
        {
            RuleFor(i => i.Name).NotEmpty();
            RuleFor(i => i.IsAllergen).NotNull();
        }
    }
}
