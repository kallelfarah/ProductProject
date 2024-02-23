using AutoMapper;
using MediatR;
using WebApplication1.Data;
using WebApplication1.models;
using WebApplication1.Queries;

namespace WebApplication1.Handlers
{
    public class GetProductHandler : IRequestHandler<GetProductQuery, Product>
    {
        public readonly AppDbContext _context;
        public readonly IMapper _mapper;
        public GetProductHandler(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<Product> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            if (_context.Product == null)
            {
                Console.WriteLine("pas de produit");
                return null;
            }
            var product = await _context.Product.FindAsync(request.id);

            if (product == null)
            {
                return null;
            }
            return product;
        }
        
      
    }
}
