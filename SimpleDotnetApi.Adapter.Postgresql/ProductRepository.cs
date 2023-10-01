using Microsoft.Extensions.Options;
using Npgsql;
using SimpleDotnetApi.Core.Database;
using SimpleDotnetApi.Core.Domain;
using SimpleDotnetApi.Core.Settings;

namespace SimpleDotnetApi.Adapter.Postgresql
{
	public class ProductRepository : IProductRepository
	{
		private readonly IOptions<DatabaseSettings> _settings;

		public ProductRepository(IOptions<DatabaseSettings> settings)
		{
			_settings = settings;
		}

		public async Task<IEnumerable<Product>> GetAllAsync()
		{
			var connectionString = $"Server={_settings.Value.Server};Port={_settings.Value.Port};User Id={_settings.Value.User};Password={_settings.Value.Password};Database={_settings.Value.Database};";
			var con = new NpgsqlConnection(
				connectionString: connectionString);
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

		public async Task<Product?> GetByIdAsync(int id)
		{
			var connectionString = $"Server={_settings.Value.Server};Port={_settings.Value.Port};User Id={_settings.Value.User};Password={_settings.Value.Password};Database={_settings.Value.Database};";
			var con = new NpgsqlConnection(
				connectionString: connectionString);
			con.Open();
			using var cmd = new NpgsqlCommand();
			cmd.Connection = con;

			cmd.CommandText = $"SELECT * FROM products WHERE id={id}";
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

			return result.Any() ? result[0] : null;
		}
	}
}