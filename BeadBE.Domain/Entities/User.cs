using System;
using System.Collections.Generic;

namespace BeadBE.Domain.Entities;

public partial class User
{
    public int Id { get; set; }

    public int RoleId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public byte[] Password { get; set; } = null!;

    public byte[] Salt { get; set; } = null!;

    public virtual ICollection<Booking> Bookings { get; } = new List<Booking>();

    public virtual ICollection<Eatery> Eateries { get; } = new List<Eatery>();

    public virtual Role Role { get; set; } = null!;
}
