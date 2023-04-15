using System;
using System.Collections.Generic;

namespace BeadBE.Domain.Entities;

public partial class Booking
{
    public int Id { get; set; }

    public int EateryId { get; set; }

    public int UserId { get; set; }

    public bool DidOrder { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public virtual ICollection<BookingCell> BookingCells { get; } = new List<BookingCell>();

    public virtual ICollection<BookingFood> BookingFoods { get; } = new List<BookingFood>();

    public virtual Eatery Eatery { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
