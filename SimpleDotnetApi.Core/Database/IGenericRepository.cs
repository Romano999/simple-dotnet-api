namespace SimpleDotnetApi.Core.Database
{
	public interface IGenericRepository<T>
		where T : class
	{
		Task<T> GetAsync();
		Task<IEnumerable<T>> GetAllAsync();
	}
}
