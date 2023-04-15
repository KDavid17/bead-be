using BeadBE.Domain.Entities;

namespace BeadBE.Application.BookingLogic.Common
{
    public record BookingsResult(IEnumerable<Booking> Bookings);
}
