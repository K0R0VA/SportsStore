using SportsStoreForAzure.Models.Class;
using SportsStoreForAzure.Models.DbContext;
using System.Linq;

namespace SportsStoreForAzure.Models.Seed
{
    public class SeedData
    {
        public static void EnsurePopulated(ApplicationDbContext context)
        {
            if (!context.Products.Any())
            {
                context.Products.AddRange(
                    new Product { Name = "Kayak", Description = "А boat for one person", Category = "Watersports", Price = 275M },
                    new Product { Name = "Lifejacket", Description = "Protective and fashionable", Category = "Watersports", Price = 48.95m },
                    new Product { Name = "Soccer Ball", Description = "FIFA-approved size and weight", Category = "Soccer", Price = 19.50m },
                    new Product { Name = "Corner Flags", Description = "Give your playing field а professional touch", Category = "Soccer", Price = 34.95m },
                    new Product { Name = "Stadium", Description = "Flat-packed 35,000- seat stadi um ", Category = "Soccer", Price = 79500M },
                    new Product { Name = "Thinking Сар ", Description = "Improve brain efficiency Ьу 75%", Category = "Chess", Price = 16M },
                    new Product { Name = "Unsteady Chair", Description = "Secretly give your opponent а disadvantage", Category = "Chess", Price = 29.95m },
                    new Product { Name = "Human Chess Board", Description = "А fun game for the family", Category = "Chess ", Price = 75M },
                    new Product { Name = "Bling-Bling King", Description = "Gold-plated, diamond-studded King", Category = "Chess", Price = 1200M });
                context.SaveChanges();
            }
        }
    }
}
