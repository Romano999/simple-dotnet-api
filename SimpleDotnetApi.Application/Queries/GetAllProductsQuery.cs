using MediatR;
using SimpleDotnetApi.Core.Domain;

namespace SimpleDotnetApi.Application.Queries
{
	public record GetAllProductsQuery() : IRequest<IEnumerable<Product>>
	{

	}
}
