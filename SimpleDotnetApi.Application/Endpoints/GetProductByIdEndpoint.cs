using MediatR;
using Microsoft.AspNetCore.Mvc;
using SimpleDotnetApi.Application.Queries;
using SimpleDotnetApi.Core.Domain;

namespace SimpleDotnetApi.Application.Endpoints
{
	[ApiController]
	public class GetProductByIdEndpoint : ControllerBase
	{
		private readonly IMediator _mediator;

		public GetProductByIdEndpoint(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet]
		[Route("products/{id}")]
		[ProducesResponseType(typeof(Product), StatusCodes.Status200OK)]
		[ProducesResponseType(typeof(NotFoundResult), StatusCodes.Status404NotFound)]
		public async Task<ActionResult> GetProductById(int id)
		{
			GetProductByIdQuery request = new(id);
			var product = await _mediator.Send(request);

			return product != null ? Ok(product) : NotFound();
		}
	}
}
