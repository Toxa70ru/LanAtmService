using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using OrderService.core.Queries;

namespace OrderService
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {

        private readonly IMapper _mapper;

        private IMediator _mediator;
        protected IMediator Mediator =>
            _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        public OrderController(IMapper mapper) => _mapper = mapper;

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categorys = await Mediator.Send(new GetOrdersQuery());
            return Ok(categorys);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrderVm>> Get(int id)
        {
            var query = new GetOrderQuery
            {
                Order_id = id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateOrder createCategory)
        {
            var command = _mapper.Map<CreateOrder>(createCategory);
            await Mediator.Send(command);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] UpdateOrder command)
        {
            command.Order_id = id;
            await Mediator.Send(command);
            return Ok("Данные успешно изменены");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteOrder
            {
                Order_id = id
            };
            await Mediator.Send(command).ConfigureAwait(false);
            return NoContent();
        }

    }
}

