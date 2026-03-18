namespace WineshopManagerStarterKit.Data;

public static class DbSeeder
{
    public static async Task SeedAsync(AppDbContext context)
    {
        WineTypeSeeder.Seed(context);
        await WineSeeder.SeedAsync(context);
        ClientSeeder.Seed(context);
        SupplierSeeder.Seed(context);
        TicketSeeder.Seed(context);
        OrderSeeder.Seed(context);
    }
}
