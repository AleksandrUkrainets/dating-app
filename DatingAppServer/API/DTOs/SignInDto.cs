using System.ComponentModel.DataAnnotations;

namespace API.DTOs
{
    public class SignInDto
    {
        [Required]
        public required String UserName { get; set; }

        [Required]
        public required String Password { get; set; }
    }
}
