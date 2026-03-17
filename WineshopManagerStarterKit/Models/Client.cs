using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WineshopManagerStarterKit.Models;

public class Client
{
    public int Id { get; set; }

    [Required]
    [StringLength(150)]
    public string Name { get; set; } = string.Empty;

    [Required]
    [EmailAddress]
    [StringLength(255)]
    public string Email { get; set; } = string.Empty;

    [StringLength(255)]
    public string? Street { get; set; }

    [StringLength(10)]
    public string? PostCode { get; set; }

    [StringLength(100)]
    public string? City { get; set; }

    [Phone]
    [StringLength(20)]
    public string? Phone { get; set; }

    [JsonIgnore]
    public ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}
