using BeadBE.Application.Common.Responses;
using MediatR;

namespace BeadBE.Application.Authentication.Commands.Register
{
    public record RegisterCommand(
        string FirstName,
        string LastName,
        string Email,
        string Password) : IRequest<IBaseResponse>;
}
