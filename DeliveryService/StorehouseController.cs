using AutoMapper;
using DeliveryService.core.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DeliveryService
{
    [ApiController]
    [Route("api/[controller]")]
    public class StorehouseController : ControllerBase
    {
        private readonly IMapper _mapper;

        private IMediator _mediator;
        protected IMediator Mediator =>
            _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        public StorehouseController(IMapper mapper) => _mapper = mapper;

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categorys = await Mediator.Send(new GetStorehousesQuery());
            return Ok(categorys);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StorehouseVm>> Get(int id)
        {
            var query = new GetStorehouseQuery
            {
                Storehouse_id = id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateStorehouse createCategory)
        {
            var command = _mapper.Map<CreateStorehouse>(createCategory);
            await Mediator.Send(command);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] UpdateStorehouse command)
        {
            command.Storehouse_id = id;
            await Mediator.Send(command);
            return Ok("Данные успешно изменены");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteStorehouse
            {
                Storehouse_id = id
            };
            await Mediator.Send(command).ConfigureAwait(false);
            return NoContent();
        }
    }
}
