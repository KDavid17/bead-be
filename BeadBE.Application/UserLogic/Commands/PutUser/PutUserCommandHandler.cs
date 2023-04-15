using BeadBE.Application.Common.Interfaces.Persistence;
using BeadBE.Application.Common.Interfaces.Services;
using BeadBE.Application.UserLogic.Common;
using BeadBE.Domain.Entities;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace BeadBE.Application.UserLogic.Commands.PutUser
{
    public class PutUserCommandHandler : IRequestHandler<PutUserCommand, UserResult>
    {
        private readonly IHashService _hashService;
        private readonly IUnitOfWork _unitOfWork;

        public PutUserCommandHandler(IHashService hashService, IUnitOfWork unitOfWork)
        {
            _hashService = hashService;
            _unitOfWork = unitOfWork;
        }

        public async Task<UserResult> Handle(PutUserCommand command, CancellationToken cancellationToken)
        {
            if (await _unitOfWork.UserRepository.FindByIdAsync(command.Id) is not User existingUser)
            {
                throw new BadHttpRequestException(
                    "User with provided ID not found!",
                    StatusCodes.Status404NotFound);
            }

            command.Adapt(existingUser);

            _hashService.CreateHash(command.Password, out byte[] hash, out byte[] salt);

            existingUser.Password = hash;
            existingUser.Salt = salt;

            await _unitOfWork.UserRepository.UpdateAsync(existingUser);

            return new UserResult(existingUser);
        }
    }
}
