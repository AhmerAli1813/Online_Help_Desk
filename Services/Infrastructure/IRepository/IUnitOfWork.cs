using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Infrastructure.IRepository
{
    public interface IUnitOfWork
    {
        IRolesRespository RolesIU { get; }
        IFacilityRespository FacilityIU { get; }
        IRegisterRespository RegisterIU { get; }
        void save();
    }
}
