using BeadBE.Application.BookingLogic.Common;
using MediatR;

namespace BeadBE.Application.BookingLogic.Queries.GetBookings
{
    public record GetBookingsQuery() : IRequest<BookingsResult>;
}
