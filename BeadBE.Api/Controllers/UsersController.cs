using BeadBE.Application.UserLogic.Commands.DeleteUser;
using BeadBE.Application.UserLogic.Commands.PutUser;
using BeadBE.Application.UserLogic.Queries.GetUser;
using BeadBE.Contract.User;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace BeadBE.Api.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ISender _mediator;

        public UsersController(IMapper mapper, ISender mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetUsers()
        {
            var query = new GetUsersQuery();

            var response = _mapper.Map<UsersResponse>(await _mediator.Send(query));

            return Ok(response.Users);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetUserById(int id)
        {
            GetUserQuery query = new(id);

            var response = _mapper.Map<UserResponse>(await _mediator.Send(query));

            return Ok(response);
        }

        [HttpGet("profile")]
        public async Task<IActionResult> GetUserProfile()
        {
            var id = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (int.TryParse(id, out int parsedId))
            {
                GetUserQuery query = new(parsedId);

                var response = _mapper.Map<UserProfileResponse>(await _mediator.Send(query));

                return Ok(response);
            }
            else
            {
                throw new BadHttpRequestException("Invalid UserId!");
            }
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> PutUser(int id, UserRequest request)
        {
            PutUserCommand command = new(
                id,
                request.RoleId,
                request.FirstName,
                request.LastName,
                request.Email,
                request.Password);

            await _mediator.Send(command);

            return Ok();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            DeleteUserCommand command = new(id);

            await _mediator.Send(command);

            return Ok();
        }

        [AllowAnonymous]
        [HttpGet("picture")]
        public IActionResult GetPicture()
        {
            var image = System.IO.File.OpenRead("C:\\Users\\kiss_\\GitHub-KDavid17\\bead-be\\images\\Chef's Burger.jpg");
            return File(image, "image/jpeg");
        }
    }
}
