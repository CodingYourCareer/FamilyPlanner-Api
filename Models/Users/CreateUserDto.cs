using System.ComponentModel.DataAnnotations;

namespace FamilyPlanner_Api.Models.Users;

public class CreateUserDto
{
    [Key]
    [Required]
    [MaxLength(255)]
    public string Id { get; set; }

    [Required]
    [MinLength(8)]
    [MaxLength(24)]
    public string UserName { get; set; }

    [Required]
    [MaxLength(255)]
    [EmailAddress]
    public string Email { get; set; }
}
