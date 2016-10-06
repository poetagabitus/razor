using System.Collections.Generic;
using Razor.Domain.Entities;

namespace Razor.Domain
{
    public interface IProductRepository
    {
        IEnumerable<Product> Products { get; }

        void SaveProduct(Product product);

        Product DeleteProduct(int productId);
    }
}