using MediatR;
using stall.Domain;
using stall.Domain.seller;
using stall.Application.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stall.Application.stalls.Commands.Create.seller
{
    public class CreateCategoryHandler : IRequestHandler<CreateCategory>
    {
        private readonly IstallDbContext _dbContext;
        public CreateCategoryHandler(IstallDbContext dbContext) =>
            _dbContext = dbContext;
        public async Task Handle(CreateCategory request, CancellationToken cancellationToken)
        {
            var category = new Category
            {
                Category_id = request.Category_id,
                Category_name = request.Category_name
            };
            await _dbContext.category.AddAsync(category, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return;
        }
    }
}
