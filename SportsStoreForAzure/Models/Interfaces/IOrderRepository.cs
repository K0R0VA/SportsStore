using SportsStoreForAzure.Models.Class;
using System.Collections.Generic;

namespace SportsStoreForAzure.Models.Interfaces
{
    public interface IOrderRepository
    {
        IEnumerable<Order> Orders { get; }
        void SaveOrder(Order order);
    }
}
