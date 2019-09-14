using Microsoft.AspNetCore.Mvc;
using SportsStoreForAzure.Models.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace SportsStoreForAzure.Components
{
    public class NavigationMenuViewComponent : ViewComponent
    {
        private IProductRepository Repository;
        public NavigationMenuViewComponent(IProductRepository Repository)
        {
            this.Repository = Repository;
        }
        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCategory = RouteData?.Values["category"];
            return View(Repository.Products.
                       Select(x => x.Category).
                       Distinct().
                       OrderBy(x => x));
        }
    }
}
