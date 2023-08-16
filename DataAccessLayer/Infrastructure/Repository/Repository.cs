
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
    public class Repository<T> : IDisposable, IRepository<T> where T : class
    {
        private readonly OHDDbContext _context;
        internal  DbSet<T> _dbset;

        public Repository(OHDDbContext context)
        {
            _context = context;
            _dbset = _context.Set<T>();
        }

        public void Add(T entity)
        {
            _dbset.Add(entity);
        }

		public async Task<T> AddAsync(T entity)
		{
            _dbset.AddAsync(entity);
            return entity;
		}

		public void Delete(T entity)
        {
            if(_context.Entry(entity).State == EntityState.Detached)
            {
                _dbset.Attach(entity);
            }
            _dbset.Remove(entity);
        }

		public async Task<T> DeleteAsync(T entity)
		{
			if (_context.Entry(entity).State == EntityState.Detached)
			{
				_dbset.Attach(entity);
			}
			_dbset.Remove(entity);
            return entity;
		}

		public void DeleteRange(T entity)
        {
            _dbset.RemoveRange(entity);
        }
        private bool _disposed;
		public void Dispose()
		{
            Dispose(true);
            GC.SuppressFinalize(this);
		}

		private void Dispose(bool disposing)
		{
            if (!this._disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this._disposed = true;
		}

		public IEnumerable<T> GetAll(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderby = null,
            string IncludeProperties = ""
            )
        {
            IQueryable<T> query = _dbset;
            
            if (filter != null)
            {
                query = query.Where(filter);
            }
            foreach (var Include in
                IncludeProperties.Split(new char[] {','},StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(Include);
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


        public T GetT(Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderby = null,
            string IncludeProperties = "")
        {
            IQueryable<T> query = _dbset;

            if (filter != null)
            {
                query = query.Where(filter);
            }
            foreach (var Include in
                IncludeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(Include);
            }
            if (orderby != null)
            {
                return orderby(query).FirstOrDefault();
            }
            else
            {
                return query.FirstOrDefault();
            }

        }

		public async Task<T> GetTAsync(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderby = null, string IncludeProperties = "")
		{
			IQueryable<T> query = _dbset;

			if (filter != null)
			{
				query = query.Where(filter);
			}
			foreach (var Include in
				IncludeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
			{
				query = query.Include(Include);
			}
			if (orderby != null)
			{
				return  await orderby(query).FirstOrDefaultAsync();
			}
			else
			{
				return await query.FirstOrDefaultAsync();
			}
		}

		public void Update(T entity)
		{

			_dbset.Attach(entity);
			_context.Entry(entity).State = EntityState.Modified;
		}

		public async Task<T> UpdateAsync(T entity)
		{

			_dbset.Attach(entity);
			_context.Entry(entity).State = EntityState.Modified;
            return entity;
		}
	}
}
