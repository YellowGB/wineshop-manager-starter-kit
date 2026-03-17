using System.ComponentModel.DataAnnotations;

namespace WineshopManagerStarterKit.Models;

public class Ticket
{
    public int Id { get; set; }

    [Required]
    public int ClientId { get; set; }

    public Client Client { get; set; } = null!;

    [Required]
    public DateTime SaleDate { get; set; }

    public ICollection<TicketWine> TicketWines { get; set; } = new List<TicketWine>();
}
