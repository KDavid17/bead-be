using BeadBE.Application.Common.Interfaces.Persistence.Repositories;
using BeadBE.Domain.Entities;

namespace BeadBE.Infrastructure.Persistence.Repositories
{
    public class CellRepository : BaseRepository<Cell>, ICellRepository
    {
        public CellRepository(BeadContext context) : base(context) { }
    }
}
