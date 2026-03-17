using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WineshopManagerStarterKit.Models;

public class WineType
{
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Name { get; set; } = string.Empty;

    [JsonIgnore]
    public ICollection<Wine> Wines { get; set; } = new List<Wine>();
}
