using MediatR;
using Microsoft.AspNetCore.Mvc.Testing;
using Moq;
using SimpleDotnetApi.Application.Endpoints;

namespace SimpleDotnetApi.Application.Test.IntegrationTest
{
    public class GetAllProductsEndpointIntegrationTests
        : WebApplicationFactory<Program>
    {
        private Mock<IMediator> _mockMediator;
        private GetAllProductsEndpoint _myController;

        [SetUp]
        public void SetUp()
        {

        }

        [Test]
        public void GetAllProducts()
        {
            Assert.That(true);
        }
    }
}
