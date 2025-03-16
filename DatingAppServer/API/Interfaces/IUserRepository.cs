using API.DTOs;
using API.Entities;
using AutoMapper;

namespace API.Interfaces;

public interface IUserRepository
{
    Task<IEnumerable<AppUser>> GetUsersAsync();
    void UpdateUser(AppUser user);
    Task<AppUser?> GetUserByIdAsync(int id);
    Task<AppUser?> GetUserByNameAsync(string name);
    Task<bool> SaveChangesAsync();
    Task<MemberDto?> GetMemberByIdAsync(int id);

    Task<MemberDto?> GetMemberByNameAsync(string name);

    Task<IEnumerable<MemberDto>> GetMembersAsync();
}
