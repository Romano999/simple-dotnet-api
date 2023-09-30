using Moq;
using SimpleDotnetApi.Application.Handlers;
using SimpleDotnetApi.Application.Queries;
using SimpleDotnetApi.Application.UnitTest.ObjectMother;
using SimpleDotnetApi.Core.Database;
using SimpleDotnetApi.Core.Domain;

namespace SimpleDotnetApi.Application.UnitTest.UnitTest
{
	internal class GetAllProductsHandlerTests
	{
		private Mock<IProductRepository> _productRepository;

		[SetUp]
		public void SetUp()
		{
			_productRepository = new Mock<IProductRepository>();
		}

		[Test]
		public async Task GetAllProductsSuccesfully()
		{
			// Arrange
			var request = new GetAllProductsQuery();
			var expectedResult = GetProducts();
			_productRepository.Setup(x => x.GetAllAsync()).Returns(Task.FromResult(expectedResult));
			var handler = new GetAllProductsHandler(_productRepository.Object);

			// Act
			var actualResult = await handler.Handle(request, new CancellationToken());

			// Assert
			Assert.That(actualResult, Is.EqualTo(expectedResult));
		}

		[Test]
		public async Task GetAllProductsEmpty()
		{
			// Arrange
			var request = new GetAllProductsQuery();
			var handler = new GetAllProductsHandler(_productRepository.Object);

			// Act
			var actualResult = await handler.Handle(request, new CancellationToken());

			// Assert
			Assert.That(actualResult, Is.Empty);
		}

		private static IEnumerable<Product> GetProducts()
		{
			return new List<Product> {
				ProductMother.GenericProduct()
			};
		}
	}
}
