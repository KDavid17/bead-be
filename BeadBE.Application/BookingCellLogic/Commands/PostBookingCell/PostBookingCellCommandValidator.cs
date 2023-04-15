using FluentValidation;

namespace BeadBE.Application.BookingCellLogic.Commands.PostBookingCell
{
    public class PostBookingCellCommandValidator : AbstractValidator<PostBookingCellCommand>
    {
        public PostBookingCellCommandValidator()
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
