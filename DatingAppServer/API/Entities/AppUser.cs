using API.Extensions;

namespace API.Entities;

public class AppUser
{
    public int Id { get; set; }
    public required string UserName { get; set; }

    public byte[] PasswordHash { get; set; } = [];

    public byte[] PasswordSalt { get; set; } = [];
    public DateOnly BirdthDate { get; set; }
    public required String KnownAs { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime LastActive { get; set; } = DateTime.Now;
    public required String Gender { get; set; }
    public String? Introduction { get; set; }
    public String? Interests { get; set; }
    public String? LookingFor { get; set; }
    public required String City { get; set; }
    public required String Country { get; set; }
    public List<Photo> Photos { get; set; } = [];

    //public int GetAge()
    //{
    //    return BirdthDate.AgeCalculate();
    //}
}
