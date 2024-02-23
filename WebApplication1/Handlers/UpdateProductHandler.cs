using MediatR;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Commands;
using WebApplication1.Data;

namespace WebApplication1.Handlers
{
    public class UpdateProductHandler : IRequestHandler<UpdateProductRequest,bool>
    {
        public readonly AppDbContext _context;

        public UpdateProductHandler(AppDbContext context)
        {
            _context = context;
        }


        public async Task<bool> Handle(UpdateProductRequest request, CancellationToken cancellationToken)
        {
            var id = request.Id;
            var product = request.Product;

            if (id != product.Id)
            {
                return false; // IDs don't match, return false indicating failure
            }

            _context.Entry(product).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                {
                    return false; // Product with specified ID not found, return false indicating failure
                }
                else
                {
                    throw; // Other concurrency exceptions, rethrow
                }
            }

            return true; // Update successful, return true
        }
        private bool ProductExists(int id)
        {
            return _context.Product.Any(e => e.Id == id);
        }
    }
}

       

