namespace SimpleDotnetApi.Core.Database
{
	public interface IGenericRepository<T>
		where T : class
	{
		Task<T?> GetByIdAsync(int id);
		Task<IEnumerable<T>> GetAllAsync();
	}
}
