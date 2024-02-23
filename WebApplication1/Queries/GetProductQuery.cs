using MediatR;
using WebApplication1.models;

namespace WebApplication1.Queries
{
    public class GetProductQuery : IRequest<Product>
    {
        public GetProductQuery(int id)
        {
            this.id = id;
        }

        public int id { get;  }

    }
}
