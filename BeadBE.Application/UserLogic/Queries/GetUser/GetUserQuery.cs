using BeadBE.Application.UserLogic.Common;
using MediatR;

namespace BeadBE.Application.UserLogic.Queries.GetUser
{
    public record GetUserQuery(int Id) : IRequest<UserResult>;
}
