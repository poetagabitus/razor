using System;
using System.Linq;
using System.Web.Mvc;
using Razor.Domain;
using Razor.Models;

namespace Razor.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository productRepository;
        private const int PageSize = 4;

        public ProductController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        [HttpGet]
        public ActionResult List(string category, int page = 1)
        {
            var model = new ProductsListViewModel
            {
                Products = productRepository.Products
                    .Where(x => x.Category.Equals(category, StringComparison.CurrentCultureIgnoreCase) || category == null)
                    .OrderBy(p => p.ProductId)
                    .Skip((page - 1)*PageSize)
                    .Take(PageSize),

                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = productRepository.Products.Count(x => x.Category.Equals(category, StringComparison.CurrentCultureIgnoreCase) || category == null)
                },

                CurrentCategory = category
            };

            return View(model);
        }
    }
}