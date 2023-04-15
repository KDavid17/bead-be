using BeadBE.Application.AuthenticationLogic.Common;
using BeadBE.Application.Common.Interfaces.Authentication;
using BeadBE.Application.Common.Interfaces.Persistence;
using BeadBE.Application.Common.Interfaces.Services;
using BeadBE.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace BeadBE.Application.AuthenticationLogic.Commands.Register
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, AuthenticationResult>
    {
        private readonly IHashService _hashService;
        private readonly IUnitOfWork _unitOfWork;

        public RegisterCommandHandler(IHashService hashService, IUnitOfWork unitOfWork)
        {
            _hashService = hashService;
            _unitOfWork = unitOfWork;
        }

        public async Task<AuthenticationResult> Handle(RegisterCommand command, CancellationToken cancellationToken)
        {
            if (await _unitOfWork.UserRepository.GetUserByEmailAsync(command.Email) is not null)
            {
                throw new BadHttpRequestException("Email already in use", StatusCodes.Status409Conflict);
            }

            _hashService.CreateHash(command.Password, out byte[] hash, out byte[] salt);

            User user = new()
            {
                RoleId = 1,
                FirstName = command.FirstName,
                LastName = command.LastName,
                Email = command.Email,
                Password = hash,
                Salt = salt
            };

            await _unitOfWork.UserRepository.AddAsync(user);

            return new AuthenticationResult(user, "");
        }
    }
}
