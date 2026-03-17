using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WineshopManagerStarterKit.Models;

public class OrderWine
{
    [Required]
    public int OrderId { get; set; }

    [JsonIgnore]
    public Order Order { get; set; } = null!;

    [Required]
    public int WineId { get; set; }

    public Wine Wine { get; set; } = null!;

    [Required]
    [Range(1, int.MaxValue)]
    public int Quantity { get; set; }
}
