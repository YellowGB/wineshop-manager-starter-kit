using WineshopManagerStarterKit.Models;

namespace WineshopManagerStarterKit.Data;

public static class OrderSeeder
{
    public static void Seed(AppDbContext context)
    {
        if (context.Orders.Any())
        {
            return;
        }

        var suppliers = context.Suppliers.ToList();
        var wines = context.Wines.ToList();

        var orders = new List<Order>();

        // Order 1 — Bordeaux supplier, single wine, 24 bottles (2 cases)
        orders.Add(new Order
        {
            SupplierId = suppliers[0].Id,
            OrderDate = new DateTime(2025, 8, 20),
            DeliveryDate = new DateTime(2025, 9, 3),
            Street = "10 Rue du Commerce",
            PostCode = "75015",
            City = "Paris",
            Validated = true,
            Delivered = true,
            OrderWines = new List<OrderWine>
            {
                new OrderWine { WineId = wines[0].Id, Quantity = 24 }
            }
        });

        // Order 2 — Bourgogne supplier, 2 different wines, total 36
        orders.Add(new Order
        {
            SupplierId = suppliers[1].Id,
            OrderDate = new DateTime(2025, 9, 1),
            DeliveryDate = new DateTime(2025, 9, 15),
            Street = "10 Rue du Commerce",
            PostCode = "75015",
            City = "Paris",
            Validated = true,
            Delivered = true,
            OrderWines = new List<OrderWine>
            {
                new OrderWine { WineId = wines[1].Id, Quantity = 12 },
                new OrderWine { WineId = wines[2].Id, Quantity = 24 }
            }
        });

        // Order 3 — Rhône supplier, single wine, 18 bottles
        orders.Add(new Order
        {
            SupplierId = suppliers[2].Id,
            OrderDate = new DateTime(2025, 9, 10),
            DeliveryDate = new DateTime(2025, 9, 24),
            Street = "10 Rue du Commerce",
            PostCode = "75015",
            City = "Paris",
            Validated = true,
            Delivered = true,
            OrderWines = new List<OrderWine>
            {
                new OrderWine { WineId = wines[3].Id, Quantity = 18 }
            }
        });

        // Order 4 — Champagne supplier, single wine, 48 bottles (big stock)
        orders.Add(new Order
        {
            SupplierId = suppliers[4].Id,
            OrderDate = new DateTime(2025, 9, 25),
            DeliveryDate = new DateTime(2025, 10, 10),
            Street = "10 Rue du Commerce",
            PostCode = "75015",
            City = "Paris",
            Validated = true,
            Delivered = true,
            OrderWines = new List<OrderWine>
            {
                new OrderWine { WineId = wines[4].Id, Quantity = 48 }
            }
        });

        // Order 5 — Bordeaux supplier, 3 wines, total 42
        orders.Add(new Order
        {
            SupplierId = suppliers[0].Id,
            OrderDate = new DateTime(2025, 10, 15),
            DeliveryDate = new DateTime(2025, 10, 30),
            Street = "10 Rue du Commerce",
            PostCode = "75015",
            City = "Paris",
            Validated = true,
            Delivered = true,
            OrderWines = new List<OrderWine>
            {
                new OrderWine { WineId = wines[0].Id, Quantity = 18 },
                new OrderWine { WineId = wines[1].Id, Quantity = 12 },
                new OrderWine { WineId = wines[3].Id, Quantity = 12 }
            }
        });

        // Order 6 — Alsace supplier, single wine restock, 30 bottles
        orders.Add(new Order
        {
            SupplierId = suppliers[3].Id,
            OrderDate = new DateTime(2025, 11, 1),
            DeliveryDate = new DateTime(2025, 11, 14),
            Street = "10 Rue du Commerce",
            PostCode = "75015",
            City = "Paris",
            Validated = true,
            Delivered = true,
            OrderWines = new List<OrderWine>
            {
                new OrderWine { WineId = wines[2].Id, Quantity = 30 }
            }
        });

        // Order 7 — Champagne supplier, pre-holiday stock, 2 wines, total 40
        orders.Add(new Order
        {
            SupplierId = suppliers[4].Id,
            OrderDate = new DateTime(2025, 11, 20),
            DeliveryDate = new DateTime(2025, 12, 5),
            Street = "10 Rue du Commerce",
            PostCode = "75015",
            City = "Paris",
            Validated = true,
            Delivered = true,
            OrderWines = new List<OrderWine>
            {
                new OrderWine { WineId = wines[4].Id, Quantity = 30 },
                new OrderWine { WineId = wines[2].Id, Quantity = 10 }
            }
        });

        // Order 8 — Bordeaux supplier, single wine, 12 bottles
        orders.Add(new Order
        {
            SupplierId = suppliers[0].Id,
            OrderDate = new DateTime(2025, 12, 10),
            DeliveryDate = new DateTime(2025, 12, 22),
            Street = "10 Rue du Commerce",
            PostCode = "75015",
            City = "Paris",
            Validated = true,
            Delivered = true,
            OrderWines = new List<OrderWine>
            {
                new OrderWine { WineId = wines[0].Id, Quantity = 12 }
            }
        });

        // Order 9 — Bourgogne supplier, 2 wines, total 24
        orders.Add(new Order
        {
            SupplierId = suppliers[1].Id,
            OrderDate = new DateTime(2026, 1, 10),
            DeliveryDate = new DateTime(2026, 1, 25),
            Street = "10 Rue du Commerce",
            PostCode = "75015",
            City = "Paris",
            Validated = true,
            Delivered = true,
            OrderWines = new List<OrderWine>
            {
                new OrderWine { WineId = wines[1].Id, Quantity = 12 },
                new OrderWine { WineId = wines[3].Id, Quantity = 12 }
            }
        });

        // Order 10 — Rhône supplier, single wine, 18 bottles
        orders.Add(new Order
        {
            SupplierId = suppliers[2].Id,
            OrderDate = new DateTime(2026, 2, 5),
            DeliveryDate = new DateTime(2026, 2, 20),
            Street = "10 Rue du Commerce",
            PostCode = "75015",
            City = "Paris",
            Validated = true,
            Delivered = false,
            OrderWines = new List<OrderWine>
            {
                new OrderWine { WineId = wines[3].Id, Quantity = 18 }
            }
        });

        // Order 11 — Champagne supplier, spring restock, 3 wines, total 50
        orders.Add(new Order
        {
            SupplierId = suppliers[4].Id,
            OrderDate = new DateTime(2026, 2, 25),
            DeliveryDate = new DateTime(2026, 3, 10),
            Street = "10 Rue du Commerce",
            PostCode = "75015",
            City = "Paris",
            Validated = true,
            Delivered = false,
            OrderWines = new List<OrderWine>
            {
                new OrderWine { WineId = wines[4].Id, Quantity = 24 },
                new OrderWine { WineId = wines[0].Id, Quantity = 12 },
                new OrderWine { WineId = wines[2].Id, Quantity = 14 }
            }
        });

        // Order 12 — Alsace supplier, pending order, not yet validated
        orders.Add(new Order
        {
            SupplierId = suppliers[3].Id,
            OrderDate = new DateTime(2026, 3, 12),
            DeliveryDate = new DateTime(2026, 3, 28),
            Street = "10 Rue du Commerce",
            PostCode = "75015",
            City = "Paris",
            Validated = false,
            Delivered = false,
            OrderWines = new List<OrderWine>
            {
                new OrderWine { WineId = wines[2].Id, Quantity = 24 },
                new OrderWine { WineId = wines[1].Id, Quantity = 12 }
            }
        });

        context.Orders.AddRange(orders);
        context.SaveChanges();
    }
}
