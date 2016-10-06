using System.Linq;
using System.Web.Mvc;
using Razor.Domain;
using Razor.Domain.Entities;

namespace Razor.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private readonly IProductRepository _repository;
        public AdminController(IProductRepository repo)
        {
            _repository = repo;
        }
        public ViewResult Index()
        {
            return View(_repository.Products);
        }

        public ViewResult Edit(int productId)
        {
            var product = _repository.Products.FirstOrDefault(p => p.ProductID == productId);

            return View(product);
        }

        [HttpPost]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid == false)
                return View(product);

            _repository.SaveProduct(product);
            TempData["message"] = $"{product.Name} has been saved";

            return RedirectToAction("Index");
        }

        public ViewResult Create()
        {
            return View("Edit", new Product());
        }

        [HttpPost]
        public ActionResult Delete(int productId)
        {
            var deletedProduct = _repository.DeleteProduct(productId);

            if (deletedProduct != null)
                TempData["message"] = $"{deletedProduct.Name} was deleted";

            return RedirectToAction("Index");
        }
    }
}