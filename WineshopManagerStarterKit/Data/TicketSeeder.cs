using WineshopManagerStarterKit.Models;

namespace WineshopManagerStarterKit.Data;

public static class TicketSeeder
{
    public static void Seed(AppDbContext context)
    {
        if (context.Tickets.Any())
        {
            return;
        }

        var clients = context.Clients.ToList();
        var wines = context.Wines.ToList();

        var tickets = new List<Ticket>();

        // Ticket 1 — single bottle purchase
        tickets.Add(new Ticket
        {
            ClientId = clients[0].Id,
            SaleDate = new DateTime(2025, 9, 5),
            TicketWines = new List<TicketWine>
            {
                new TicketWine { WineId = wines[0].Id, Quantity = 1 }
            }
        });

        // Ticket 2 — someone buys 2 bottles of the same wine
        tickets.Add(new Ticket
        {
            ClientId = clients[1].Id,
            SaleDate = new DateTime(2025, 9, 8),
            TicketWines = new List<TicketWine>
            {
                new TicketWine { WineId = wines[2].Id, Quantity = 2 }
            }
        });

        // Ticket 3 — a client buys 3 different wines
        tickets.Add(new Ticket
        {
            ClientId = clients[2].Id,
            SaleDate = new DateTime(2025, 9, 12),
            TicketWines = new List<TicketWine>
            {
                new TicketWine { WineId = wines[0].Id, Quantity = 1 },
                new TicketWine { WineId = wines[3].Id, Quantity = 2 },
                new TicketWine { WineId = wines[4].Id, Quantity = 1 }
            }
        });

        // Ticket 4 — repeat customer, single bottle
        tickets.Add(new Ticket
        {
            ClientId = clients[0].Id,
            SaleDate = new DateTime(2025, 9, 15),
            TicketWines = new List<TicketWine>
            {
                new TicketWine { WineId = wines[4].Id, Quantity = 1 }
            }
        });

        // Ticket 5 — buying 6 bottles of one wine (a case)
        tickets.Add(new Ticket
        {
            ClientId = clients[5].Id,
            SaleDate = new DateTime(2025, 9, 20),
            TicketWines = new List<TicketWine>
            {
                new TicketWine { WineId = wines[1].Id, Quantity = 6 }
            }
        });

        // Ticket 6 — two different wines
        tickets.Add(new Ticket
        {
            ClientId = clients[3].Id,
            SaleDate = new DateTime(2025, 9, 22),
            TicketWines = new List<TicketWine>
            {
                new TicketWine { WineId = wines[2].Id, Quantity = 3 },
                new TicketWine { WineId = wines[0].Id, Quantity = 1 }
            }
        });

        // Ticket 7 — single bottle
        tickets.Add(new Ticket
        {
            ClientId = clients[8].Id,
            SaleDate = new DateTime(2025, 10, 1),
            TicketWines = new List<TicketWine>
            {
                new TicketWine { WineId = wines[3].Id, Quantity = 1 }
            }
        });

        // Ticket 8 — mixed purchase, 2 wines
        tickets.Add(new Ticket
        {
            ClientId = clients[10].Id,
            SaleDate = new DateTime(2025, 10, 3),
            TicketWines = new List<TicketWine>
            {
                new TicketWine { WineId = wines[4].Id, Quantity = 2 },
                new TicketWine { WineId = wines[1].Id, Quantity = 1 }
            }
        });

        // Ticket 9 — someone really likes Château Margaux
        tickets.Add(new Ticket
        {
            ClientId = clients[13].Id,
            SaleDate = new DateTime(2025, 10, 7),
            TicketWines = new List<TicketWine>
            {
                new TicketWine { WineId = wines[0].Id, Quantity = 3 }
            }
        });

        // Ticket 10 — small gift purchase
        tickets.Add(new Ticket
        {
            ClientId = clients[6].Id,
            SaleDate = new DateTime(2025, 10, 10),
            TicketWines = new List<TicketWine>
            {
                new TicketWine { WineId = wines[4].Id, Quantity = 1 },
                new TicketWine { WineId = wines[2].Id, Quantity = 1 }
            }
        });

        // Ticket 11 — single bottle purchase
        tickets.Add(new Ticket
        {
            ClientId = clients[15].Id,
            SaleDate = new DateTime(2025, 10, 14),
            TicketWines = new List<TicketWine>
            {
                new TicketWine { WineId = wines[1].Id, Quantity = 1 }
            }
        });

        // Ticket 12 — party supplies, 3 different wines
        tickets.Add(new Ticket
        {
            ClientId = clients[4].Id,
            SaleDate = new DateTime(2025, 10, 18),
            TicketWines = new List<TicketWine>
            {
                new TicketWine { WineId = wines[0].Id, Quantity = 2 },
                new TicketWine { WineId = wines[2].Id, Quantity = 3 },
                new TicketWine { WineId = wines[4].Id, Quantity = 6 }
            }
        });

        // Ticket 13 — quick single purchase
        tickets.Add(new Ticket
        {
            ClientId = clients[20].Id,
            SaleDate = new DateTime(2025, 10, 21),
            TicketWines = new List<TicketWine>
            {
                new TicketWine { WineId = wines[3].Id, Quantity = 2 }
            }
        });

        // Ticket 14 — two wines
        tickets.Add(new Ticket
        {
            ClientId = clients[9].Id,
            SaleDate = new DateTime(2025, 10, 25),
            TicketWines = new List<TicketWine>
            {
                new TicketWine { WineId = wines[1].Id, Quantity = 2 },
                new TicketWine { WineId = wines[3].Id, Quantity = 1 }
            }
        });

        // Ticket 15 — repeat buyer, just champagne
        tickets.Add(new Ticket
        {
            ClientId = clients[2].Id,
            SaleDate = new DateTime(2025, 11, 1),
            TicketWines = new List<TicketWine>
            {
                new TicketWine { WineId = wines[4].Id, Quantity = 3 }
            }
        });

        // Ticket 16 — single bottle
        tickets.Add(new Ticket
        {
            ClientId = clients[18].Id,
            SaleDate = new DateTime(2025, 11, 5),
            TicketWines = new List<TicketWine>
            {
                new TicketWine { WineId = wines[0].Id, Quantity = 1 }
            }
        });

        // Ticket 17 — two different wines, small quantities
        tickets.Add(new Ticket
        {
            ClientId = clients[22].Id,
            SaleDate = new DateTime(2025, 11, 8),
            TicketWines = new List<TicketWine>
            {
                new TicketWine { WineId = wines[2].Id, Quantity = 1 },
                new TicketWine { WineId = wines[3].Id, Quantity = 1 }
            }
        });

        // Ticket 18 — a collector buying Barolo
        tickets.Add(new Ticket
        {
            ClientId = clients[13].Id,
            SaleDate = new DateTime(2025, 11, 12),
            TicketWines = new List<TicketWine>
            {
                new TicketWine { WineId = wines[1].Id, Quantity = 4 }
            }
        });

        // Ticket 19 — three wines for a dinner party
        tickets.Add(new Ticket
        {
            ClientId = clients[7].Id,
            SaleDate = new DateTime(2025, 11, 16),
            TicketWines = new List<TicketWine>
            {
                new TicketWine { WineId = wines[0].Id, Quantity = 2 },
                new TicketWine { WineId = wines[2].Id, Quantity = 2 },
                new TicketWine { WineId = wines[4].Id, Quantity = 2 }
            }
        });

        // Ticket 20 — single purchase
        tickets.Add(new Ticket
        {
            ClientId = clients[25].Id,
            SaleDate = new DateTime(2025, 11, 20),
            TicketWines = new List<TicketWine>
            {
                new TicketWine { WineId = wines[3].Id, Quantity = 1 }
            }
        });

        // Ticket 21 — holiday shopping, two wines
        tickets.Add(new Ticket
        {
            ClientId = clients[11].Id,
            SaleDate = new DateTime(2025, 12, 2),
            TicketWines = new List<TicketWine>
            {
                new TicketWine { WineId = wines[4].Id, Quantity = 4 },
                new TicketWine { WineId = wines[0].Id, Quantity = 2 }
            }
        });

        // Ticket 22 — quick single bottle
        tickets.Add(new Ticket
        {
            ClientId = clients[16].Id,
            SaleDate = new DateTime(2025, 12, 5),
            TicketWines = new List<TicketWine>
            {
                new TicketWine { WineId = wines[2].Id, Quantity = 1 }
            }
        });

        // Ticket 23 — christmas gifts, 3 different wines
        tickets.Add(new Ticket
        {
            ClientId = clients[0].Id,
            SaleDate = new DateTime(2025, 12, 15),
            TicketWines = new List<TicketWine>
            {
                new TicketWine { WineId = wines[0].Id, Quantity = 1 },
                new TicketWine { WineId = wines[1].Id, Quantity = 1 },
                new TicketWine { WineId = wines[4].Id, Quantity = 2 }
            }
        });

        // Ticket 24 — new year's eve champagne
        tickets.Add(new Ticket
        {
            ClientId = clients[14].Id,
            SaleDate = new DateTime(2025, 12, 28),
            TicketWines = new List<TicketWine>
            {
                new TicketWine { WineId = wines[4].Id, Quantity = 6 }
            }
        });

        // Ticket 25 — single bottle after the holidays
        tickets.Add(new Ticket
        {
            ClientId = clients[27].Id,
            SaleDate = new DateTime(2026, 1, 8),
            TicketWines = new List<TicketWine>
            {
                new TicketWine { WineId = wines[3].Id, Quantity = 1 }
            }
        });

        // Ticket 26 — two wines
        tickets.Add(new Ticket
        {
            ClientId = clients[19].Id,
            SaleDate = new DateTime(2026, 1, 14),
            TicketWines = new List<TicketWine>
            {
                new TicketWine { WineId = wines[0].Id, Quantity = 1 },
                new TicketWine { WineId = wines[2].Id, Quantity = 2 }
            }
        });

        // Ticket 27 — small purchase
        tickets.Add(new Ticket
        {
            ClientId = clients[23].Id,
            SaleDate = new DateTime(2026, 1, 20),
            TicketWines = new List<TicketWine>
            {
                new TicketWine { WineId = wines[1].Id, Quantity = 1 }
            }
        });

        // Ticket 28 — valentine gift, two wines
        tickets.Add(new Ticket
        {
            ClientId = clients[5].Id,
            SaleDate = new DateTime(2026, 2, 12),
            TicketWines = new List<TicketWine>
            {
                new TicketWine { WineId = wines[0].Id, Quantity = 1 },
                new TicketWine { WineId = wines[4].Id, Quantity = 1 }
            }
        });

        // Ticket 29 — regular buyer picks up some Chablis
        tickets.Add(new Ticket
        {
            ClientId = clients[2].Id,
            SaleDate = new DateTime(2026, 2, 20),
            TicketWines = new List<TicketWine>
            {
                new TicketWine { WineId = wines[2].Id, Quantity = 3 }
            }
        });

        // Ticket 30 — spring purchase, three wines
        tickets.Add(new Ticket
        {
            ClientId = clients[12].Id,
            SaleDate = new DateTime(2026, 3, 5),
            TicketWines = new List<TicketWine>
            {
                new TicketWine { WineId = wines[1].Id, Quantity = 2 },
                new TicketWine { WineId = wines[3].Id, Quantity = 2 },
                new TicketWine { WineId = wines[4].Id, Quantity = 1 }
            }
        });

        context.Tickets.AddRange(tickets);
        context.SaveChanges();
    }
}
