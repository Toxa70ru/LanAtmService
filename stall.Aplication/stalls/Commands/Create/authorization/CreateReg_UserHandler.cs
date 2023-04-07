using MediatR;
using stall.Application.interfaces;
using stall.Application.stalls.Commands.Create.courier;
using stall.Domain.authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stall.Application.stalls.Commands.Create.authorization
{
    public class CreateReg_UserHandler : IRequestHandler<CreateReg_User>
    {
        private readonly IstallDbContext _dbContext;
        public CreateReg_UserHandler(IstallDbContext dbContext) =>
            _dbContext = dbContext;
        public async Task Handle(CreateReg_User request, CancellationToken cancellationToken)
        {
            var reg_user = new Reg_User
            {
                User_id = request.User_id,
                Surname = request.Surname,
                Name = request.Name,
                Midlename = request.Midlename,
                Birthday = request.Birthday,
                Phone_Number = request.Phone_Number,
                Login = request.Login,
                Password = request.Password,
                Role_id = request.Role_id
            };
            await _dbContext.reg_User.AddAsync(reg_user, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return;
        }
    }
}
