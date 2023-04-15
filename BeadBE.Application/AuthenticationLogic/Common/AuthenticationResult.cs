using BeadBE.Domain.Entities;

namespace BeadBE.Application.AuthenticationLogic.Common
{
    public record AuthenticationResult(User User, string Token);
}