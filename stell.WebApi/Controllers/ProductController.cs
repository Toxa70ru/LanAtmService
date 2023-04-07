using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using stall.Application.interfaces;
using stall.Application.stalls.Commands.Create.seller;
using stall.WebApi.Models;
using Microsoft.EntityFrameworkCore;
using MediatR;
using stall.Application.stalls.Commands.Delete.seller;
using stall.Application.stalls.Queries.GetProducts;
using stall.Domain.seller;
using stall.Application.stalls.Queries.GetCategorys;
using stall.Application.stalls.Commands.Update.seller;

namespace stall.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {

        private readonly IMapper _mapper;

        private IMediator _mediator;
        protected IMediator Mediator =>
            _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        
        public ProductController(IMapper mapper) => _mapper = mapper;

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await Mediator.Send(new GetProductsQuery ());
            return Ok(products);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductVm>> Get(int id)
        {
            var query = new GetProductQuery
            {
                Product_id = id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id,[FromBody] UpdateProduct command)
        {
            command.Product_id = id;
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
                Product_id = id
            };
            await Mediator.Send(command).ConfigureAwait(false);
            return NoContent();
        }
    }
}
