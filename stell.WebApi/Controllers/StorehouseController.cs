using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using stall.Application.stalls.Commands.Create.seller;
using stall.Application.stalls.Commands.Delete.seller;
using stall.Application.stalls.Commands.Update.seller;
using stall.Application.stalls.Queries.GetManufacturers;
using stall.Application.stalls.Queries.GetStorehouse;

namespace stall.WebApi.Controllers
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
            var products = await Mediator.Send(new GetStorehousesQuery());
            return Ok(products);
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

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] UpdateStorehouse command)
        {
            command.Storehouse_id = id;
            await Mediator.Send(command);
            return Ok("Данные успешно изменены");
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateStorehouse createProduct)
        {
            var command = _mapper.Map<CreateStorehouse>(createProduct);
            await Mediator.Send(command);
            return Ok();
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
