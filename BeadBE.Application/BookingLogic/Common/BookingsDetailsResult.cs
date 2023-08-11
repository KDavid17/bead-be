using BeadBE.Domain.Models;

namespace BeadBE.Application.BookingLogic.Common
{
    public record BookingsDetailsResult(IEnumerable<BookingDetails> Bookings);
}
