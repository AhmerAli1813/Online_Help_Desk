using OHD.DataAccessLayer;
using OHD.DataAccessLayer.Infrastructure.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OHD.DataAccessLayer.Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly OHDDbContext _dbContext;

        public UnitOfWork(OHDDbContext dbContext)
        {
            _dbContext = dbContext;
            RolesIU = new RolesRespository(dbContext);
            FacilityIU = new FacilityRespository(dbContext);
            RegisterIU = new RegisterRespository(dbContext);

        }

        public IRolesRespository RolesIU { get; private set; }

        public IFacilityRespository FacilityIU { get; private set; }
      public IRegisterRespository RegisterIU { get; private set; }

        public void save()
        {
            _dbContext.SaveChanges();   
        }
    }
}
