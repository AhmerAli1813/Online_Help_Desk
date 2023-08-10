
using OHD.DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using OHD.DataAccessLayer.Infrastructure.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OHD.DataAccessLayer.Infrastructure.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly OHDDbContext _context;
        private readonly DbSet<T> _dbset;

        public Repository(OHDDbContext context)
        {
            _context = context;
            _dbset = _context.Set<T>();
        }

        public void Add(T entity)
        {
            _dbset.Add(entity);
        }

        public void Delete(T entity)
        {
            _dbset.Remove(entity);
        }

        public void DeleteRange(T entity)
        {
            _dbset.RemoveRange(entity);
        }


        public IEnumerable<T> GetAll(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderby = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
            bool disabledTranking = true
            )
        {
            IQueryable<T> query = _dbset;
            if (disabledTranking)
            {
                query = query.AsNoTracking();
            }
            if (filter != null)
            {
                query = query.Where(filter);
            }
            if (include != null)
            {
                query = include(query);
            }
            if (orderby != null)
            {
                return orderby(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        public T GetT(Expression<Func<T, bool>> predicate)
        {
            return _dbset.Where(predicate).FirstOrDefault();

        }

    }
}
