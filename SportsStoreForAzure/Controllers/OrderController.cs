using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SportsStoreForAzure.Models.Class;
using SportsStoreForAzure.Models.Class.Cart;
using SportsStoreForAzure.Models.Interfaces;

namespace SportsStoreForAzure.Controllers
{
    public class OrderController : Controller
    {
        private IOrderRepository repository;
        private Cart cart;
        public OrderController(IOrderRepository repository, Cart cart)
        {
            this.repository = repository;
            this.cart = cart;
        }
        [Authorize]
        public ViewResult List() => View(repository.Orders.Where(o => !o.Snipped));
        [HttpPost]
        [Authorize]
        public IActionResult MarkSnipped(int orderID)
        {
            Order order = repository.Orders
                .FirstOrDefault(o => o.OrderID == orderID);
            if (!order.Equals(null))
            {
                order.Snipped = true;
                repository.SaveOrder(order);
            }
            return RedirectToAction(nameof(List));
        }
        public ViewResult CheckOut() => View(new Order());
        [HttpPost]
        public IActionResult CheckOut(Order order)
        {
            if (cart.lines.Count().Equals(0))
            {
                ModelState.AddModelError("", "Sorry your cart is empty");
            }
            if (ModelState.IsValid)
            {
                order.lines = cart.lines.ToArray();
                repository.SaveOrder(order);
                return RedirectToAction(nameof(Completed));
            }
            else return View(order);
        }
        public ViewResult Completed()
        {
            cart.Clear();
            return View();
        }
    }
}