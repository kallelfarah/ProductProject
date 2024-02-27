using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Buisness.Models;

namespace ApplicationContract.Commands
{
    public class UpdateProductCommand
    {
        public UpdateProductCommand(int id, Product product)
        {
            Id = id;
            Product = product;
        }

        public int Id { get; set; }
        public Product Product { get; set; }
    }
}
