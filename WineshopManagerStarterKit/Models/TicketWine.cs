using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WineshopManagerStarterKit.Models;

public class TicketWine
{
    [Required]
    public int TicketId { get; set; }

    [JsonIgnore]
    public Ticket Ticket { get; set; } = null!;

    [Required]
    public int WineId { get; set; }

    public Wine Wine { get; set; } = null!;

    [Required]
    [Range(1, int.MaxValue)]
    public int Quantity { get; set; }
}
