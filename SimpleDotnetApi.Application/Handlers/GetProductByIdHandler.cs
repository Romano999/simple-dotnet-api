using MediatR;
using SimpleDotnetApi.Application.Queries;
using SimpleDotnetApi.Core.Database;
using SimpleDotnetApi.Core.Domain;

namespace SimpleDotnetApi.Application.Handlers
{
	public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, Product>
	{
		private readonly IProductRepository _productRepository;

		public GetProductByIdHandler(IProductRepository productRepository)
		{
			_productRepository = productRepository;
		}

		public async Task<Product?> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
		{
			return await _productRepository.GetByIdAsync(request.Id);
		}
	}
}
