using BeadBE.Contract.Eatery;

namespace BeadBE.Contract.Booking
{
    public record BookingDetailsResponse(
        int Id,
        DateTime StartDate,
        DateTime EndDate,
        EateryResponse Eatery);
}
