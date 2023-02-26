using System;
using System.Collections.Generic;

namespace BeadBE.Infrastructure.Persistence.Models
{
    public partial class Table
    {
        public int Id { get; set; }
        public int? BookingId { get; set; }
        public int Seats { get; set; }

        public virtual Booking? Booking { get; set; }
    }
}
