namespace BeadBE.Domain.Models
{
    public class BookingDetails
    {
        public int Id { get; set; }

        public int EateryId { get; set; }

        public string EateryName { get; set; } = string.Empty;

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public IEnumerable<FoodDetails> Foods { get; set; } = new List<FoodDetails>();
    }
}
