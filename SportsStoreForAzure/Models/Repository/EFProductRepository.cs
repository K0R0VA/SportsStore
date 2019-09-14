using SportsStoreForAzure.Models.Class;
using SportsStoreForAzure.Models.DbContext;
using SportsStoreForAzure.Models.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace SportsStoreForAzure.Models.Repository
{
    public class EFProductRepository : IProductRepository
    {
        public EFProductRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        private ApplicationDbContext context;
        public IEnumerable<Product> Products => context.Products;

        public void SaveProduct(Product product)
        {
            if (product.ProductId.Equals(0))
            {
                context.Products.Add(product);
            }
            else
            {
                Product dbEntry = context.Products.
                    FirstOrDefault(p => p.ProductId == product.ProductId);
                if (dbEntry != null)
                {
                    dbEntry.Name = product.Name;
                    dbEntry.Description = product.Description;
                    dbEntry.Price = product.Price;
                    dbEntry.Category = product.Category;
                }
            }
            context.SaveChanges();
        }

        public Product DeleteProduct(int productId)
        {
            Product dbEntry = context.Products
                 .FirstOrDefault(p => p.ProductId == productId);
            if (dbEntry != null)
            {
                context.Products.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}
