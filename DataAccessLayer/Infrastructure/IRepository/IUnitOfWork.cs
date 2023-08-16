using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OHD.DataAccessLayer.Infrastructure.IRepository
{
    public interface IUnitOfWork
    {
        IRepository<T> GenericRepository<T>()  where T : class;
        
        void Save();
         Task SaveAsync();
    }
}
