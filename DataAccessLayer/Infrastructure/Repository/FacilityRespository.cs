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
    public class FacilityRespository : Repository<Facility>, IFacilityRespository
    {
        private readonly OHDDbContext  _dbContext;

        public FacilityRespository(OHDDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public void update(Facility Facility)
        {
            _dbContext.Facilities.Update(Facility);
        }
    }
}
