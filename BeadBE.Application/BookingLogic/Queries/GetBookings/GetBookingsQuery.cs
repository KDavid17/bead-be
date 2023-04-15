using BeadBE.Application.BookingLogic.Common;
using MediatR;

namespace BeadBE.Application.BookingLogic.Queries.GetBooking
{
    public record GetBookingsQuery() : IRequest<BookingsResult>;
}
