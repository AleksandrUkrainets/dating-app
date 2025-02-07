using System.ComponentModel.DataAnnotations;

namespace API.DTOs;

public class SignInDto
{
    [Required]
    [MinLength(3)]
    public required String UserName { get; set; }

    [Required]
    [StringLength(256, MinimumLength = 8)]
    public required String Password { get; set; }
}
