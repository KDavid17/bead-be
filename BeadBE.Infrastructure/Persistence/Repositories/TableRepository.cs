using BeadBE.Application.Common.Interfaces.Persistence.Repositories;
using BeadBE.Domain.Entities;

namespace BeadBE.Infrastructure.Persistence.Repositories
{
    public class TableRepository : BaseRepository<Table>, ITableRepository
    {
        public TableRepository(BeadContext context) : base(context) { }
    }
}
