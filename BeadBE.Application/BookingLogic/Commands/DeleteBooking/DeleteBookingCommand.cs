using BeadBE.Application.BookingLogic.Common;
using MediatR;

namespace BeadBE.Application.BookingLogic.Commands.DeleteBooking
{
    public record DeleteBookingCommand(int Id) : IRequest<BookingResult>;
}
