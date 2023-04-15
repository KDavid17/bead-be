using BeadBE.Application.Common.Interfaces.Persistence.Repositories;
using BeadBE.Domain.Entities;

namespace BeadBE.Infrastructure.Persistence.Repositories
{
    public class BookingFoodRepository : BaseRepository<BookingFood>, IBookingFoodRepository
    {
        public BookingFoodRepository(BeadContext context) : base(context) { }
    }
}
