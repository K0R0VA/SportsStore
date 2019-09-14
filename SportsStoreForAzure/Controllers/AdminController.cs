using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SportsStoreForAzure.Models.Class;
using SportsStoreForAzure.Models.Interfaces;

namespace SportsStoreForAzure.Controllers
{
    public class AdminController : Controller
    {
        private IProductRepository repository;
        public AdminController(IProductRepository repository)
        {
            this.repository = repository;
        }
        public ViewResult Index() => View(repository.Products);
        public ViewResult Edit(int ProductId) => View(repository.Products
            .FirstOrDefault(p => p.ProductId == ProductId));
        [HttpPost]
        public IActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                repository.SaveProduct(product);
                TempData["message"] = $"{product.Name} has been saved";
                return RedirectToAction("Index");
            }
            else
            {
                return View(product);
            }
        }
        public ViewResult Create() =>
            View("Edit", new Product());
        [HttpPost]
        public IActionResult Delete(int productId)
        {
            Product deletedProduct = repository.DeleteProduct(productId);
            if (deletedProduct != null)
            {
                TempData["message"] = $"{deletedProduct.Name} was deleted";
            }
            return RedirectToAction("Index");
        }
    }
}