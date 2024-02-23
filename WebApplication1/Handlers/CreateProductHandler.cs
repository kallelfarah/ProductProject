using AutoMapper;
using MediatR;
using WebApplication1.Commands;
using WebApplication1.Data;
using WebApplication1.models;

namespace WebApplication1.Handlers
{
    public class CreateProductHandler : IRequestHandler<CreateProductRequest, Product>
    {
        public readonly AppDbContext _context;
        public readonly IMapper _mapper;

        public CreateProductHandler(AppDbContext context, IMapper _mapper)
        {
            _context = context;
            _mapper = _mapper;
        }

        public async Task<Product> Handle(CreateProductRequest request, CancellationToken cancellationToken)
        {
            var product = request.product;

            _context.Product.Add(product);
            await _context.SaveChangesAsync();

            return product;
        }
    }
}
