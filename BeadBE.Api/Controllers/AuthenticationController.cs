using BeadBE.Application.AuthenticationLogic.Commands.Register;
using BeadBE.Application.AuthenticationLogic.Common;
using BeadBE.Application.AuthenticationLogic.Queries.Login;
using BeadBE.Contracts.Authentication;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BeadBE.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ISender _mediator;

        public AuthenticationController(IMapper mapper, ISender mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            LoginQuery query = _mapper.Map<LoginQuery>(request);

            AuthenticationResult result = await _mediator.Send(query);

            return Ok(_mapper.Map<AuthenticationResponse>(result));
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            RegisterCommand command = _mapper.Map<RegisterCommand>(request);

            await _mediator.Send(command);

            return StatusCode(StatusCodes.Status201Created);
        }
    }
}
