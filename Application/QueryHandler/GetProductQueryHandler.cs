using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Buisness.Models;
using Buisness.Repositories;

using ApplicationContract.Queries;
namespace Application.QueryHandler
{
    public class GetProductQueryHandler : IRequestHandler<GetProductQuery, Product>
    {
        public readonly IUnitOfWork _unitOfWork;
        public readonly IMapper _mapper;
        public GetProductQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
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
