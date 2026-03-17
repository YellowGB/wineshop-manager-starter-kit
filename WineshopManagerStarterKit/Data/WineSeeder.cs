using WineshopManagerStarterKit.Models;

namespace WineshopManagerStarterKit.Data;

public static class WineSeeder
{
    public static void Seed(AppDbContext context)
    {
        if (context.Wines.Any())
        {
            return;
        }

        var red = context.WineTypes.First(t => t.Name == "Red");
        var white = context.WineTypes.First(t => t.Name == "White");
        var sparkling = context.WineTypes.First(t => t.Name == "Sparkling");

        context.Wines.AddRange(
            new Wine
            {
                Name = "Château Margaux",
                WineType = red,
                Quantity = 24,
                AmountBeforeTax = 450.00m,
                TaxRate = 20.00m,
                Threshold = 5
            },
            new Wine
            {
                Name = "Barolo Riserva",
                WineType = red,
                Quantity = 12,
                AmountBeforeTax = 85.00m,
                TaxRate = 20.00m,
                Threshold = 3
            },
            new Wine
            {
                Name = "Chablis Premier Cru",
                WineType = white,
                Quantity = 36,
                AmountBeforeTax = 32.50m,
                TaxRate = 20.00m,
                Threshold = 10
            },
            new Wine
            {
                Name = "Rioja Gran Reserva",
                WineType = red,
                Quantity = 18,
                AmountBeforeTax = 28.00m,
                TaxRate = 20.00m,
                Threshold = 6
            },
            new Wine
            {
                Name = "Champagne Brut Réserve",
                WineType = sparkling,
                Quantity = 48,
                AmountBeforeTax = 38.00m,
                TaxRate = 20.00m,
                Threshold = 12
            }
        );

        context.SaveChanges();
    }
}
