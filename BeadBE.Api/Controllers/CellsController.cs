using BeadBE.Application.CellLogic.Commands.DeleteCell;
using BeadBE.Application.CellLogic.Commands.PostCell;
using BeadBE.Application.CellLogic.Commands.PutCell;
using BeadBE.Application.CellLogic.Queries.GetCell;
using BeadBE.Contract.Cell;
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
    public class CellsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ISender _mediator;

        public CellsController(IMapper mapper, ISender mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetCells()
        {
            var query = new GetCellsQuery();

            var response = _mapper.Map<CellsResponse>(await _mediator.Send(query));

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCellById(int id)
        {
            GetCellQuery query = new(id);

            var response = _mapper.Map<CellResponse>(await _mediator.Send(query));

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> PostCell(CellRequest request)
        {
            var command = _mapper.Map<PostCellCommand>(request);

            await _mediator.Send(command);

            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCell(int id, CellRequest request)
        {
            var command = (id, request).Adapt<PutCellCommand>();

            await _mediator.Send(command);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCell(int id)
        {
            DeleteCellCommand command = new(id);

            await _mediator.Send(command);

            return Ok();
        }
    }
}
