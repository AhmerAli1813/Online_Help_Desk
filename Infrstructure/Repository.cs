
using Microsoft.EntityFrameworkCore;
using OHD.DataAccessLayer;
using OHD.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OHD.Infrastructure
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

        public void Add(T entity)
        {
            _dbset.Add(entity);
        }

		public async Task<T> AddAsync(T entity)
		{
            await _dbset.AddAsync(entity);
            return  entity;
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
        
		public IEnumerable<T> GetAll(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderby = null,
            string IncludeProperties = ""
            )
                {
                    IQueryable<T> query = _dbset;
            
                    if (filter != null)
                    {
                        query = query.AsNoTracking().Where(filter);
                    }
                    foreach (var Include in
                        IncludeProperties.Split(new char[] {','},StringSplitOptions.RemoveEmptyEntries))
                    {
                        query = query.AsNoTracking().Include(Include);
                    }
                    if (orderby != null)
                    {
                        return orderby(query).AsNoTracking().ToList();
                    }
                    else
                    {
                        return query.AsNoTracking().ToList();
                    }
                }

        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderby = null,
            string IncludeProperties = ""
          )
                {
                    IQueryable<T> query = _dbset;

                    if (filter != null)
                    {
                       query = query.AsNoTracking().Where(filter);
                    }
                    foreach (var Include in
                        IncludeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                    {
                        query = query.AsNoTracking().Include(Include);
                    }
                    if (orderby != null)
                    {
                        return await orderby(query).AsNoTracking().ToListAsync();
                    }
                    else
                    {
                        return  await query.AsNoTracking().ToListAsync();
                    }
                }

        public T GetT(Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderby = null,
            string IncludeProperties = "")
        {
            IQueryable<T> query = _dbset;

            if (filter != null)
            {
                query = query.AsNoTracking().Where(filter);
            }
            foreach (var Include in
                IncludeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.AsNoTracking().Include(Include);
            }
            if (orderby != null)
            {
                return orderby(query).AsNoTracking().FirstOrDefault();
            }
            else
            {
                return query.AsNoTracking().FirstOrDefault();
            }

        }

		public async Task<T> GetTAsync(Expression<Func<T, bool>> filter = null,
                                Func<IQueryable<T>, 
                                    IOrderedQueryable<T>> orderby = null,
                                string IncludeProperties = "")
         
		{
			        IQueryable<T> query = _dbset;

			        if (filter != null)
			        {
				        query = query.AsNoTracking().Where(filter);
			        }
			        foreach (var Include in
				        IncludeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
			        {
				        query = query.AsNoTracking().Include(Include);
			        }
			        if (orderby != null)
			        {
				        return  await orderby(query).AsNoTracking().FirstOrDefaultAsync();
			        }
			        else
			        {
				        return await query.AsNoTracking().FirstOrDefaultAsync();
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
			_context.Entry(entity).State =  EntityState.Modified;
             return entity;
		}

        
    }
}
