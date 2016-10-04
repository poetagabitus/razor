using System.Data.Entity;
using Razor.Domain.Entities;
using Razor.Models;

namespace Razor.Domain
{
    public class EfDbContext : DbContext
    {
         public DbSet<Product> Products { get; set; } 
    }
}