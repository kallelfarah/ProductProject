using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.models;

namespace WebApplication1.Core.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context ) { }

        public override async Task<IEnumerable<Product>> All()
        {
            try
            {
                return await _dbSet.Where(x => x.Id < 100).ToListAsync();
            }
            catch (Exception e)
            {
              
                throw; 
            }
        }
    }
}
