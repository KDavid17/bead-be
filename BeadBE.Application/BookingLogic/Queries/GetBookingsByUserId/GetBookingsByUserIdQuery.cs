using BeadBE.Application.BookingLogic.Common;
using MediatR;

namespace BeadBE.Application.BookingLogic.Queries.GetBookingsByUserId
{
    public record GetBookingsByUserIdQuery(int UserId) : IRequest<BookingsDetailsResult>;
}
