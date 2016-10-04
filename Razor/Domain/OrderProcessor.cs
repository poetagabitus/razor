using Razor.Domain.Entities;

namespace Razor.Domain
{
    class OrderProcessor : IOrderProcessor
    {
        public void ProcessOrder(Cart cart, ShippingDetails shippingDetails)
        {
            return;
        }
    }
}