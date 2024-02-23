using MediatR;
using WebApplication1.models;

namespace WebApplication1.Commands
{
    public class CreateProductRequest: IRequest<Product>
    {

        public CreateProductRequest(Product product)
        {
            this.product = product;
        }

        public Product product { get; }

    }
}
