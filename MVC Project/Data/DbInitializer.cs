using UserRoles.Data;

namespace MVC_Project.Data
{
    public static class DbInitializer
    {
        public static void Initialize(BakeryDbContext context)
        {
            if (context.Products.Any()) return;

            var products = new List<Product>
        {
            new Product {
                Name = "Apple Pie",
                Description = "Homemade with Granny Smith apples",
                Price = 27.99m,
                StockQuantity = 20,
                ImageUrl = "/images/apple-pie.jpg",
                Category = "Pies"
            },
            new Product {
                Name = "Croissant",
                Description = "Flaky French-style pastry",
                Price = 15.99m,
                StockQuantity = 40,
                ImageUrl = "/images/croissant.jpg",
                Category = "Pastries"
            }
        };

            context.Products.AddRange(products);
            context.SaveChanges();
        }
    }
}
