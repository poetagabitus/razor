using Razor.Domain.Entities;

namespace Razor.Domain
{
    public interface IOrderProcessor
    {
        void ProcessOrder(Cart cart, ShippingDetails shippingDetails);
    }
}