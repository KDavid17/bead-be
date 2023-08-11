using BeadBE.Contract.BookingFood;

namespace BeadBE.Contract.Booking
{
    public record BookingRequest(
        int EateryId,
        int UserId,
        bool DidOrder,
        DateTime StartDate,
        DateTime? EndDate,
        IEnumerable<BookingFoodRequest>? PreOrderedFoods);
}
