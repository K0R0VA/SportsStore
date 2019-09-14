using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SportsStoreForAzure.Models.Class;
using SportsStoreForAzure.Models.Interfaces;
using SportsStoreForAzure.Models.ViewModels;

namespace SportsStoreForAzure.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductRepository Repository;
        public int PageSize = 4;
        public HomeController(IProductRepository Repository)
        {
            this.Repository = Repository;
        }
        public ViewResult Index(int page = 1) =>
            View(new ProductListViewModel
            {
                Products = Repository.Products.
                   OrderBy(p => p.ProductId).
                   Skip((page - 1) * PageSize).
                   Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItes = Repository.Products.Count()
                }
            });
    }
}