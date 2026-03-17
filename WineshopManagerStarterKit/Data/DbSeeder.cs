namespace WineshopManagerStarterKit.Data;

public static class DbSeeder
{
    public static void Seed(AppDbContext context)
    {
        WineTypeSeeder.Seed(context);
        WineSeeder.Seed(context);
    }
}
