using BeadBE.Application.BookingLogic.Commands.DeleteBooking;
using BeadBE.Application.BookingLogic.Commands.PostBooking;
using BeadBE.Application.BookingLogic.Commands.PutBooking;
using BeadBE.Application.BookingLogic.Queries.GetBooking;
using BeadBE.Contract.Booking;
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
    public class BookingsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ISender _mediator;

        public BookingsController(IMapper mapper, ISender mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetBookings()
        {
            var query = new GetBookingsQuery();

            var response = _mapper.Map<BookingsResponse>(await _mediator.Send(query));

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookingById(int id)
        {
            var query = new GetBookingQuery(id);

            var response = _mapper.Map<BookingResponse>(await _mediator.Send(query));

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> PostBooking(BookingRequest request)
        {
            var command = _mapper.Map<PostBookingCommand>(request);

            await _mediator.Send(command);

            return StatusCode(StatusCodes.Status201Created);
        }

        [Authorize(Roles = "Eatery")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBooking(int id, BookingRequest request)
        {
            var command = (id, request).Adapt<PutBookingCommand>();

            await _mediator.Send(command);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBooking(int id)
        {
            var command = new DeleteBookingCommand(id);

            await _mediator.Send(command);

            return Ok();
        }
    }
}
