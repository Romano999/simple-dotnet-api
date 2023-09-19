using Npgsql;
using SimpleDotnetApi.Core.Database;
using SimpleDotnetApi.Core.Domain;

namespace SimpleDotnetApi.Adapter.Postgresql
{
	public class ProductRepository : IProductRepository
	{
		public ProductRepository()
		{
		}

		public Task<Product> GetAsync()
		{
			throw new NotImplementedException();
		}

		public async Task<IEnumerable<Product>> GetAllAsync()
		{
			var con = new NpgsqlConnection(
				connectionString: "Server=localhost;Port=5432;User Id=postgres;Password=test;Database=testdb;");
			con.Open();
			using var cmd = new NpgsqlCommand();
			cmd.Connection = con;

			cmd.CommandText = $"SELECT * FROM products";
			NpgsqlDataReader reader = await cmd.ExecuteReaderAsync();
			var result = new List<Product>();

			while (await reader.ReadAsync())
			{
				result.Add(new Product(
					id: (int)reader["id"],
					name: (string)reader["name"],
					description: (string)reader["description"],
					category: (string)reader["category"],
					price: (double)reader["price"],
					imageUrl: (string)reader["imageUrl"]
				));
			}
			return result;
		}
	}
}