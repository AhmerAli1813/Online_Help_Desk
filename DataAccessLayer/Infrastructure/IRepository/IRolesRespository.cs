using OHD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OHD.DataAccessLayer.Infrastructure.IRepository
{
    public interface IRolesRespository : IRepository<Role>
    {
        void update(Role role);
    }
}
