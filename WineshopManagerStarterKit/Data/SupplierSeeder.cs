using WineshopManagerStarterKit.Models;

namespace WineshopManagerStarterKit.Data;

public static class SupplierSeeder
{
    public static void Seed(AppDbContext context)
    {
        if (context.Suppliers.Any())
        {
            return;
        }

        context.Suppliers.AddRange(
            new Supplier
            {
                Name = "Vignobles de Bordeaux SARL",
                Street = "1 Route des Châteaux",
                PostCode = "33250",
                City = "Pauillac",
                Email = "contact@vignobles-bordeaux.fr",
                Phone = "0556789012",
                Siret = "12345678901234"
            },
            new Supplier
            {
                Name = "Domaine de Bourgogne",
                Street = "24 Route des Grands Crus",
                PostCode = "21200",
                City = "Beaune",
                Email = "commandes@domaine-bourgogne.fr",
                Phone = "0380123456",
                Siret = "23456789012345"
            },
            new Supplier
            {
                Name = "Maison des Vins du Rhône",
                Street = "8 Avenue Pierre de Luxembourg",
                PostCode = "84230",
                City = "Châteauneuf-du-Pape",
                Email = "ventes@vins-rhone.fr",
                Phone = "0490567890",
                Siret = "34567890123456"
            },
            new Supplier
            {
                Name = "Cave Coopérative d'Alsace",
                Street = "15 Route du Vin",
                PostCode = "68340",
                City = "Riquewihr",
                Email = "info@cave-alsace.fr",
                Phone = "0389654321",
                Siret = "45678901234567"
            },
            new Supplier
            {
                Name = "Champagne Prestige Distribution",
                Street = "33 Avenue de Champagne",
                PostCode = "51200",
                City = "Épernay",
                Email = "distribution@champagne-prestige.fr",
                Phone = "0326987654",
                Siret = "56789012345678"
            }
        );

        context.SaveChanges();
    }
}
