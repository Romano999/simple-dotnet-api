namespace SimpleDotnetApi.Core.Domain
{
	public class Product
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public string Category { get; set; }
		public double Price { get; set; }
		public string ImageUrl { get; set; }

		public Product(int id, string name, string description, string category, double price, string imageUrl)
		{
			Id = id;
			Name = name;
			Description = description;
			Category = category;
			Price = price;
			ImageUrl = imageUrl;
		}
	}
}
