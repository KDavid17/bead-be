using BeadBE.Application.Common.Interfaces.Persistence.Repositories;
using BeadBE.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Threading;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace BeadBE.Infrastructure.Persistence.Repositories
{
    public class EateryRepository : BaseRepository<Eatery>, IEateryRepository
    {
        public EateryRepository(BeadContext context) : base(context) { }

        public async Task<bool> CheckIfUserIdInEatery(int userId)
        {
            return await _context.Eateries.FirstOrDefaultAsync(e => e.UserId == userId) is null;
        }

        public async Task<IEnumerable<Eatery>> FindEateriesByParamAsync(string searchParam)
        {
            IQueryable<Eatery> query = _context.Eateries.Take(0);

            if (!String.IsNullOrEmpty(searchParam))
            {
                query = _context.Eateries
                    .Where(e => e.Name
                        .ToLower()
                        .Contains(searchParam
                            .Trim()
                            .ToLower()));
            }

            var eateries = await query.ToListAsync();

            return eateries;
        }
    }
}
