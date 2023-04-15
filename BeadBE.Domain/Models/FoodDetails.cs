using BeadBE.Domain.Entities;

namespace BeadBE.Domain.Models
{
    public class FoodDetails
    {
        public int Id { get; set; }

        public int EateryId { get; set; }

        public string Name { get; set; } = string.Empty;

        public decimal Price { get; set; }

        public IEnumerable<Ingredient> Ingredients { get; set; } = Enumerable.Empty<Ingredient>();
    }
}
