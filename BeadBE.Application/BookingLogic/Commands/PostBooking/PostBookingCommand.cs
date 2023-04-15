using BeadBE.Application.BookingLogic.Common;
using MediatR;

namespace BeadBE.Application.BookingLogic.Commands.PostBooking
{
    public record PostBookingCommand(
        int EateryId,
        int UserId,
        bool DidOrder,
        DateTime StartDate,
        DateTime? EndDate) : IRequest<BookingResult>;
}
