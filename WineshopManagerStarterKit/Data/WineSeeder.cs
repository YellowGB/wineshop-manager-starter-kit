using System.Text.Json;
using WineshopManagerStarterKit.Models;

namespace WineshopManagerStarterKit.Data;

public static class WineSeeder
{
    private static readonly string[] GenericNames =
    {
        "vin rouge", "vin blanc", "vin", "vino", "vino tinto", "vino blanco",
        "wine", "red wine", "white wine", "rosé", "rose"
    };

    public static async Task SeedAsync(AppDbContext context)
    {
        if (context.Wines.Any())
        {
            return;
        }

        var wineTypes = context.WineTypes.ToList();
        var wines = await FetchWinesFromApiAsync(wineTypes);

        if (wines.Count < 10)
        {
            Console.WriteLine($"API returned only {wines.Count} wines. Using fallback data.");
            wines = GetFallbackWines(wineTypes);
        }
        else
        {
            Console.WriteLine($"Fetched {wines.Count} wines from Open Food Facts.");
        }

        context.Wines.AddRange(wines);
        context.SaveChanges();
    }

    private static async Task<List<Wine>> FetchWinesFromApiAsync(List<WineType> wineTypes)
    {
        var wines = new List<Wine>();

        // Map Open Food Facts category slugs to our WineType names
        var categoryMap = new Dictionary<string, string[]>
        {
            { "Red", new[] { "red-wines" } },
            { "White", new[] { "white-wines" } },
            { "Rosé", new[] { "rose-wines" } },
            { "Sparkling", new[] { "sparkling-wines", "champagnes" } },
            { "Dessert", new[] { "dessert-wines", "sweet-wines" } }
        };

        try
        {
            using var http = new HttpClient();
            http.DefaultRequestHeaders.Add("User-Agent", "WineshopManagerSeeder/1.0");
            http.Timeout = TimeSpan.FromSeconds(30);

            foreach (var wineType in wineTypes)
            {
                if (!categoryMap.TryGetValue(wineType.Name, out var slugs))
                {
                    continue;
                }

                foreach (var slug in slugs)
                {
                    // Fetch enough products to filter down to 2 good ones per type
                    var url = $"https://world.openfoodfacts.org/category/{slug}.json?page_size=20&fields=product_name,brands";
                    var response = await http.GetAsync(url);

                    if (!response.IsSuccessStatusCode)
                    {
                        continue;
                    }

                    var json = await response.Content.ReadAsStringAsync();
                    using var doc = JsonDocument.Parse(json);
                    var products = doc.RootElement.GetProperty("products");

                    int added = 0;
                    foreach (var product in products.EnumerateArray())
                    {
                        if (added >= 2)
                        {
                            break;
                        }

                        var name = BuildWineName(product);

                        if (string.IsNullOrWhiteSpace(name))
                        {
                            continue;
                        }

                        // Skip generic names
                        if (GenericNames.Any(g => name.Equals(g, StringComparison.OrdinalIgnoreCase)))
                        {
                            continue;
                        }

                        // Skip duplicates
                        if (wines.Any(w => w.Name.Equals(name, StringComparison.OrdinalIgnoreCase)))
                        {
                            continue;
                        }

                        wines.Add(new Wine
                        {
                            Name = name,
                            WineType = wineType,
                            Quantity = 12 + (wines.Count * 4) % 40,
                            AmountBeforeTax = 15.00m + (wines.Count * 7.50m),
                            TaxRate = 20.00m,
                            Threshold = 3 + (wines.Count % 10)
                        });
                        added++;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Open Food Facts API error: {ex.Message}");
        }

        return wines;
    }

    private static string BuildWineName(JsonElement product)
    {
        var name = "";
        var brand = "";

        if (product.TryGetProperty("product_name", out var nameEl))
        {
            name = nameEl.GetString()?.Trim() ?? "";
        }

        if (product.TryGetProperty("brands", out var brandEl))
        {
            brand = brandEl.GetString()?.Trim() ?? "";
        }

        // Prefer product_name, prepend brand if it adds info
        if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(brand)
            && !name.Contains(brand, StringComparison.OrdinalIgnoreCase))
        {
            return $"{brand} {name}";
        }

        return !string.IsNullOrEmpty(name) ? name : brand;
    }

    private static List<Wine> GetFallbackWines(List<WineType> wineTypes)
    {
        var red = wineTypes.First(t => t.Name == "Red");
        var white = wineTypes.First(t => t.Name == "White");
        var rose = wineTypes.First(t => t.Name == "Rosé");
        var sparkling = wineTypes.First(t => t.Name == "Sparkling");
        var dessert = wineTypes.First(t => t.Name == "Dessert");

        return new List<Wine>
        {
            new Wine { Name = "Château Margaux 2015", WineType = red, Quantity = 24, AmountBeforeTax = 450.00m, TaxRate = 20.00m, Threshold = 5 },
            new Wine { Name = "Barolo Riserva 2016", WineType = red, Quantity = 12, AmountBeforeTax = 85.00m, TaxRate = 20.00m, Threshold = 3 },
            new Wine { Name = "Chablis Premier Cru 2020", WineType = white, Quantity = 36, AmountBeforeTax = 32.50m, TaxRate = 20.00m, Threshold = 10 },
            new Wine { Name = "Sancerre Blanc 2021", WineType = white, Quantity = 28, AmountBeforeTax = 22.00m, TaxRate = 20.00m, Threshold = 8 },
            new Wine { Name = "Côtes de Provence Rosé 2022", WineType = rose, Quantity = 40, AmountBeforeTax = 14.50m, TaxRate = 20.00m, Threshold = 12 },
            new Wine { Name = "Tavel Rosé 2021", WineType = rose, Quantity = 20, AmountBeforeTax = 18.00m, TaxRate = 20.00m, Threshold = 6 },
            new Wine { Name = "Champagne Brut Réserve", WineType = sparkling, Quantity = 48, AmountBeforeTax = 38.00m, TaxRate = 20.00m, Threshold = 12 },
            new Wine { Name = "Crémant d'Alsace Brut", WineType = sparkling, Quantity = 30, AmountBeforeTax = 15.00m, TaxRate = 20.00m, Threshold = 8 },
            new Wine { Name = "Sauternes 2018", WineType = dessert, Quantity = 18, AmountBeforeTax = 55.00m, TaxRate = 20.00m, Threshold = 4 },
            new Wine { Name = "Muscat de Beaumes-de-Venise", WineType = dessert, Quantity = 15, AmountBeforeTax = 19.00m, TaxRate = 20.00m, Threshold = 5 }
        };
    }
}
