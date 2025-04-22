namespace MVC_Project.Data
{
    public static class DbInitializer
    {
        public static void Initialize(BakeryDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.Products.Any())
            {
                return; // DB has been seeded
            }

            var products = new Product[]
            {
            new Product{Name="Chocolate Cake", Description="Rich chocolate cake", Price=25.99m, StockQuantity=10, Category="Cake"},
            new Product{Name="Croissant", Description="Buttery French croissant", Price=3.50m, StockQuantity=30, Category="Pastry"},
                // Add more products
            };

            context.Products.AddRange(products);
            context.SaveChanges();
        }
    }
}
