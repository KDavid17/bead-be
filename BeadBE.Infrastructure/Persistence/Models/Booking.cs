using System;
using System.Collections.Generic;

namespace BeadBE.Infrastructure.Persistence.Models
{
    public partial class Booking
    {
        public Booking()
        {
            BookingOrders = new HashSet<BookingOrder>();
            Tables = new HashSet<Table>();
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public bool DidOrder { get; set; }

        public virtual User User { get; set; } = null!;
        public virtual ICollection<BookingOrder> BookingOrders { get; set; }
        public virtual ICollection<Table> Tables { get; set; }
    }
}
