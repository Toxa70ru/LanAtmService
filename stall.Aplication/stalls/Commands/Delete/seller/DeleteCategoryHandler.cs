using MediatR;
using stall.Application.interfaces;
using stall.Application.Common.Exceptions;
using stall.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stall.Application.stalls.Commands.Delete.seller
{
    public class DeleteCategoryHandler : IRequestHandler<DeleteCategory,Unit>
    {
        private readonly IstallDbContext _dbContext;

        public DeleteCategoryHandler(IstallDbContext dbContext) =>
            _dbContext = dbContext;
        public async Task<Unit> Handle(DeleteCategory request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.category
                .FindAsync(new object[] { request.Category_id }, cancellationToken);
            if (entity == null || entity.Category_id != request.Category_id) 
            {
                throw new NotFoundException();
            }
            var id = entity.Category_id;
            _dbContext.category.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
