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
    public class FacilityRespository : Repository<Facility>, IFacilityRespository
    {
        private readonly ApplicationDbContext  _dbContext;

        public FacilityRespository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public void update(Facility Facility)
        {
            _dbContext.Facilities.Update(Facility);
        }
    }
}
