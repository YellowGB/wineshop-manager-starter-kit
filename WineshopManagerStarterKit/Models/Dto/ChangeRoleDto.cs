using System.ComponentModel.DataAnnotations;

namespace WineshopManagerStarterKit.Models.Dto;

public class ChangeRoleDto
{
    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    [Required]
    public string Role { get; set; } = string.Empty;
}
