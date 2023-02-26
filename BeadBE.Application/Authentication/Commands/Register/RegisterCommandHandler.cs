using BeadBE.Application.Authentication.Common;
using BeadBE.Application.Common.Interfaces.Authentication;
using BeadBE.Application.Common.Interfaces.Persistence;
using BeadBE.Application.Common.Responses;
using BeadBE.Domain.Entities;
using MediatR;

namespace BeadBE.Application.Authentication.Commands.Register
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, IBaseResponse>
    {
        private readonly IJwtGenerator _jwtGenerator;
        private readonly IUserRepository _userRepository;

        public RegisterCommandHandler(IJwtGenerator jwtGenerator, IUserRepository userRepository)
        {
            _jwtGenerator = jwtGenerator;
            _userRepository = userRepository;
        }

        public async Task<IBaseResponse> Handle(RegisterCommand command, CancellationToken cancellationToken)
        {
            if (_userRepository.GetUserByEmail(command.Email) is not null)
            {
                return new ServiceError(System.Net.HttpStatusCode.Conflict, "Email already in use");
            }

            UserEntity user = new()
            {
                FirstName = command.FirstName,
                LastName = command.LastName,
                Email = command.Email,
                Password = command.Password
            };

            await _userRepository.Add(user);

            string token = _jwtGenerator.GenerateToken(command.Email);

            return new AuthenticationResult(user, token);
        }
    }
}
