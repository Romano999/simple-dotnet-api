using MediatR;
using SimpleDotnetApi.Core.Domain;

namespace SimpleDotnetApi.Application.Queries
{
	public class GetProductByIdQuery : IRequest<Product>
	{
		public int Id { get; init; }

		public GetProductByIdQuery(int id)
		{
			this.Id = id;
		}
	}
}
