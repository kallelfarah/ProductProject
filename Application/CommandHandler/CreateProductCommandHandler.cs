using ApplicationContract.Commands;
using AutoMapper;
using Buisness.Models;
using Buisness.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.QueryHandler
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Product>
    {
        public readonly IUnitOfWork _unitOfWork;
        public readonly IMapper _mapper;

        public CreateProductCommandHandler(IUnitOfWork unitOfWork, IMapper _mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = _mapper;
        }

        public async Task<Product> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = request.product;

            _unitOfWork.Product.Add(product);
            await _unitOfWork.CompleteAsync();

            return product;
        }
    }
}