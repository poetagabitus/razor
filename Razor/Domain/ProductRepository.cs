using System.Collections.Generic;
using Razor.Domain.Entities;
using Razor.Models;

namespace Razor.Domain
{
    public class ProductRepository : IProductRepository
    {
        private readonly EfDbContext context = new EfDbContext();

        public IEnumerable<Product> Products
        {
            get { return context.Products; }
        }
    }
}