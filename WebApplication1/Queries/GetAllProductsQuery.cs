using MediatR;
using WebApplication1.models;

namespace WebApplication1.Queries
{
    public class GetAllProductsQuery : IRequest<IEnumerable<Product>>
    {
    }
}
