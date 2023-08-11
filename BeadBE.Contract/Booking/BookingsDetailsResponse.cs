namespace BeadBE.Contract.Booking
{
    public record BookingsDetailsResponse(IEnumerable<BookingDetailsResponse> Bookings);
}
