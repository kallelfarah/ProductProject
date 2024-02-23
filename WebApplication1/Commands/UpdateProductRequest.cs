using MediatR;
using WebApplication1.models;

namespace WebApplication1.Commands
{
    public class UpdateProductRequest : IRequest<bool>
    {
        public UpdateProductRequest(int id, Product product)
        {
            Id = id;
            Product = product;
        }

        public int Id { get; set; }
        public Product Product { get; set; }
    }
}
