using MiniShop.Models;

namespace MiniShop.Data;

public static class SeedData
{
    public static void Initialize(AppDbContext context)
    {
        if (context.Products.Any())
            return;

        var products = new List<Product>
        {
            new Product
            {
                Name = "Wireless Headphones",
                Description = "Noise cancelling over-ear headphones",
                Price = 99.99m,
                ImageUrl = "/images/products/headphones.jpg"
            },
            new Product
            {
                Name = "Mechanical Keyboard",
                Description = "RGB mechanical keyboard with blue switches",
                Price = 79.99m,
                ImageUrl = "/images/products/keyboard.jpg"
            },
            new Product
            {
                Name = "Gaming Mouse",
                Description = "High precision wireless gaming mouse",
                Price = 49.99m,
                ImageUrl = "/images/products/mouse.jpg"
            },
            new Product
            {
                Name = "USB-C Hub",
                Description = "Multi-port USB-C hub for laptops",
                Price = 39.99m,
                ImageUrl = "/images/products/hub.jpg"
            }
        };

        context.Products.AddRange(products);
        context.SaveChanges();
    }
}
