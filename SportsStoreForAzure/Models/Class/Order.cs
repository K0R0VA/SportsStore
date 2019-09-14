using Microsoft.AspNetCore.Mvc.ModelBinding;
using SportsStoreForAzure.Models.Class.Cart;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace SportsStoreForAzure.Models.Class
{
    public class Order
    {
        [BindNever]
        public int OrderID { get; set; }
        [BindNever]
        public ICollection<CartLine> lines { get; set; }
        [BindNever]
        public bool Snipped { get; set; }
        [Required(ErrorMessage = "Please enter your name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter the first adress line")]
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string Line3 { get; set; }
        [Required(ErrorMessage = "Please enter your city")]
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        [Required(ErrorMessage = "Please enter your country")]
        public string Country { get; set; }
        public bool? GiftWrap { get; set; }
    }
}
