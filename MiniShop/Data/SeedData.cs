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
            new Product { Name = "Gaming Mouse", Description = "High precision wireless gaming mouse", Price = 49.99m, ImageUrl = "https://m.media-amazon.com/images/I/71vm32j2InL._AC_UF1000,1000_QL80_.jpg" },
            new Product { Name = "USB-C Hub", Description = "Multi-port USB-C hub for laptops", Price = 39.99m, ImageUrl = "https://www.intelec.co.cr/wp-content/uploads/2025/01/HD4001GL.jpg" },

            new Product { Name = "4K Monitor", Description = "27-inch 4K UHD monitor", Price = 299.99m, ImageUrl = "https://cdn.thewirecutter.com/wp-content/media/2025/06/BEST-4K-MONITORS-2x1-1.jpg" },
            new Product { Name = "Laptop Stand", Description = "Adjustable aluminum laptop stand", Price = 29.99m, ImageUrl = "https://m.media-amazon.com/images/I/71gX7yNLE4L._AC_SL1500_.jpg" },
            new Product { Name = "Bluetooth Speaker", Description = "Portable waterproof speaker", Price = 59.99m, ImageUrl = "https://m.media-amazon.com/images/I/718yxonHN8L._AC_SL1500_.jpg" },
            new Product { Name = "Smart Watch", Description = "Fitness tracking smart watch", Price = 149.99m, ImageUrl = "https://images-cdn.ubuy.co.in/653dca4638b3b6351c03b03e-smart-watch-for-android-and-iphone.jpg" },
            new Product { Name = "External SSD 1TB", Description = "High-speed portable SSD storage", Price = 129.99m, ImageUrl = "https://www.techzilla.cr/wp-content/uploads/2025/05/Sin-titulo-1-14-1.jpg" },
            new Product { Name = "Gaming Chair", Description = "Ergonomic gaming chair with lumbar support", Price = 199.99m, ImageUrl = "https://i5.walmartimages.com/seo/GTRACING-GTWD-200-Gaming-Chair-with-Footrest-Height-Adjustable-Office-Swivel-Recliner-Red_aaef885a-fdfe-4dc0-99a7-d01ed62b9cd3.9c135133a687a7623a0e6ae866086107.jpeg" },

            new Product { Name = "Webcam HD", Description = "1080p streaming webcam", Price = 69.99m, ImageUrl = "https://www.intelec.co.cr/wp-content/uploads/2024/10/960-001257-1.jpg" },
            new Product { Name = "Microphone USB", Description = "Professional USB condenser microphone", Price = 89.99m, ImageUrl = "https://m.media-amazon.com/images/I/615Y5Xa5ZDL._AC_SL1500_.jpg" },
            new Product { Name = "Tablet 10\"", Description = "10-inch Android tablet", Price = 179.99m, ImageUrl = "https://m.media-amazon.com/images/I/71Mt4JAZQtL._AC_SL1500_.jpg" },
            new Product { Name = "Wireless Charger", Description = "Fast wireless charging pad", Price = 24.99m, ImageUrl = "https://m.media-amazon.com/images/I/51YD0CM1PnL._AC_SL1500_.jpg" },
            new Product { Name = "Power Bank 20000mAh", Description = "High capacity portable power bank", Price = 34.99m, ImageUrl = "https://www.steren.cr/media/catalog/product/cache/0236bbabe616ddcff749ccbc14f38bf2/image/21920e5b9/power-bank-de-20-000-mah-con-turbo-charge-qc-y-power-delivery-con-2-salidas-usb-y-usb-c.jpg" },

            new Product { Name = "Graphics Card RTX 4060", Description = "High performance gaming graphics card", Price = 399.99m, ImageUrl = "https://m.media-amazon.com/images/I/61q0rsE3ezL._AC_SL1500_.jpg" },
            new Product { Name = "Gaming Laptop", Description = "High performance laptop for gaming", Price = 1199.99m, ImageUrl = "https://m.media-amazon.com/images/I/71sgAr9atBS._AC_SL1500_.jpg" },
            new Product { Name = "Desk Lamp LED", Description = "Adjustable LED desk lamp", Price = 19.99m, ImageUrl = "https://m.media-amazon.com/images/I/7150UxsOtIL._AC_SL1500_.jpg" },
            new Product { Name = "Router WiFi 6", Description = "High-speed WiFi 6 router", Price = 149.99m, ImageUrl = "https://www.intelec.co.cr/wp-content/uploads/2024/11/ARCHER-AX23-1000x1000.webp" },
            new Product { Name = "Noise Cancelling Earbuds", Description = "Wireless earbuds with ANC", Price = 129.99m, ImageUrl = "https://cdn.thewirecutter.com/wp-content/media/2025/05/BEST-NOISE-CANCELLING-HEADPHONES-8255.jpg" }
        };


        context.Products.AddRange(products);
        context.SaveChanges();
    }
}
