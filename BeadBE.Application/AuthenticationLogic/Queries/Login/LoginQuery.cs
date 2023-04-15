using BeadBE.Application.AuthenticationLogic.Common;
using MediatR;

namespace BeadBE.Application.AuthenticationLogic.Queries.Login
{
    public record LoginQuery(
        string Email,
        string Password) : IRequest<AuthenticationResult>;
}
