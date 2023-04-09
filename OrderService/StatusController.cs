﻿using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using OrderService.core.Queries;

namespace OrderService
{
    [ApiController]
    [Route("api/[controller]")]
    public class StatusController : ControllerBase
    {
        private readonly IMapper _mapper;

        private IMediator _mediator;
        protected IMediator Mediator =>
            _mediator ??= HttpContext.RequestServices.GetService<IMediator>();


        public StatusController(IMapper mapper) => _mapper = mapper;

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await Mediator.Send(new GetStatussQuery());
            return Ok(products);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<StatusVm>> Get(int id)
        {
            var query = new GetStatusQuery
            {
                Status_id = id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] UpdateStatus command)
        {
            command.Status_id = id;
            await Mediator.Send(command);
            return Ok("Данные успешно изменены");
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateStatus createProduct)
        {
            var command = _mapper.Map<CreateStatus>(createProduct);
            await Mediator.Send(command);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteStatus
            {
                Status_id = id
            };
            await Mediator.Send(command).ConfigureAwait(false);
            return NoContent();
        }
    }
}