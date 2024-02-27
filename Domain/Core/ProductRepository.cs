using Buisness.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Buisness.Repositories;
using Data;
using Microsoft.EntityFrameworkCore;

namespace Data.Core
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context) { }

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
