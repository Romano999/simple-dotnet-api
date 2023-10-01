using MediatR;
using Microsoft.AspNetCore.Mvc;
using SimpleDotnetApi.Application.Queries;
using SimpleDotnetApi.Core.Domain;

namespace SimpleDotnetApi.Application.Endpoints
{
	[ApiController]
	public class GetAllProductsEndpoint : ControllerBase
	{
		private readonly IMediator _mediator;

		public GetAllProductsEndpoint(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet]
		[Route("products/all")]
		[ProducesResponseType(typeof(IEnumerable<Product>), StatusCodes.Status200OK)]
		[ProducesResponseType(typeof(NotFoundResult), StatusCodes.Status404NotFound)]
		public async Task<ActionResult> GetAllProducts()
		{
			var products = await _mediator.Send(new GetAllProductsQuery());


			return products.Any() ? Ok(products) : NotFound();
		}
	}
}
