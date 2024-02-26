using AutoMapper;
using MediatR;
using WebApplication1.Core;
using WebApplication1.Data;
using WebApplication1.models;
using WebApplication1.Queries;

namespace WebApplication1.Handlers
{
    public class GetProductHandler : IRequestHandler<GetProductQuery, Product>
    {
        public readonly IUnitOfWork _unitOfWork;
        public readonly IMapper _mapper;
        public GetProductHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Product> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            if (_unitOfWork.Product == null)
            {
                Console.WriteLine("pas de produit");
                return null;
            }
            var product = await _unitOfWork.Product.GetById(request.id);

            if (product == null)
            {
                return null;
            }
            return product;
        }
        
      
    }
}
