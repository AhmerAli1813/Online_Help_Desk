using OHD.DataAccessLayer;
using OHD.Models;
using OHD.DataAccessLayer.Infrastructure.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OHD.DataAccessLayer.Infrastructure.Repository
{
    public class RolesRespository : Repository<Roles>, IRolesRespository
    {
        private readonly OHDDbContext  _dbContext;

        public RolesRespository(OHDDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public void update(Roles role)
        {
            _dbContext.Roles.Update(role);
        }
    }
}
