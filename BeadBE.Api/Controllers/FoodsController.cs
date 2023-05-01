using BeadBE.Application.FoodLogic.Commands.DeleteFood;
using BeadBE.Application.FoodLogic.Commands.PostFood;
using BeadBE.Application.FoodLogic.Commands.PutFood;
using BeadBE.Application.FoodLogic.Queries.GetFood;
using BeadBE.Application.FoodLogic.Queries.GetFoodDetails;
using BeadBE.Application.FoodLogic.Queries.GetFoods;
using BeadBE.Application.FoodLogic.Queries.GetFoodsDetailsByEateryId;
using BeadBE.Contract.Food;
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
    public class FoodsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ISender _mediator;

        public FoodsController(IMapper mapper, ISender mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetFoods()
        {
            GetFoodsQuery query = new();

            var response = _mapper.Map<FoodsResponse>(await _mediator.Send(query));

            return Ok(response.Foods);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFoodById(int id)
        {
            GetFoodQuery query = new(id);

            var response = _mapper.Map<FoodResponse>(await _mediator.Send(query));

            return Ok(response);
        }

        [HttpGet("{id}/details")]
        public async Task<IActionResult> GetFoodDetailsById(int id)
        {
            GetFoodDetailsByIdQuery query = new(id);

            var response = _mapper.Map<FoodDetailsResponse>(await _mediator.Send(query));
            
            return Ok(response);
        }

        [HttpGet("details/eatery/{id}")]
        public async Task<IActionResult> GetFoodsByEateryId(int id)
        {
            GetFoodsDetailsByEateryIdQuery query = new(id);

            var response = _mapper.Map<FoodsDetailsResponse>(await _mediator.Send(query));

            return Ok(response.FoodsDetails);
        }

        [HttpPost]
        public async Task<IActionResult> PostFood(FoodRequest request)
        {
            var command = _mapper.Map<PostFoodCommand>(request);

            await _mediator.Send(command);

            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutFood(int id, FoodRequest request)
        {
            var command = (id, request).Adapt<PutFoodCommand>();

            await _mediator.Send(command);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFood(int id)
        {
            DeleteFoodCommand command = new(id);

            await _mediator.Send(command);

            return Ok();
        }
    }
}
