using BeadBE.Application.AuthenticationLogic.Common;
using MediatR;

namespace BeadBE.Application.AuthenticationLogic.Commands.Register
{
    public record RegisterCommand(
        string FirstName,
        string LastName,
        string Email,
        string Password) : IRequest<AuthenticationResult>;
}
