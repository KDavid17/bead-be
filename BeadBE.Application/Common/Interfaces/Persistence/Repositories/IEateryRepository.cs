using BeadBE.Domain.Entities;

namespace BeadBE.Application.Common.Interfaces.Persistence.Repositories
{
    public interface IEateryRepository : IBaseRepository<Eatery>
    {
        Task<IEnumerable<Eatery>> FindEateriesByParamAsync(string searchParam);
    }
}
