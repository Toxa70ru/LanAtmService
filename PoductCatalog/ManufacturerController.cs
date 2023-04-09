using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProductCatalog.core.Queries.CreateCategory;
using ProductCatalog.core.Queries.DeleteCategory;
using ProductCatalog.core.Queries.DeleteManufacturers;
using ProductCatalog.core.Queries.GetCategorys;
using ProductCatalog.core.Queries.GetManufacturers;
using ProductCatalog.core.Queries.UpdateCategory;
using ProductCatalog.core.Queries.UpdateManufacturers;

namespace ProductCatalog
{
    [ApiController]
    [Route("api/[controller]")]
    public class ManufacturerController : ControllerBase
    {
        private readonly IMapper _mapper;

        private IMediator _mediator;
        protected IMediator Mediator =>
            _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
        public ManufacturerController(IMapper mapper) => _mapper = mapper;

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await Mediator.Send(new GetManufacturersQuery());
            return Ok(products);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ManufacturerVm>> Get(int id)
        {
            var query = new GetManufacturerQuery
            {
                Brend_id = id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] UpdateManufacturer command)
        {
            command.Brend_id = id;
            await Mediator.Send(command);
            return Ok("Данные успешно изменены");
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateManufacturer createProduct)
        {
            var command = _mapper.Map<CreateManufacturer>(createProduct);
            await Mediator.Send(command);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteManufacturer
            {
                Brend_id = id
            };
            await Mediator.Send(command).ConfigureAwait(false);
            return NoContent();
        }
    }
}
