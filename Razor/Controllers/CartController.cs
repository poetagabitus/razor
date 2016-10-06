using System.Linq;
using System.Web.Mvc;
using Razor.Domain;
using Razor.Domain.Entities;
using Razor.Models;

namespace Razor.Controllers
{
    public class CartController : Controller
    {
        private readonly IProductRepository _repository;
        private readonly IOrderProcessor _orderProcessor;

        public CartController(IProductRepository repo, IOrderProcessor orderProcessor)
        {
            _repository = repo;
            _orderProcessor = orderProcessor;
        }

        [HttpGet]
        public ActionResult Index(Cart cart, string returnurl)
        {
            return View(new CartIndexViewModel
            {
                Cart = cart,
                ReturnUrl = returnurl
            });
        }

        [HttpPost]
        public RedirectToRouteResult AddToCart(Cart cart, int productId, string returnUrl)
        {
            var product = _repository.Products.SingleOrDefault(p => p.ProductID == productId);

            if (product != null)
                cart.AddItem(product, 1);
            
            return RedirectToAction("Index", new {returnUrl});
        }

        [HttpPost]
        public RedirectToRouteResult RemoveFromCart(Cart cart, int productId, string returnUrl)
        {
            var product = _repository.Products.SingleOrDefault(p => p.ProductID == productId);

            if (product != null)
                cart.RemoveLine(product);

            return RedirectToAction("Index", new {returnUrl});
        }

        [ChildActionOnly]
        public PartialViewResult Summary(Cart cart)
        {
            return PartialView(cart);
        }

        [HttpGet]
        public ActionResult Checkout()
        {
            return View(new ShippingDetails());
        }

        [HttpPost]
        public ViewResult Checkout(Cart cart, ShippingDetails shippingDetails)
        {
            if (cart.Lines.Any() == false)
                ModelState.AddModelError(string.Empty, "Sorry, your cart is empty!");

            if (ModelState.IsValid == false) 
                return View(shippingDetails);

            _orderProcessor.ProcessOrder(cart, shippingDetails);
            cart.Clear();

            return View("Completed");
        }
    }
}