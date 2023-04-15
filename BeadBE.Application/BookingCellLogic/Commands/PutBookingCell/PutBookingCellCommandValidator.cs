using FluentValidation;

namespace BeadBE.Application.BookingCellLogic.Commands.PutBookingCell
{
    public class PutBookingCellCommandValidator : AbstractValidator<PutBookingCellCommand>
    {
        public PutBookingCellCommandValidator()
        {
            RuleFor(bc => bc.BookingId)
                .NotNull()
                .GreaterThan(0);
            RuleFor(bc => bc.CellId)
                .NotNull()
                .GreaterThan(0);
        }
    }
}
