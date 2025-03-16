using API.Entities;

namespace API.DTOs
{
    public class MemberDto
    {
        public int Id { get; set; }
        public string? UserName { get; set; }
        public int? Age { get; set; }
        public DateOnly BirdthDate { get; set; }
        public String? KnownAs { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastActive { get; set; }
        public String? Gender { get; set; }
        public String? Introduction { get; set; }
        public String? Interests { get; set; }
        public String? LookingFor { get; set; }
        public String? City { get; set; }
        public String? Country { get; set; }
        public List<PhotoDto>? Photos { get; set; }
        public string? PhotoUrl { get; set; }
    }
}
