using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OHD.DataAccessLayer.Infrastructure.IRepository
{
    public interface IRepository<T>  where T : class
    {
        IEnumerable<T> GetAll(
            Expression<Func<T,bool>> filter = null,
            Func<IQueryable<T> , IOrderedQueryable<T>> orderby = null,
            string IncludeProperties = ""
            
            );
        T GetT(Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderby = null,
            string IncludeProperties = "");
        void Add(T entity);
        void Delete(T entity);
        void DeleteRange(T entity);
        
        
    }
}
