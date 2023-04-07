using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using stall.Application.stalls.Commands.Create.courier;
using stall.Application.stalls.Commands.Create.customer;
using stall.Application.stalls.Commands.Create.seller;
using stall.Application.stalls.Commands.Delete.courier;
using stall.Application.stalls.Commands.Delete.customer;
using stall.Application.stalls.Commands.Update.courier;
using stall.Application.stalls.Commands.Update.customer;
using stall.Application.stalls.Queries.GetDelivery;
using stall.Application.stalls.Queries.GetOrders;
using stall.WebApi.Models;

namespace stall.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DeliveryController : ControllerBase
    {
        private readonly IMapper _mapper;

        private IMediator _mediator;
        protected IMediator Mediator =>
            _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        public DeliveryController(IMapper mapper) => _mapper = mapper;

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categorys = await Mediator.Send(new GetDeliverysQuery());
            return Ok(categorys);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DeliveryVm>> Get(int id)
        {
            var query = new GetDeliveryQuery
            {
                Delivery_id = id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateDelivery createCategory)
        {
            var command = _mapper.Map<CreateDelivery>(createCategory);
            await Mediator.Send(command);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] UpdateDelivery command)
        {
            command.Delivery_id = id;
            await Mediator.Send(command);
            return Ok("Данные успешно изменены");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteDelivery
            {
                Delivery_id = id
            };
            await Mediator.Send(command).ConfigureAwait(false);
            return NoContent();
        }
    }
}

