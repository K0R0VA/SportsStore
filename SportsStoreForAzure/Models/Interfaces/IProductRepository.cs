using SportsStoreForAzure.Models.Class;
using System.Collections.Generic;

namespace SportsStoreForAzure.Models.Interfaces
{
    public interface IProductRepository
    {
        IEnumerable<Product> Products { get; }
        void SaveProduct(Product productS);
        Product DeleteProduct(int productId);
    }
}
