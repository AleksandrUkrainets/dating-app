using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities;

[Table("Photos")]
public class Photo
{
    public int Id { get; set; }
    public required String Url { get; set; }
    public required bool IsMain { get; set; }
    public String? PublicId { get; set; }

    public int AppUserId { get; set; }
    public AppUser AppUser { get; set; } = null!;
}