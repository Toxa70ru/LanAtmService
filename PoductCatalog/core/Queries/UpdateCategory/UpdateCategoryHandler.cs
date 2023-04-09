using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;
using ProductCatalog.core.Queries.GetCategorys;

namespace ProductCatalog.core.Queries.UpdateCategory
{
    public class UpdateCategoryHandler : IRequestHandler<UpdateCategory,CategoryVm>
    {
        private readonly IPCDbContext _dbContext;
        public UpdateCategoryHandler(IPCDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<CategoryVm> Handle(UpdateCategory request, CancellationToken cancellationToken) 
        {
            var entity =
                await _dbContext.category.FirstOrDefaultAsync(category =>
                category.Category_id == request.Category_id, cancellationToken);

            if (entity == null || entity.Category_id != request.Category_id) 
            {
                //throw new NotFoundException();
            }

            entity.Category_id = request.Category_id;
            entity.Category_name = request.Category_name;
            await _dbContext.SaveChangesAsync(cancellationToken);
            var model = new CategoryVm { Category_id = entity.Category_id,Category_name = entity.Category_name}; 
            return model;
            
        }
    }
}
