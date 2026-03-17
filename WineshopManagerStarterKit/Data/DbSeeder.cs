namespace WineshopManagerStarterKit.Data;

public static class DbSeeder
{
    public static void Seed(AppDbContext context)
    {
        WineTypeSeeder.Seed(context);
        WineSeeder.Seed(context);
        ClientSeeder.Seed(context);
        SupplierSeeder.Seed(context);
        TicketSeeder.Seed(context);
        OrderSeeder.Seed(context);
    }
}
