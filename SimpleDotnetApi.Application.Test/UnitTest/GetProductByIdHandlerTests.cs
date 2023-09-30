using Moq;
using SimpleDotnetApi.Application.Handlers;
using SimpleDotnetApi.Application.Queries;
using SimpleDotnetApi.Application.UnitTest.ObjectMother;
using SimpleDotnetApi.Core.Database;
using SimpleDotnetApi.Core.Domain;

namespace SimpleDotnetApi.Application.UnitTest.UnitTest
{
	internal class GetProductByIdHandlerTests
	{
		private Mock<IProductRepository> _productRepository;

		[SetUp]
		public void SetUp()
		{
			_productRepository = new Mock<IProductRepository>();
		}

		[Test]
		public async Task GetProductByIdSuccesfully()
		{
			// Arrange
			var id = 1;
			var request = new GetProductByIdQuery(id);
			var expectedResult = GetProduct();
			_productRepository.Setup(x => x.GetByIdAsync(id)).Returns(Task.FromResult<Product?>(expectedResult));
			var handler = new GetProductByIdHandler(_productRepository.Object);

			// Act
			var actualResult = await handler.Handle(request, new CancellationToken());

			// Assert
			Assert.That(actualResult, Is.EqualTo(expectedResult));
		}

		[Test]
		public async Task GetProductByIdEmpty()
		{
			// Arrange
			var id = 1;
			var request = new GetProductByIdQuery(id);
			var handler = new GetProductByIdHandler(_productRepository.Object);

			// Act
			var actualResult = await handler.Handle(request, new CancellationToken());

			// Assert
			Assert.That(actualResult, Is.Null);
		}

		private static Product GetProduct()
		{
			return ProductMother.GenericProduct();
		}
	}
}
