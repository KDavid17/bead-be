using BeadBE.Application.BookingLogic.Common;
using MediatR;

namespace BeadBE.Application.BookingLogic.Queries.GetBooking
{
    public record GetBookingQuery(int Id) : IRequest<BookingResult>;
}
