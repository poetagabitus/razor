using Razor.Domain;

namespace Razor.Models
{
    public class CartIndexViewModel
    {
        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; }
    }
}