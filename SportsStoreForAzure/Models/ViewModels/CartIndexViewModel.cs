using SportsStoreForAzure.Models.Class.Cart;

namespace SportsStoreForAzure.Models.ViewModels
{
    public class CartIndexViewModel
    {
        public Cart cart { get; set; }
        public string ReturnUrl { get; set; }
    }
}
