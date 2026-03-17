using System.ComponentModel.DataAnnotations;

namespace WineshopManagerStarterKit.Models;

public class WineType
{
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Name { get; set; } = string.Empty;

    public ICollection<Wine> Wines { get; set; } = new List<Wine>();
}
