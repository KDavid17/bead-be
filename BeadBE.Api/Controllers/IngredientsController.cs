using BeadBE.Application.IngredientLogic.Commands.DeleteIngredient;
using BeadBE.Application.IngredientLogic.Commands.PostIngredient;
using BeadBE.Application.IngredientLogic.Commands.PutIngredient;
using BeadBE.Application.IngredientLogic.Queries.GetIngredient;
using BeadBE.Contract.Ingredient;
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
    public class IngredientsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ISender _mediator;

        public IngredientsController(IMapper mapper, ISender mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetIngredients()
        {
            var query = new GetIngredientsQuery();

            var response = _mapper.Map<IngredientsResponse>(await _mediator.Send(query));

            return Ok(response.Ingredients);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetIngredientById(int id)
        {
            GetIngredientQuery query = new(id);

            var response = _mapper.Map<IngredientResponse>(await _mediator.Send(query));

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> PostIngredient(IngredientRequest request)
        {
            var command = _mapper.Map<PostIngredientCommand>(request);

            await _mediator.Send(command);

            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutIngredient(int id, IngredientRequest request)
        {
            var command = (id, request).Adapt<PutIngredientCommand>();

            await _mediator.Send(command);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIngredient(int id)
        {
            DeleteIngredientCommand command = new(id);

            await _mediator.Send(command);

            return Ok();
        }
    }
}
