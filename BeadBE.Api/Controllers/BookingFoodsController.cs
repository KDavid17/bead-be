using BeadBE.Application.BookingCellLogic.Commands.PutBookingCell;
using BeadBE.Application.BookingFoodLogic.Commands.DeleteBookingFood;
using BeadBE.Application.BookingFoodLogic.Commands.PostBookingFood;
using BeadBE.Application.BookingFoodLogic.Commands.PutBookingFood;
using BeadBE.Contract.BookingFood;
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
    public class BookingFoodsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ISender _mediator;

        public BookingFoodsController(IMapper mapper, ISender mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> PostBookingFood(BookingFoodRequest request)
        {
            var command = _mapper.Map<PostBookingFoodCommand>(request);

            await _mediator.Send(command);

            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutBookingFood(int id, BookingFoodRequest request)
        {
            var command = (id, request).Adapt<PutBookingFoodCommand>();

            await _mediator.Send(command);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBookingFood(int id)
        {
            DeleteBookingFoodCommand command = new(id);

            await _mediator.Send(command);

            return Ok();
        }
    }
}
