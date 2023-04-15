using System;
using System.Collections.Generic;

namespace BeadBE.Domain.Entities;

public partial class Cell
{
    public int Id { get; set; }

    public int EateryId { get; set; }

    public int? TableId { get; set; }

    public int X { get; set; }

    public int Y { get; set; }

    public virtual ICollection<BookingCell> BookingCells { get; } = new List<BookingCell>();

    public virtual Eatery Eatery { get; set; } = null!;

    public virtual Table? Table { get; set; }
}
