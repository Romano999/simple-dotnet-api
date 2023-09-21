using MediatR;
using SimpleDotnetApi.Core.Domain;

namespace SimpleDotnetApi.Application.Queries
{
    public class GetAllProductsQuery : IRequest<IEnumerable<Product>>
    {

    }
}
