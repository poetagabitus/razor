using System.Web.Mvc;
using Razor.Infrastructure.Abstract;
using Razor.Models;

namespace Razor.Controllers
{
    public class AccountController : Controller
    {
        readonly IAuthProvider _authProvider;
        public AccountController(IAuthProvider auth)
        {
            _authProvider = auth;
        }
        public ViewResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (_authProvider.Authenticate(model.UserName, model.Password))
                    return Redirect(returnUrl ?? Url.Action("Index", "Admin"));

                ModelState.AddModelError(string.Empty, "Incorrect username or password");
                return View();
            }

            return View();
        }
    }
}