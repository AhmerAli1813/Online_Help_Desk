using OHD.DataAccessLayer;

namespace OHD.Infrastructure
{
	public class UnitOfWork : IUnitOfWork, IDisposable
	{
		private readonly OHDDbContext _dbContext;

		public UnitOfWork(OHDDbContext dbContext)
		{
			_dbContext = dbContext;

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
					_dbContext.Dispose();
				}
			}
			this._disposed = true;
		}

		public IRepository<T> GenericRepository<T>() where T : class
		{
			IRepository<T> repo = new Repository<T>(_dbContext);
			return repo;
		}


		public void Save()
		{
			_dbContext.SaveChanges();
		}


		public async Task SaveAsync()
		{
			await _dbContext.SaveChangesAsync();
		}
	}
}
