using BeadBE.Domain.Entities;

namespace BeadBE.Application.Common.Interfaces.Persistence
{
    public interface IUserRepository
    {
        UserEntity GetUserByEmail(string email);
        Task Add(UserEntity user);
    }
}
