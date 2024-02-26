using Microsoft.EntityFrameworkCore;
using WebApplication1.Core;
using WebApplication1.Core.Repositories;

namespace WebApplication1.Data
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly AppDbContext _context;
     //   protected readonly ILogger _logger;

       public IProductRepository Product { get; private set; }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();  }

        public void Dispose()
        {
            _context.Dispose();
        }


        public UnitOfWork(AppDbContext context )
        {
            _context = context;
            Product = new ProductRepository(_context);
        }
       



    }
}
