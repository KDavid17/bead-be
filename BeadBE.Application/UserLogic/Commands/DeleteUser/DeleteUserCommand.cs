using BeadBE.Application.UserLogic.Common;
using MediatR;

namespace BeadBE.Application.UserLogic.Commands.DeleteUser
{
    public record DeleteUserCommand(int Id) : IRequest<UserResult>;
}
