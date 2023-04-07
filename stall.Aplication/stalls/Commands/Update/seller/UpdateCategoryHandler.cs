using MediatR;
using Microsoft.EntityFrameworkCore;
using stall.Application.interfaces;
using stall.Application.Common.Exceptions;
using stall.Domain;
using System;
using System.Threading;
using System.Threading.Tasks;
using stall.Application.stalls.Queries.GetCategorys;

namespace stall.Application.stalls.Commands.Update.seller
{
    public class UpdateCategoryHandler : IRequestHandler<UpdateCategory,CategoryVm>
    {
        private readonly IstallDbContext _dbContext;
        public UpdateCategoryHandler(IstallDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<CategoryVm> Handle(UpdateCategory request, CancellationToken cancellationToken) 
        {
            var entity =
                await _dbContext.category.FirstOrDefaultAsync(category =>
                category.Category_id == request.Category_id, cancellationToken);

            if (entity == null || entity.Category_id != request.Category_id) 
            {
                throw new NotFoundException();
            }

            entity.Category_id = request.Category_id;
            entity.Category_name = request.Category_name;
            await _dbContext.SaveChangesAsync(cancellationToken);
            var model = new CategoryVm { Category_id = entity.Category_id,Category_name = entity.Category_name}; 
            return model;
            
        }
    }
}
