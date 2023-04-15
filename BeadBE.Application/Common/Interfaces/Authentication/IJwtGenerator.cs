using BeadBE.Domain.Entities;

namespace BeadBE.Application.Common.Interfaces.Authentication
{
    public interface IJwtGenerator
    {
        string GenerateToken(User user);
    }
}
