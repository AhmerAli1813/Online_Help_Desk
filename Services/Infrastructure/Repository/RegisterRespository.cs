using DataAccessLayer;
using Models;
using Services.Infrastructure.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Infrastructure.Repository
{
    public class RegisterRespository : Repository<Register>, IRegisterRespository
    {
        private readonly OHDDbContext  _dbContext;

        public RegisterRespository(OHDDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public void update(Register Register)
        {
            _dbContext.Registers.Update(Register);
        }
    }
}
