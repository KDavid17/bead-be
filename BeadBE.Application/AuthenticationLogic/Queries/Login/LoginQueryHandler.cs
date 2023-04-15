using BeadBE.Application.AuthenticationLogic.Common;
using BeadBE.Application.Common.Interfaces.Authentication;
using BeadBE.Application.Common.Interfaces.Persistence;
using BeadBE.Application.Common.Interfaces.Services;
using BeadBE.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace BeadBE.Application.AuthenticationLogic.Queries.Login
{
    public class LoginQueryHandler : IRequestHandler<LoginQuery, AuthenticationResult>
    {
        private readonly IHashService _hashService;
        private readonly IJwtGenerator _jwtGenerator;
        private readonly IUnitOfWork _unitOfWork;

        public LoginQueryHandler(IHashService hashService, IJwtGenerator jwtGenerator, IUnitOfWork unitOfWork)
        {
            _hashService = hashService;
            _jwtGenerator = jwtGenerator;
            _unitOfWork = unitOfWork;
        }

        public async Task<AuthenticationResult> Handle(LoginQuery query, CancellationToken cancellationToken)
        {
            if (await _unitOfWork.UserRepository.GetUserByEmailAsync(query.Email) is not User user
                || !_hashService.VerifyCredentials(query.Password, user.Password, user.Salt))
            {
                throw new BadHttpRequestException(
                    "Invalid credentials",
                    StatusCodes.Status401Unauthorized);
            }

            string token = _jwtGenerator.GenerateToken(user);

            return new AuthenticationResult(user, token);
        }
    }
}
