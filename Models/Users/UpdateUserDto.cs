using System.ComponentModel.DataAnnotations;

namespace FamilyPlanner_Api.Models.Users;

public class UpdateUserDto
{
    [Required]
    [MinLength(8)]
    [MaxLength(24)]
    public string UserName { get; set; }

    [Required]
    [MaxLength(255)]
    [EmailAddress]
    public string Email { get; set; }
}
