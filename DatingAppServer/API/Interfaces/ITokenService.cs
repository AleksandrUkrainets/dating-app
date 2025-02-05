using API.Entities;

namespace API.Interfaces;

public interface ITokenService
{
    public String CreateToken(AppUser user);
}
