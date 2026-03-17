using WineshopManagerStarterKit.Models;

namespace WineshopManagerStarterKit.Data;

public static class ClientSeeder
{
    public static void Seed(AppDbContext context)
    {
        if (context.Clients.Any())
        {
            return;
        }

        context.Clients.AddRange(
            new Client { Name = "Alice Dupont", Email = "alice.dupont@email.fr", Street = "12 Rue de la Paix", PostCode = "75002", City = "Paris", Phone = "0612345678" },
            new Client { Name = "Bernard Martin", Email = "b.martin@orange.fr", Street = "45 Avenue Jean Jaurès", PostCode = "69007", City = "Lyon", Phone = "0623456789" },
            new Client { Name = "Claire Moreau", Email = "claire.moreau@gmail.com", Street = "8 Boulevard Gambetta", PostCode = "33000", City = "Bordeaux", Phone = "0634567890" },
            new Client { Name = "David Lefebvre", Email = "d.lefebvre@free.fr", Street = "22 Rue du Faubourg", PostCode = "31000", City = "Toulouse", Phone = "0645678901" },
            new Client { Name = "Émilie Bernard", Email = "emilie.bernard@yahoo.fr", Street = "3 Place Bellecour", PostCode = "69002", City = "Lyon", Phone = "0656789012" },
            new Client { Name = "François Petit", Email = "f.petit@laposte.net", Street = "17 Rue de Rivoli", PostCode = "75004", City = "Paris", Phone = "0667890123" },
            new Client { Name = "Gabrielle Rousseau", Email = "g.rousseau@gmail.com", Street = "56 Cours Mirabeau", PostCode = "13100", City = "Aix-en-Provence", Phone = "0678901234" },
            new Client { Name = "Hugo Durand", Email = "hugo.durand@email.fr", Street = "9 Rue de la République", PostCode = "13001", City = "Marseille", Phone = "0689012345" },
            new Client { Name = "Isabelle Garcia", Email = "i.garcia@orange.fr", Street = "34 Avenue Foch", PostCode = "67000", City = "Strasbourg", Phone = "0690123456" },
            new Client { Name = "Julien Robert", Email = "j.robert@free.fr", Street = "7 Quai des Chartrons", PostCode = "33000", City = "Bordeaux", Phone = "0601234567" },
            new Client { Name = "Karine Thomas", Email = "k.thomas@gmail.com", Street = "28 Rue Nationale", PostCode = "59000", City = "Lille", Phone = "0712345678" },
            new Client { Name = "Laurent Simon", Email = "l.simon@yahoo.fr", Street = "15 Place du Capitole", PostCode = "31000", City = "Toulouse", Phone = "0723456789" },
            new Client { Name = "Marie Laurent", Email = "m.laurent@laposte.net", Street = "42 Rue Saint-Honoré", PostCode = "75001", City = "Paris", Phone = "0734567890" },
            new Client { Name = "Nicolas Michel", Email = "n.michel@email.fr", Street = "11 Boulevard Haussmann", PostCode = "75009", City = "Paris", Phone = "0745678901" },
            new Client { Name = "Ophélie Leroy", Email = "o.leroy@orange.fr", Street = "6 Rue de la Liberté", PostCode = "21000", City = "Dijon", Phone = "0756789012" },
            new Client { Name = "Pierre Roux", Email = "p.roux@gmail.com", Street = "19 Avenue de Saxe", PostCode = "69006", City = "Lyon", Phone = "0767890123" },
            new Client { Name = "Quentin David", Email = "q.david@free.fr", Street = "25 Rue du Port", PostCode = "44000", City = "Nantes", Phone = "0778901234" },
            new Client { Name = "Rachel Bertrand", Email = "r.bertrand@yahoo.fr", Street = "38 Promenade des Anglais", PostCode = "06000", City = "Nice", Phone = "0789012345" },
            new Client { Name = "Sébastien Morel", Email = "s.morel@laposte.net", Street = "4 Place Stanislas", PostCode = "54000", City = "Nancy" },
            new Client { Name = "Thérèse Fournier", Email = "t.fournier@email.fr", Street = "20 Rue Sainte-Catherine", PostCode = "33000", City = "Bordeaux", Phone = "0701234567" },
            new Client { Name = "Ugo Girard", Email = "u.girard@orange.fr", Street = "13 Cours Julien", PostCode = "13006", City = "Marseille", Phone = "0611112222" },
            new Client { Name = "Valérie Bonnet", Email = "v.bonnet@gmail.com", Street = "31 Rue de Vesle", PostCode = "51100", City = "Reims", Phone = "0622223333" },
            new Client { Name = "William Dupuis", Email = "w.dupuis@free.fr", Street = "50 Avenue de la Gare", PostCode = "35000", City = "Rennes", Phone = "0633334444" },
            new Client { Name = "Xénia Lambert", Email = "x.lambert@yahoo.fr", Street = "2 Rue du Vieux-Port", PostCode = "13002", City = "Marseille" },
            new Client { Name = "Yann Fontaine", Email = "y.fontaine@laposte.net", Street = "27 Place de la Bourse", PostCode = "33000", City = "Bordeaux", Phone = "0655556666" },
            new Client { Name = "Zoé Mercier", Email = "z.mercier@email.fr", Street = "16 Rue de la Soif", PostCode = "35000", City = "Rennes", Phone = "0666667777" },
            new Client { Name = "Antoine Chevalier", Email = "a.chevalier@orange.fr", Street = "39 Avenue Victor Hugo", PostCode = "75016", City = "Paris", Phone = "0677778888" },
            new Client { Name = "Béatrice Muller", Email = "b.muller@gmail.com", Street = "14 Rue Kléber", PostCode = "67000", City = "Strasbourg", Phone = "0688889999" },
            new Client { Name = "Cédric Gauthier", Email = "c.gauthier@free.fr", Street = "23 Boulevard de la Plage", PostCode = "64200", City = "Biarritz" },
            new Client { Name = "Delphine Perrin", Email = "d.perrin@yahoo.fr", Street = "10 Rue des Marchands", PostCode = "68000", City = "Colmar", Phone = "0600001111" }
        );

        context.SaveChanges();
    }
}
