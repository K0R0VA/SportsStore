using Microsoft.AspNetCore.Mvc;
using SportsStoreForAzure.Models.Class.Cart;

namespace SportsStoreForAzure.Components
{
    public class CartSummaryViewComponent : ViewComponent
    {
        private Cart Cart;
        public CartSummaryViewComponent(Cart Cart)
        {
            this.Cart = Cart;
        }
        public IViewComponentResult Invoke() =>
            View(Cart);
    }
}
