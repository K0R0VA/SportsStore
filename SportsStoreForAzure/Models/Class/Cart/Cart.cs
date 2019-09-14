using System.Collections.Generic;
using System.Linq;

namespace SportsStoreForAzure.Models.Class.Cart
{
    public class Cart
    {
        private List<CartLine> LineCollection =
           new List<CartLine>();
        public virtual void AddItem(Product product, int quantity)
        {
            CartLine line = LineCollection.
                Where(p => p.Product.ProductId == product.ProductId).
                FirstOrDefault();
            if (Equals(line, null))
            {
                LineCollection.Add(
                    new CartLine
                    {
                        Product = product,
                        Quantity = quantity
                    });
            }
            else line.Quantity += quantity;
        }
        public virtual void RemoveLine(Product product) =>
            LineCollection.
            RemoveAll(p => p.Product.ProductId == product.ProductId);
        public virtual decimal ComputeTotalValue() =>
            LineCollection.Sum(e => e.Product.Price * e.Quantity);
        public virtual void Clear() => LineCollection.Clear();
        public virtual IEnumerable<CartLine> lines =>
            LineCollection;
    }
}
