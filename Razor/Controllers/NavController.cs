using System.Linq;
using System.Web.Mvc;
using Razor.Domain;

namespace Razor.Controllers
{
    public class NavController : Controller
    {
        private readonly IProductRepository productRepository;

        public NavController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        [ChildActionOnly]
        public PartialViewResult Menu(string category = null)
        {
            ViewBag.SelectedCategory = category;

            var categories = productRepository.Products
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x);

            return PartialView(categories);
        }
    }
}