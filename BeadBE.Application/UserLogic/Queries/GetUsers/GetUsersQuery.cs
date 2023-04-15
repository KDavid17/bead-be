using BeadBE.Application.UserLogic.Common;
using MediatR;

namespace BeadBE.Application.UserLogic.Queries.GetUser
{
    public record GetUsersQuery() : IRequest<UsersResult>;
}
