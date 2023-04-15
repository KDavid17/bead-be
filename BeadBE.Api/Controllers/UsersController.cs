using BeadBE.Application.UserLogic.Commands.DeleteUser;
using BeadBE.Application.UserLogic.Commands.PutUser;
using BeadBE.Application.UserLogic.Queries.GetUser;
using BeadBE.Contract.User;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BeadBE.Api.Controllers
{
    [ApiController]
    [Authorize(Roles = "Admin")]
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
        public async Task<IActionResult> GetUsers()
        {
            var query = new GetUsersQuery();

            var response = _mapper.Map<UsersResponse>(await _mediator.Send(query));

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            GetUserQuery query = new(id);

            var response = _mapper.Map<UserResponse>(await _mediator.Send(query));

            return Ok(response);
        }

        [HttpPut("{id}")]
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
