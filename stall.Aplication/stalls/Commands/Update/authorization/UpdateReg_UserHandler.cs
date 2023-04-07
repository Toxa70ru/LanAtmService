using MediatR;
using stall.Application.Common.Exceptions;
using stall.Application.interfaces;
using stall.Application.stalls.Commands.Update.authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace stall.Application.stalls.Commands.Update.authorization
{
    public class UpdateReg_UserHandler : IRequestHandler<UpdateReg_User>
    {
        private readonly IstallDbContext _dbContext;
        public UpdateReg_UserHandler(IstallDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Unit> Handle(UpdateReg_User request, CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.reg_User.FirstOrDefaultAsync(ruser =>
                ruser.User_id == request.User_id, cancellationToken);

            if (entity == null || entity.User_id != request.User_id)
            {
                throw new NotFoundException();
            }

            entity.User_id = request.User_id;
            entity.Surname = request.Surname;
            entity.Name = request.Name;
            entity.Midlename = request.Midlename;
            entity.Birthday = request.Birthday;
            entity.Phone_Number = request.Phone_Number;
            entity.Role_id = request.Role_id;
            entity.Login = request.Login;
            entity.Password = request.Password;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }

        Task IRequestHandler<UpdateReg_User>.Handle(UpdateReg_User request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
