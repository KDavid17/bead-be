using BeadBE.Application.Common.Interfaces.Persistence;
using BeadBE.Application.UserLogic.Common;
using BeadBE.Application.UserLogic.Queries.GetUser;
using MediatR;

namespace BeadBE.Application.UserLogic.Queries.GetUsers
{
    public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, UsersResult>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetUsersQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<UsersResult> Handle(GetUsersQuery query, CancellationToken cancellationToken)
        {
            return new UsersResult(await _unitOfWork.UserRepository.FindAllAsync());
        }
    }
}
