using MediatR;
using ProductCatalog.Interfaces.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog.core.Queries.CreateCategory
{
    public class CreateCategoryHandler : IRequestHandler<CreateCategory>
    {
        private readonly IPCDbContext _dbContext;
        public CreateCategoryHandler(IPCDbContext dbContext) =>
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
