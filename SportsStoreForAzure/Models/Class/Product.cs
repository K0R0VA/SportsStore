using System.ComponentModel.DataAnnotations;

namespace SportsStoreForAzure.Models.Class
{
    public class Product
    {
        public int ProductId { get; set; }
        [Required(ErrorMessage = "Please enter a product name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter a description")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Please enter a positive price")]
        [Range(0.01, double.MaxValue)]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "Please specify a category")]
        public string Category { get; set; }
    }
}
