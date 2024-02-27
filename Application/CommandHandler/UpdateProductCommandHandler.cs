using ApplicationContract.Commands;
using Buisness.Repositories;
using Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.QueryHandler
{
    public class UpdateProductCommandHandler
    {
        private readonly AppDbContext _context;

        public readonly IUnitOfWork _unitOfWork;

        public UpdateProductCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public async Task<bool> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var id = request.Id;
            var product = request.Product;

            if (id != product.Id)
            {
                return false; 
            }
            _unitOfWork.Product.Update(product);

          

            try
            {
                await _unitOfWork.CompleteAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                {
                    return false; 
                }
                else
                {
                    throw; 
                }
            }

            return true; 
        }
        private bool ProductExists(int id)
        {
            return _context.Product.Any(e => e.Id == id);
        }
    }
}
