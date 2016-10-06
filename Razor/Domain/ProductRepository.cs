using System.Collections.Generic;
using Razor.Domain.Entities;

namespace Razor.Domain
{
    public class ProductRepository : IProductRepository
    {
        private readonly EfDbContext _context = new EfDbContext();

        public IEnumerable<Product> Products => _context.Products;

        public void SaveProduct(Product product)
        {
            if (product.ProductID == 0)
                _context.Products.Add(product);

            else
            {
                var dbEntry = _context.Products.Find(product.ProductID);
                if (dbEntry != null)
                {
                    dbEntry.Name = product.Name;
                    dbEntry.Description = product.Description;
                    dbEntry.Price = product.Price;
                    dbEntry.Category = product.Category;
                }
            }

            _context.SaveChanges();
        }

        public Product DeleteProduct(int productId)
        {
            var dbEntry = _context.Products.Find(productId);

            if (dbEntry == null)
                return null;

            _context.Products.Remove(dbEntry);
            _context.SaveChanges();

            return dbEntry;
        }
    }
}