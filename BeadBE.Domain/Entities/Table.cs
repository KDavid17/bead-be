using System;
using System.Collections.Generic;

namespace BeadBE.Domain.Entities;

public partial class Table
{
    public int Id { get; set; }

    public int Seats { get; set; }

    public virtual ICollection<Cell> Cells { get; } = new List<Cell>();
}
