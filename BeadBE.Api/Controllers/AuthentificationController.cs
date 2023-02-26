using BeadBE.Application.Authentication.Commands.Register;
using BeadBE.Application.Authentication.Common;
using BeadBE.Application.Authentication.Queries.Login;
using BeadBE.Application.Common.Responses;
using BeadBE.Contracts.Authentication;
using BeadBE.Domain.Common.Errors;
using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;

namespace BeadBE.Api.Controllers
{
    [Route("api/[controller]")]
    [AllowAnonymous]
    public class AuthentificationController : ApiController
    {
        private readonly ILogger<AuthentificationController> _logger;
        private readonly IMapper _mapper;
        private readonly ISender _mediator;

        public AuthentificationController(ILogger<AuthentificationController> logger, IMapper mapper, ISender mediator)
        {
            _logger = logger;
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            /*CreateHash("hamham", out byte[] hash, out byte[] salt);

            UserModel existingUser = new()
            {
                UserName = "JohnDoe",
                Password = hash,
                Salt = salt
            };

            if (user.UserName != existingUser.UserName || !VerifyCredentials(user.Password, existingUser.Password, existingUser.Salt))
            {
                return BadRequest("Invalid credentials!");
            }

            string jwt = CreateJwt(user.UserName);*/

            LoginQuery query = _mapper.Map<LoginQuery>(request);

            ErrorOr<AuthenticationResult> result = await _mediator.Send(query);

            if (result.IsError && result.FirstError == Errors.Authentication.InvalidCredentials)
            {
                _logger.LogWarning("Errors: {Errors}", result.Errors);

                return Problem(
                    statusCode: StatusCodes.Status401Unauthorized,
                    title: result.FirstError.Description);
            }

            return Ok(_mapper.Map<AuthenticationResponse>(result));
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            /*CreateHash(user.Password, out byte[] hash, out byte[] salt);

            UserModel newUser = new()
            {
                UserName = user.UserName,
                Password = hash,
                Salt = salt
            };*/

            RegisterCommand command = _mapper.Map<RegisterCommand>(request);

            IBaseResponse result = await _mediator.Send(command);

            return result is ServiceError error ? Problem(error) : Ok(_mapper.Map<AuthenticationResponse>(result));
        }

        private void CreateHash(string password, out byte[] hash, out byte[] salt)
        {
            using HMACSHA512 hmac = new();

            salt = hmac.Key;
            hash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        }

        private bool VerifyCredentials(string password, byte[] hash, byte[] salt)
        {
            using HMACSHA512 hmac = new(salt);

            byte[] computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

            return hash.SequenceEqual(computedHash);
        }
    }
}
