using BeadBE.Domain.Entities;

namespace BeadBE.Domain.Models
{
    public class BookingFoodDetails
    {
        public FoodDetails Food { get; set; } = null!;

        public int Quantity { get; set; }
    }
}
