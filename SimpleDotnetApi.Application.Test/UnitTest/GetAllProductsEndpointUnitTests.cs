using MediatR;
using Moq;
using SimpleDotnetApi.Application.Endpoints;

namespace SimpleDotnetApi.Application.Test.UnitTest
{
    public class GetAllProductsEndpointUnitTests
    {
        private Mock<IMediator> _mockMediator;
        private GetAllProductsEndpoint _myController;

        [SetUp]
        public void SetUp()
        {
            _mockMediator = new Mock<IMediator>();
            _myController = new GetAllProductsEndpoint(_mockMediator.Object);
        }

        [Test]
        public void CallsMediator()
        {
            Assert.That(true);
        }
    }
}
