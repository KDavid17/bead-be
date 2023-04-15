using BeadBE.Domain.Entities;

namespace BeadBE.Application.Common.Interfaces.Persistence.Repositories
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User?> GetUserByEmailAsync(string email);
    }
}
