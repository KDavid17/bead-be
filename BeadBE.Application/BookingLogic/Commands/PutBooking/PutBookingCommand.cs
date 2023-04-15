using BeadBE.Application.BookingLogic.Common;
using MediatR;

namespace BeadBE.Application.BookingLogic.Commands.PutBooking
{
    public record PutBookingCommand(
        int Id,
        int EateryId,
        int UserId,
        bool DidOrder,
        DateTime StartDate,
        DateTime? EndDate) : IRequest<BookingResult>;
}
