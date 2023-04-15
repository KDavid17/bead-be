using BeadBE.Application.BookingCellLogic.Commands.DeleteBookingCell;
using BeadBE.Application.BookingCellLogic.Commands.PostBookingCell;
using BeadBE.Application.BookingCellLogic.Commands.PutBookingCell;
using BeadBE.Contract.BookingCell;
using Mapster;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BeadBE.Api.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class BookingCellsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ISender _mediator;

        public BookingCellsController(IMapper mapper, ISender mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> PostBookingCell(BookingCellRequest request)
        {
            var command = _mapper.Map<PostBookingCellCommand>(request);

            await _mediator.Send(command);

            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutBookingCell(int id, BookingCellRequest request)
        {
            var command = (id, request).Adapt<PutBookingCellCommand>();

            await _mediator.Send(command);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBookingCell(int id)
        {
            DeleteBookingCellCommand command = new(id);

            await _mediator.Send(command);

            return Ok();
        }
    }
}
