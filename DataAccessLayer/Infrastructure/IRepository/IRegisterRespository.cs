using OHD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OHD.DataAccessLayer.Infrastructure.IRepository
{
    public interface IRegisterRespository : IRepository<Register>
    {
        void update(Register role);
    }
}
