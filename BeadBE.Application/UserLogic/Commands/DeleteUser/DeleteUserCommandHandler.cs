using BeadBE.Application.Common.Interfaces.Persistence;
using BeadBE.Application.UserLogic.Common;
using BeadBE.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace BeadBE.Application.UserLogic.Commands.DeleteUser
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, UserResult>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteUserCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<UserResult> Handle(DeleteUserCommand command, CancellationToken cancellationToken)
        {
            if (await _unitOfWork.UserRepository.FindByIdAsync(command.Id) is not User user)
            {
                throw new BadHttpRequestException("User with provided ID not found!", StatusCodes.Status404NotFound);
            }

            await _unitOfWork.UserRepository.RemoveAsync(user);

            return new UserResult(user);
        }
    }
}
