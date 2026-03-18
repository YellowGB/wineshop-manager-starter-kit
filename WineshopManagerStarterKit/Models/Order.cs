using System.ComponentModel.DataAnnotations;

namespace WineshopManagerStarterKit.Models;

public class Order
{
    public int Id { get; set; }

    [Required]
    public int SupplierId { get; set; }

    public Supplier? Supplier { get; set; }

    [Required]
    public DateTime OrderDate { get; set; }

    [Required]
    public DateTime DeliveryDate { get; set; }

    [Required]
    [StringLength(255)]
    public string Street { get; set; } = string.Empty;

    [Required]
    [StringLength(10)]
    public string PostCode { get; set; } = string.Empty;

    [Required]
    [StringLength(100)]
    public string City { get; set; } = string.Empty;

    public bool Validated { get; set; } = false;

    public bool Delivered { get; set; } = false;

    public ICollection<OrderWine> OrderWines { get; set; } = new List<OrderWine>();
}
