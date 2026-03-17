using WineshopManagerStarterKit.Models;

namespace WineshopManagerStarterKit.Data;

public static class WineTypeSeeder
{
    public static void Seed(AppDbContext context)
    {
        if (context.WineTypes.Any())
        {
            return;
        }

        context.WineTypes.AddRange(
            new WineType { Name = "Red" },
            new WineType { Name = "White" },
            new WineType { Name = "Rosé" },
            new WineType { Name = "Sparkling" },
            new WineType { Name = "Dessert" }
        );

        context.SaveChanges();
    }
}
