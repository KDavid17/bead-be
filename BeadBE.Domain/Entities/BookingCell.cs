using System;
using System.Collections.Generic;

namespace BeadBE.Domain.Entities;

public partial class BookingCell
{
    public int Id { get; set; }

    public int BookingId { get; set; }

    public int CellId { get; set; }

    public virtual Booking Booking { get; set; } = null!;

    public virtual Cell Cell { get; set; } = null!;
}
