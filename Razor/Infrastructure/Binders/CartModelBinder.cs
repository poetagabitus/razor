using System.Web.Mvc;
using Razor.Domain;
using Razor.Models;

namespace Razor.Infrastructure.Binders
{
    public class CartModelBinder : IModelBinder
    {
        private const string SessionKey = "Cart";

        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            Cart cart = null;

            var session = controllerContext.HttpContext.Session;

            if (session != null)
                cart = (Cart) session[SessionKey];

            if (cart == null)
            {
                cart = new Cart();
                if (session != null)
                    session[SessionKey] = cart;
            }

            return cart;
        }
    }
}