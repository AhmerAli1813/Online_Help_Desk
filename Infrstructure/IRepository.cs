
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OHD.Infrastructure
{
    public interface IRepository<T>  : IDisposable
    {
        IEnumerable<T> GetAll(
            Expression<Func<T,bool>> filter = null,
            Func<IQueryable<T> , IOrderedQueryable<T>> orderby = null,
            string IncludeProperties = ""
            
            );
        T GetT(Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderby = null,
            string IncludeProperties = "");
        Task<T> GetTAsync(Expression<Func<T, bool>> filter = null,
			Func<IQueryable<T>, IOrderedQueryable<T>> orderby = null,
			string IncludeProperties = "");
        void Add(T entity);
        Task<T> AddAsync(T entity);
		void Update(T entity);
        Task<T> UpdateAsync(T entity);  
		void Delete(T entity);
        Task<T> DeleteAsync(T entity);
        
        
  
    }
}
