using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using SportsStoreForAzure.Infrastructure;
using System;

namespace SportsStoreForAzure.Models.Class.Cart
{
    public class SessionCart : Cart
    {
        public static Cart GetCart(IServiceProvider services)
        {
            Session = services.
                GetRequiredService<IHttpContextAccessor>()?.
                HttpContext.Session;
            SessionCart cart = Session?.GetJson<SessionCart>("Cart")
                ?? new SessionCart();
            return cart;
        }
        [JsonIgnore]
        public static ISession Session { get; set; }
        public override void AddItem(Product product, int quantity)
        {
            base.AddItem(product, quantity);
            Session.SetJson("Cart", this);
        }
        public override void RemoveLine(Product product)
        {
            base.RemoveLine(product);
            Session.SetJson("Cart", this);
        }
        public override void Clear()
        {
            base.Clear();
            Session.Remove("Cart");
        }
    }
}
