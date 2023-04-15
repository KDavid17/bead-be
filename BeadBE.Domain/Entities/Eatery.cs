using System;
using System.Collections.Generic;

namespace BeadBE.Domain.Entities;

public partial class Eatery
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public string Name { get; set; } = null!;

    public int Height { get; set; }

    public int Width { get; set; }

    public virtual ICollection<Booking> Bookings { get; } = new List<Booking>();

    public virtual ICollection<Cell> Cells { get; } = new List<Cell>();

    public virtual ICollection<Food> Foods { get; } = new List<Food>();

    public virtual User User { get; set; } = null!;
}
