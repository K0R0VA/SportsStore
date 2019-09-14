using Microsoft.EntityFrameworkCore;
using SportsStoreForAzure.Models.Class;
using SportsStoreForAzure.Models.DbContext;
using SportsStoreForAzure.Models.Interfaces;
using System.Collections.Generic;
using System.Linq;


namespace SportsStoreForAzure.Models.Repository
{
    public class EFOrderRepository : IOrderRepository
    {
        private ApplicationDbContext context;
        public EFOrderRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public IEnumerable<Order> Orders => context.Orders.
            Include(o => o.lines).
            ThenInclude(l => l.Product);

        public void SaveOrder(Order order)
        {
            context.AttachRange(order.lines.Select(l => l.Product));
            if (order.OrderID.Equals(0))
            {
                context.Orders.Add(order);
            }
            context.SaveChanges();
        }
    }
}
