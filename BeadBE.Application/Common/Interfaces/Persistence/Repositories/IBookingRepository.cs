using BeadBE.Domain.Entities;
using BeadBE.Domain.Models;

namespace BeadBE.Application.Common.Interfaces.Persistence.Repositories
{
    public interface IBookingRepository : IBaseRepository<Booking>
    {
        Task AddBookingWithFoodsAsync(Booking booking, IEnumerable<BookingFood> preOrderedFoods);
        Task<IEnumerable<BookingDetails>> GetBookingsByUserIdAsync(int userId);
    }
}
