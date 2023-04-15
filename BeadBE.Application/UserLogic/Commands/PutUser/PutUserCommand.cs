using BeadBE.Application.UserLogic.Common;
using MediatR;

namespace BeadBE.Application.UserLogic.Commands.PutUser
{
    public record PutUserCommand(
        int Id,
        int RoleId,
        string FirstName,
        string LastName,
        string Email,
        string Password) : IRequest<UserResult>;
}
