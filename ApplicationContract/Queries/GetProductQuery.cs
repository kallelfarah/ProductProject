using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Buisness.Models;

namespace ApplicationContract.Queries
{
    public class GetProductQuery : IRequest<Product>
    {
        public GetProductQuery(int id)
        {
            this.id = id;
        }

        public int id { get; }

    }
}
