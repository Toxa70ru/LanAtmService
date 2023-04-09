using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProductCatalog.core;
using ProductCatalog.core.Queries.GetProducts;
using ProductCatalog.Interfaces;
using ProductCatalog.Interfaces.Models;
using ProductCatalog.core.Queries.CreateProduct;
using ProductCatalog.core.Queries.DeleteProduct;
using ProductCatalog.core.Queries.GetProduct;
using ProductCatalog.core.Queries.UpdateProduct;

namespace ProductCatalog
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductCatalog : ControllerBase
    {
        private readonly IMapper _mapper;

        private IMediator _mediator;
        protected IMediator Mediator =>
            _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
        public ProductCatalog(IMapper mapper) => _mapper = mapper;

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await Mediator.Send(new GetProductsQuery());
            return Ok(products);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductVm>> Get(int id)
        {
            var query = new GetProductQuery
            {
                Id = id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] UpdateProduct command)
        {
            command.Id = id;
            await Mediator.Send(command);
            return Ok("Данные успешно изменены");
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateProduct createProduct)
        {
            var command = _mapper.Map<CreateProduct>(createProduct);
            await Mediator.Send(command);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteProduct
            {
                Id = id
            };
            await Mediator.Send(command).ConfigureAwait(false);
            return NoContent();
        }
    }
}
