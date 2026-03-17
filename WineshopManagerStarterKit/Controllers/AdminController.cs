using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WineshopManagerStarterKit.Models.Dto;

namespace WineshopManagerStarterKit.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize(Roles = "Administrator")]
public class AdminController : ControllerBase
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public AdminController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        _userManager = userManager;
        _roleManager = roleManager;
    }

    // PUT: api/admin/change-role
    [HttpPut("change-role")]
    public async Task<IActionResult> ChangeRole(ChangeRoleDto dto)
    {
        var validRoles = new[] { "Contributor", "Administrator" };

        if (!validRoles.Contains(dto.Role))
        {
            return BadRequest(new { message = "Invalid role. Must be 'Contributor' or 'Administrator'." });
        }

        var user = await _userManager.FindByEmailAsync(dto.Email);

        if (user == null)
        {
            return NotFound(new { message = "User not found." });
        }

        // Remove all current roles
        var currentRoles = await _userManager.GetRolesAsync(user);
        await _userManager.RemoveFromRolesAsync(user, currentRoles);

        // Assign the new role
        var result = await _userManager.AddToRoleAsync(user, dto.Role);

        if (!result.Succeeded)
        {
            return BadRequest(new { errors = result.Errors.Select(e => e.Description) });
        }

        return Ok(new { message = $"User '{dto.Email}' is now a {dto.Role}." });
    }
}
