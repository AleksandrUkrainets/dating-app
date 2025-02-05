using System.ComponentModel.DataAnnotations;

namespace API.DTOs;

public class SignUpDto
{
    [Required]
    public required String UserName { get; set; }

    [Required]
    public required String Password { get; set; }
}
