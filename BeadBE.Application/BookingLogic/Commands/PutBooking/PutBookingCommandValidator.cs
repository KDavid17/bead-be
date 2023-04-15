using BeadBE.Application.Common.Interfaces.Services;
using FluentValidation;

namespace BeadBE.Application.BookingLogic.Commands.PutBooking
{
    public class PutBookingCommandValidator : AbstractValidator<PutBookingCommand>
    {
        public PutBookingCommandValidator(IDateTimeProvider dateTimeProvider)
        {
            RuleFor(b => b.EateryId)
                .NotNull()
                .GreaterThan(0);
            RuleFor(b => b.UserId)
                .NotNull()
                .GreaterThan(0);
            RuleFor(b => b.DidOrder).NotNull();
            RuleFor(b => b.StartDate)
            .NotNull()
                .GreaterThan(dateTimeProvider.UtcNow);
            RuleFor(b => b.EndDate)
                .GreaterThan(b => b.StartDate)
                    .When(b => b.EndDate.HasValue);
        }
    }
}
