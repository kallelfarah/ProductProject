using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.models;

namespace WebApplication1.Core.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext context, ILogger logger) : base(context, logger) { }

        public override async Task<IEnumerable<Product>> All()
        {
            try
            {
                return await _dbSet.Where(x => x.Id < 100).ToListAsync();
            }
            catch (Exception e)
            {
                _logger.LogError(e, "An error occurred while retrieving products.");
                throw; 
            }
        }
    }
}
