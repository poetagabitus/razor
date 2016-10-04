using Razor.Domain.Entities;

namespace Razor.Domain
{
    public class CartLine
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}