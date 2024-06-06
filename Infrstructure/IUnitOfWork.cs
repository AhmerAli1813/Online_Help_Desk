namespace OHD.Infrastructure
{
	public interface IUnitOfWork
	{
		IRepository<T> GenericRepository<T>() where T : class;

		void Save();
		Task SaveAsync();
	}
}
