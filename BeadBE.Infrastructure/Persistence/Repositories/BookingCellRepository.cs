using BeadBE.Application.Common.Interfaces.Persistence.Repositories;
using BeadBE.Domain.Entities;

namespace BeadBE.Infrastructure.Persistence.Repositories
{
    public class BookingCellRepository : BaseRepository<BookingCell>, IBookingCellRepository
    {
        public BookingCellRepository(BeadContext context) : base(context) { }
    }
}
