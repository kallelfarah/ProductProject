using AutoMapper;
using Buisness.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Buisness.Models;
using ApplicationContract.Queries;

namespace Application.QueryHandler
{
    public class GetAllProductQueryHandler : IRequestHandler<GetAllProductsQuery, IEnumerable<Product>>
    {


        public readonly IUnitOfWork _unitOfWork;
        public readonly IMapper _mapper;
        public GetAllProductQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IEnumerable<Product>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await _unitOfWork.Product.All();

            return _mapper.Map<IEnumerable<Product>>(products);
        }
    }
}
