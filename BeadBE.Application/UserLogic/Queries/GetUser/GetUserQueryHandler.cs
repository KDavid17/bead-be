using BeadBE.Application.Common.Interfaces.Persistence;
using BeadBE.Application.UserLogic.Common;
using BeadBE.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace BeadBE.Application.UserLogic.Queries.GetUser
{
    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, UserResult>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetUserQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<UserResult> Handle(GetUserQuery query, CancellationToken cancellationToken)
        {
            if (await _unitOfWork.UserRepository.FindByIdAsync(query.Id) is not User user)
            {
                throw new BadHttpRequestException(
                    "User with provided ID not found!",
                    StatusCodes.Status404NotFound);
            }

            return new UserResult(user);
        }
    }
}
