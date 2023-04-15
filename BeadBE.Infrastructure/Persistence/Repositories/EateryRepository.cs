using BeadBE.Application.Common.Interfaces.Persistence.Repositories;
using BeadBE.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BeadBE.Infrastructure.Persistence.Repositories
{
    public class EateryRepository : BaseRepository<Eatery>, IEateryRepository
    {
        public EateryRepository(BeadContext context) : base(context) { }

        public async Task<bool> CheckIfUserIdInEatery(int userId)
        {
            return await _context.Eateries.FirstOrDefaultAsync(e => e.UserId == userId) is null;
        }
    }
}
