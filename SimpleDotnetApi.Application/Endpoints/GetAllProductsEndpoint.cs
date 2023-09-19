using MediatR;
using Microsoft.AspNetCore.Mvc;
using SimpleDotnetApi.Application.Queries;
using SimpleDotnetApi.Core.Domain;

namespace SimpleDotnetApi.Application.Endpoints
{
	[Route("api/[controller]")]
	[ApiController]
	public class GetAllProductsEndpoint : ControllerBase
	{
		private readonly IMediator _mediator;

		public GetAllProductsEndpoint(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet]
		[ProducesResponseType(typeof(IEnumerable<Product>), StatusCodes.Status200OK)]
		public async Task<ActionResult> GetAllProducts()
		{
			var products = await _mediator.Send(new GetAllProductsQuery());
			return Ok(products);
		}

	}
}
