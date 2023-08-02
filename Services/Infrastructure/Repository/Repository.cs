
using DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using Services.Infrastructure.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Services.Infrastructure.Repository
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

        public IEnumerable<T> GetAll()
        {
            return _dbset.ToList();
        }

        public T GetT(Expression<Func<T, bool>> predicate)
        {
            return _dbset.Where(predicate).FirstOrDefault();

        }
    }
}
