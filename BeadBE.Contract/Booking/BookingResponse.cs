namespace BeadBE.Contract.Booking
{
    public record BookingResponse(
        int Id,
        int EateryId,
        int UserId,
        bool DidOrder,
        DateTime StartDate,
        DateTime EndDate);
}
