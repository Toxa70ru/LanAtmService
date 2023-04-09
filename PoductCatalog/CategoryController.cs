using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProductCatalog.core.Queries.CreateCategory;
using ProductCatalog.core.Queries.DeleteCategory;
using ProductCatalog.core.Queries.GetCategorys;
using ProductCatalog.core.Queries.UpdateCategory;

namespace ProductCatalog
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly IMapper _mapper;

        private IMediator _mediator;
        protected IMediator Mediator =>
            _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
        public CategoryController(IMapper mapper) => _mapper = mapper;

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await Mediator.Send(new GetCategorysQuery());
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryVm>> Get(int id)
        {
            var query = new GetCategoryQuery
            {
                Category_id = id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] UpdateCategory command)
        {
            command.Category_id = id;
            await Mediator.Send(command);
            return Ok("Данные успешно изменены");
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateCategory createProduct)
        {
            var command = _mapper.Map<CreateCategory>(createProduct);
            await Mediator.Send(command);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteCategory
            {
                Category_id = id
            };
            await Mediator.Send(command).ConfigureAwait(false);
            return NoContent();
        }
    }
}
