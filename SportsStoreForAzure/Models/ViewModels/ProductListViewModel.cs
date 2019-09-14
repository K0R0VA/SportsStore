using SportsStoreForAzure.Models.Class;
using System.Collections.Generic;

namespace SportsStoreForAzure.Models.ViewModels
{
    public class ProductListViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string CurrentCategory { get; set; }
    }
}
