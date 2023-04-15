﻿using BeadBE.Application.EateryLogic.Commands.DeleteEatery;
using BeadBE.Application.EateryLogic.Commands.PostEatery;
using BeadBE.Application.EateryLogic.Commands.PutEatery;
using BeadBE.Application.EateryLogic.Queries.GetEatery;
using BeadBE.Contract.Eatery;
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
    public class EateriesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ISender _mediator;

        public EateriesController(IMapper mapper, ISender mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetEaterys()
        {
            var query = new GetEateriesQuery();

            var response = _mapper.Map<EateriesResponse>(await _mediator.Send(query));

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEateryById(int id)
        {
            GetEateryQuery query = new(id);

            var response = _mapper.Map<EateryResponse>(await _mediator.Send(query));

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> PostEatery(EateryRequest request)
        {
            var command = _mapper.Map<PostEateryCommand>(request);

            await _mediator.Send(command);

            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutEatery(int id, EateryRequest request)
        {
            var command = (id, request).Adapt<PutEateryCommand>();

            await _mediator.Send(command);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEatery(int id)
        {
            DeleteEateryCommand command = new(id);

            await _mediator.Send(command);

            return Ok();
        }
    }
}
