using Microsoft.EntityFrameworkCore;
using Web.Spa.Api.Domain;

namespace Web.Spa.Api.Infrastructure;

public static class DataSeeder
{
    public static async Task SeedAsync(AppDbContext db)
    {
        if (await db.Products.AnyAsync())
            return;

        var products = new List<Product>
        {
            new()
            {
                Title = "Classic Backpack",
                Description = "Durable everyday backpack with padded straps.",
                Price = 49.90m,
                Image = "https://picsum.photos/seed/p1/600/600",
            },
            new()
            {
                Title = "Wireless Headphones",
                Description = "Over-ear Bluetooth headphones with mic.",
                Price = 89.00m,
                Image = "https://picsum.photos/seed/p2/600/600",
            },
            new()
            {
                Title = "Smart Watch",
                Description = "Fitness tracking, heart-rate, waterproof.",
                Price = 119.99m,
                Image = "https://picsum.photos/seed/p3/600/600",
            },
            new()
            {
                Title = "Mechanical Keyboard",
                Description = "Hot-swappable switches, RGB backlight.",
                Price = 79.50m,
                Image = "https://picsum.photos/seed/p4/600/600",
            },
            new()
            {
                Title = "Gaming Mouse",
                Description = "Ergonomic, high DPI sensor.",
                Price = 39.99m,
                Image = "https://picsum.photos/seed/p5/600/600",
            },
            new()
            {
                Title = "USB-C Hub",
                Description = "7-in-1 HDMI, USB 3.0, SD reader.",
                Price = 34.95m,
                Image = "https://picsum.photos/seed/p6/600/600",
            },
            new()
            {
                Title = "4K Monitor",
                Description = "27-inch IPS 4K UHD display.",
                Price = 299.00m,
                Image = "https://picsum.photos/seed/p7/600/600",
            },
            new()
            {
                Title = "Portable SSD",
                Description = "1TB NVMe USB-C portable drive.",
                Price = 129.00m,
                Image = "https://picsum.photos/seed/p8/600/600",
            },
            new()
            {
                Title = "Action Camera",
                Description = "4K60, stabilization, waterproof case.",
                Price = 199.00m,
                Image = "https://picsum.photos/seed/p9/600/600",
            },
            new()
            {
                Title = "Desk Lamp",
                Description = "LED lamp with color temperature modes.",
                Price = 24.99m,
                Image = "https://picsum.photos/seed/p10/600/600",
            },
            new()
            {
                Title = "Coffee Mug",
                Description = "Thermal stainless steel travel mug.",
                Price = 15.99m,
                Image = "https://picsum.photos/seed/p11/600/600",
            },
            new()
            {
                Title = "Notebook",
                Description = "A5 dotted notebook for notes.",
                Price = 8.49m,
                Image = "https://picsum.photos/seed/p12/600/600",
            },
        };

        db.Products.AddRange(products);
        await db.SaveChangesAsync();
    }
}
