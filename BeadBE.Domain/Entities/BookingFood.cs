using System;
using System.Collections.Generic;

namespace BeadBE.Domain.Entities;

public partial class BookingFood
{
    public int Id { get; set; }

    public int BookingId { get; set; }

    public int FoodId { get; set; }

    public int Quantity { get; set; }

    public virtual Booking Booking { get; set; } = null!;

    public virtual Food Food { get; set; } = null!;
}
