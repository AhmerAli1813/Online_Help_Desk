using DataAccessLayer;
using Services.Infrastructure.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly OHDDbContext _dbContext;

        public UnitOfWork(OHDDbContext dbContext)
        {
            _dbContext = dbContext;
            RolesIU = new RolesRespository(dbContext);

        }

        public IRolesRespository RolesIU { get; private set; }

        public void save()
        {
            _dbContext.SaveChanges();   
        }
    }
}
