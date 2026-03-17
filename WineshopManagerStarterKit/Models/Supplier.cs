using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WineshopManagerStarterKit.Models;

public class Supplier
{
    public int Id { get; set; }

    [Required]
    [StringLength(150)]
    public string Name { get; set; } = string.Empty;

    [StringLength(255)]
    public string? Street { get; set; }

    [StringLength(10)]
    public string? PostCode { get; set; }

    [StringLength(100)]
    public string? City { get; set; }

    [EmailAddress]
    [StringLength(255)]
    public string? Email { get; set; }

    [Phone]
    [StringLength(20)]
    public string? Phone { get; set; }

    [Required]
    [StringLength(14, MinimumLength = 14, ErrorMessage = "SIRET must be exactly 14 digits.")]
    [RegularExpression(@"^\d{14}$", ErrorMessage = "SIRET must be exactly 14 digits.")]
    public string Siret { get; set; } = string.Empty;

    [JsonIgnore]
    public ICollection<Order> Orders { get; set; } = new List<Order>();
}
