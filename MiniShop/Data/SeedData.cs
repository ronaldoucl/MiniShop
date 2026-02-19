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
            new Product { Name = "Wireless Headphones", Description = "Noise cancelling over-ear headphones", Price = 99.99m, ImageUrl = "https://m.media-amazon.com/images/I/61RahTQtAqL._AC_UF894,1000_QL80_.jpg" },
            new Product { Name = "Mechanical Keyboard", Description = "RGB mechanical keyboard with blue switches", Price = 79.99m, ImageUrl = "https://cdn.thewirecutter.com/wp-content/media/2025/12/BEST-MECHANICAL-KEYBOARDS-2048px-EVOWORKS-80-926.jpg" },
            new Product { Name = "Gaming Mouse", Description = "High precision wireless gaming mouse", Price = 49.99m, ImageUrl = "/images/products/mouse.jpg" },
            new Product { Name = "USB-C Hub", Description = "Multi-port USB-C hub for laptops", Price = 39.99m, ImageUrl = "/images/products/hub.jpg" },

            new Product { Name = "4K Monitor", Description = "27-inch 4K UHD monitor", Price = 299.99m, ImageUrl = "/images/products/monitor.jpg" },
            new Product { Name = "Laptop Stand", Description = "Adjustable aluminum laptop stand", Price = 29.99m, ImageUrl = "/images/products/laptop-stand.jpg" },
            new Product { Name = "Bluetooth Speaker", Description = "Portable waterproof speaker", Price = 59.99m, ImageUrl = "/images/products/speaker.jpg" },
            new Product { Name = "Smart Watch", Description = "Fitness tracking smart watch", Price = 149.99m, ImageUrl = "/images/products/smartwatch.jpg" },
            new Product { Name = "External SSD 1TB", Description = "High-speed portable SSD storage", Price = 129.99m, ImageUrl = "/images/products/ssd.jpg" },
            new Product { Name = "Gaming Chair", Description = "Ergonomic gaming chair with lumbar support", Price = 199.99m, ImageUrl = "/images/products/chair.jpg" },

            new Product { Name = "Webcam HD", Description = "1080p streaming webcam", Price = 69.99m, ImageUrl = "/images/products/webcam.jpg" },
            new Product { Name = "Microphone USB", Description = "Professional USB condenser microphone", Price = 89.99m, ImageUrl = "/images/products/microphone.jpg" },
            new Product { Name = "Tablet 10\"", Description = "10-inch Android tablet", Price = 179.99m, ImageUrl = "/images/products/tablet.jpg" },
            new Product { Name = "Wireless Charger", Description = "Fast wireless charging pad", Price = 24.99m, ImageUrl = "/images/products/charger.jpg" },
            new Product { Name = "Power Bank 20000mAh", Description = "High capacity portable power bank", Price = 34.99m, ImageUrl = "/images/products/powerbank.jpg" },

            new Product { Name = "Graphics Card RTX 4060", Description = "High performance gaming graphics card", Price = 399.99m, ImageUrl = "/images/products/gpu.jpg" },
            new Product { Name = "Gaming Laptop", Description = "High performance laptop for gaming", Price = 1199.99m, ImageUrl = "/images/products/gaming-laptop.jpg" },
            new Product { Name = "Desk Lamp LED", Description = "Adjustable LED desk lamp", Price = 19.99m, ImageUrl = "/images/products/lamp.jpg" },
            new Product { Name = "Router WiFi 6", Description = "High-speed WiFi 6 router", Price = 149.99m, ImageUrl = "/images/products/router.jpg" },
            new Product { Name = "Noise Cancelling Earbuds", Description = "Wireless earbuds with ANC", Price = 129.99m, ImageUrl = "/images/products/earbuds.jpg" }
        };


        context.Products.AddRange(products);
        context.SaveChanges();
    }
}
