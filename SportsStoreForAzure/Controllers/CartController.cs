using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SportsStoreForAzure.Models.Class;
using SportsStoreForAzure.Models.Class.Cart;
using SportsStoreForAzure.Models.Interfaces;
using SportsStoreForAzure.Models.ViewModels;

namespace SportsStoreForAzure.Controllers
{
    public class CartController : Controller
    {
        private IProductRepository Repository;
        private Cart CartService;
        public CartController(IProductRepository Repository, Cart CartService)
        {
            this.Repository = Repository;
            this.CartService = CartService;
        }
        public ViewResult Index(string returnUrl) =>
            View(new CartIndexViewModel
            {
                cart = CartService,
                ReturnUrl = returnUrl
            });
        public RedirectToActionResult AddToCart(int productid, string returnUrl)
        {
            Product product = Repository.Products.
                FirstOrDefault(p => p.ProductId == productid);
            if (!Equals(product, null))
            {
                CartService.AddItem(product, 1);
            }
            return RedirectToAction("Index", new { returnUrl });
        }
        public RedirectToActionResult RemoveFromCart(int productid,
            string returnUrl)
        {
            Product product = Repository.Products
                .FirstOrDefault(p => p.ProductId == productid);
            if (!Equals(product, null))
            {
                CartService.RemoveLine(product);
            }
            return RedirectToAction("Index", new { returnUrl });
        }
        public RedirectToActionResult ClearCart(string returnUrl)
        {
            CartService.Clear();
            return RedirectToAction("Index", new { returnUrl });
        }
    }
}