using BeadBE.Domain.Entities;

namespace BeadBE.Application.UserLogic.Common
{
    public record UsersResult(IEnumerable<User> Users);
}
