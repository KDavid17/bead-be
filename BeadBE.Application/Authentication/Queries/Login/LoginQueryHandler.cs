using BeadBE.Application.Authentication.Common;
using BeadBE.Application.Common.Interfaces.Authentication;
using BeadBE.Application.Common.Interfaces.Persistence;
using BeadBE.Domain.Common.Errors;
using BeadBE.Domain.Entities;
using ErrorOr;
using MediatR;

namespace BeadBE.Application.Authentication.Queries.Login
{
    public class LoginQueryHandler : IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
    {
        private readonly IJwtGenerator _jwtGenerator;
        private readonly IUserRepository _userRepository;

        public LoginQueryHandler(IJwtGenerator jwtGenerator, IUserRepository userRepository)
        {
            _jwtGenerator = jwtGenerator;
            _userRepository = userRepository;
        }

        public async Task<ErrorOr<AuthenticationResult>> Handle(LoginQuery query, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            if (_userRepository.GetUserByEmail(query.Email) is not UserEntity user)
            {
                return Errors.Authentication.InvalidCredentials;
            }

            if (user.Password != query.Password)
            {
                return Errors.Authentication.InvalidCredentials;
            }

            string token = _jwtGenerator.GenerateToken(query.Email);

            return new AuthenticationResult(user, token);
        }
    }
}
