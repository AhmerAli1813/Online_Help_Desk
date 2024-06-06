using System.Linq.Expressions;

namespace OHD.Infrastructure
{
	public interface IRepository<T> : IDisposable
	{
		IEnumerable<T> GetAll(
			Expression<Func<T, bool>> filter = null,
			Func<IQueryable<T>, IOrderedQueryable<T>> orderby = null,
			string IncludeProperties = ""

			);
		Task<IEnumerable<T>> GetAllAsync(
			Expression<Func<T, bool>> filter = null,
			Func<IQueryable<T>, IOrderedQueryable<T>> orderby = null,
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
