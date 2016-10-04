using System.Collections.Generic;
using Razor.Domain;
using Razor.Domain.Entities;

namespace Razor.Models
{
    public class ProductsListViewModel
    {
        public IEnumerable<Product> Products { get; set; }

        public string CurrentCategory { get; set; }

        public PagingInfo PagingInfo { get; set; }
    }
}