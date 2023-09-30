using System.ComponentModel.DataAnnotations;

namespace SimpleDotnetApi.Core.Domain
{
	public class Product
	{
		[Required]
		public int Id { get; set; }
		[Required]
		public string Name { get; set; }
		[Required]
		public string Description { get; set; }
		[Required]
		public string Category { get; set; }
		[Required]
		public double Price { get; set; }
		[Required]
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
