using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using stall.Application.stalls.Commands.Create.courier;
using stall.Application.stalls.Commands.Create.seller;
using stall.Application.stalls.Commands.Delete.seller;
using stall.Application.stalls.Commands.Update.courier;
using stall.Application.stalls.Commands.Update.seller;
using stall.Application.stalls.Queries.GetCategorys;
using stall.Application.stalls.Queries.GetProducts;
using stall.WebApi.Models;


namespace stall.WebApi.Controllers
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
            var categorys = await Mediator.Send(new GetCategorysQuery());
            return Ok(categorys);
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
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateCategory createCategory)
        {
            var command = _mapper.Map<CreateCategory>(createCategory);
            await Mediator.Send(command);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] UpdateCategory command)
        {
            command.Category_id = id;
            await Mediator.Send(command);
            return Ok("Данные успешно изменены");
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

