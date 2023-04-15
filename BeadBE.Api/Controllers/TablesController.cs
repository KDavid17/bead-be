using BeadBE.Application.TableLogic.Commands.DeleteTable;
using BeadBE.Application.TableLogic.Commands.PostTable;
using BeadBE.Application.TableLogic.Commands.PutTable;
using BeadBE.Application.TableLogic.Queries.GetTable;
using BeadBE.Contract.Table;
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
    public class TablesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ISender _mediator;

        public TablesController(IMapper mapper, ISender mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetTables()
        {
            var query = new GetTablesQuery();

            var response = _mapper.Map<TablesResponse>(await _mediator.Send(query));

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTableById(int id)
        {
            GetTableQuery query = new(id);

            var response = _mapper.Map<TableResponse>(await _mediator.Send(query));

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> PostTable(TableRequest request)
        {
            var command = _mapper.Map<PostTableCommand>(request);

            await _mediator.Send(command);

            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutTable(int id, TableRequest request)
        {
            var command = (id, request).Adapt<PutTableCommand>();

            await _mediator.Send(command);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTable(int id)
        {
            DeleteTableCommand command = new(id);

            await _mediator.Send(command);

            return Ok();
        }
    }
}
