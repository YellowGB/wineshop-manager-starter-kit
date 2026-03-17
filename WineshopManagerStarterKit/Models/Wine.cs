using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WineshopManagerStarterKit.Models;

public class Wine
{
    public int Id { get; set; }

    [Required]
    [StringLength(150)]
    public string Name { get; set; } = string.Empty;

    [Required]
    public int WineTypeId { get; set; }

    public WineType WineType { get; set; } = null!;

    [Required]
    [Range(0, int.MaxValue)]
    public int Quantity { get; set; } = 0;

    [Required]
    [Column(TypeName = "decimal(10,2)")]
    [Range(0, double.MaxValue)]
    public decimal AmountBeforeTax { get; set; }

    [Required]
    [Column(TypeName = "decimal(5,2)")]
    [Range(0, 100)]
    public decimal TaxRate { get; set; }

    [Required]
    [Range(0, int.MaxValue)]
    public int Threshold { get; set; }
}
