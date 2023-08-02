using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Infrastructure.IRepository
{
    public interface IRegisterRespository : IRepository<Register>
    {
        void update(Register role);
    }
}
