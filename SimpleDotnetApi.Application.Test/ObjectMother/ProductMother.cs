using SimpleDotnetApi.Core.Domain;

namespace SimpleDotnetApi.Application.UnitTest.ObjectMother
{
	public static class ProductMother
	{
		public static Product GenericProduct()
		{
			return new Product(
				id: 1,
				name: "Generic product",
				description: "A generic product",
				category: "None",
				price: 99,
				imageUrl: ""
			);
		}
	}
}
