using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.models;
using WebApplication1.Queries;

namespace WebApplication1.Handlers
{
    public class GetAllProductsHandler : IRequestHandler<GetAllProductsQuery, IEnumerable<Product>>
    {
        public readonly AppDbContext _context;
        public readonly IMapper _mapper;
        public GetAllProductsHandler(AppDbContext context, IMapper mapper) {
            _context = context;
            _mapper = mapper;
        }
        public async Task<IEnumerable<Product>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await _context.Product.ToListAsync(cancellationToken);

            return _mapper.Map<IEnumerable<Product>>(products);
        }
    }
}
