using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Buisness.Models;
using MediatR;

namespace ApplicationContract.Commands
{
    public class CreateProductCommand : IRequest<Product>
    {
        public CreateProductCommand(Product product)
        {
            this.product = product;
        }

        public Product product { get; }
    }
}
