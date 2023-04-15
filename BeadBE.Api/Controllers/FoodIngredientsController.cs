using BeadBE.Application.BookingCellLogic.Commands.PutBookingCell;
using BeadBE.Application.FoodIngredientLogic.Commands.DeleteFoodIngredient;
using BeadBE.Application.FoodIngredientLogic.Commands.PostFoodIngredient;
using BeadBE.Application.FoodIngredientLogic.Commands.PutFoodIngredient;
using BeadBE.Contract.FoodIngredient;
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
    public class FoodIngredientsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ISender _mediator;

        public FoodIngredientsController(IMapper mapper, ISender mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> PostFoodIngredient(FoodIngredientRequest request)
        {
            var command = _mapper.Map<PostFoodIngredientCommand>(request);

            await _mediator.Send(command);

            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutFoodIngredient(int id, FoodIngredientRequest request)
        {
            var command = (id, request).Adapt<PutFoodIngredientCommand>();

            await _mediator.Send(command);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFoodIngredient(int id)
        {
            DeleteFoodIngredientCommand command = new(id);

            await _mediator.Send(command);

            return Ok();
        }
    }
}
