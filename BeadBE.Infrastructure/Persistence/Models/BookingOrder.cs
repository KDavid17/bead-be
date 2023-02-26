using System;
using System.Collections.Generic;

namespace BeadBE.Infrastructure.Persistence.Models
{
    public partial class BookingOrder
    {
        public int Id { get; set; }
        public int BookingId { get; set; }
        public int FoodId { get; set; }

        public virtual Booking Booking { get; set; } = null!;
        public virtual Food Food { get; set; } = null!;
    }
}
