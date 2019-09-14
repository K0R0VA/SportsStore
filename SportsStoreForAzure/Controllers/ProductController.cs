using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SportsStoreForAzure.Models.Class;
using SportsStoreForAzure.Models.Interfaces;
using SportsStoreForAzure.Models.ViewModels;

namespace SportsStoreForAzure.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository Repository;
        public int PageSize = 4;
        public ProductController(IProductRepository Repository)
        {
            this.Repository = Repository;
        }

        public ViewResult Index(string category, int page = 1) =>
            View(new ProductListViewModel
            {
                Products = Repository.Products.
                   Where(p => p.Category == null || p.Category == category).
                   OrderBy(p => p.ProductId).
                   Skip((page - 1) * PageSize).
                   Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItes = Equals(category, null) ?
                       Repository.Products.Count() :
                       Repository.Products.
                            Where(p => p.Category == category).
                            Count()
                },
                CurrentCategory = category
            });
    }
}