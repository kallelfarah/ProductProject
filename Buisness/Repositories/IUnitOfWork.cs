using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Repositories
{
    public interface IUnitOfWork
    {
       IProductRepository Product { get; }
        Task CompleteAsync();
    }
}
