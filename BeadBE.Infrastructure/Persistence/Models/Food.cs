using System;
using System.Collections.Generic;

namespace BeadBE.Infrastructure.Persistence.Models
{
    public partial class Food
    {
        public Food()
        {
            BookingOrders = new HashSet<BookingOrder>();
            Recipes = new HashSet<Recipe>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }

        public virtual ICollection<BookingOrder> BookingOrders { get; set; }
        public virtual ICollection<Recipe> Recipes { get; set; }
    }
}
