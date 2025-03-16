using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace API.Data.Repositories;

public class UserRepository(DataContext context, IMapper mapper) : IUserRepository
{
    public async Task<MemberDto?> GetMemberByIdAsync(int id)
    {
        return await context.Users
            .Include(u => u.Photos)
            .ProjectTo<MemberDto>(mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(user => user.Id == id);
    }

    public async Task<MemberDto?> GetMemberByNameAsync(string name)
    {
        return await context.Users
            .Include(u => u.Photos)
            .ProjectTo<MemberDto>(mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(user => user.UserName == name);
    }

    public async Task<IEnumerable<MemberDto>> GetMembersAsync()
    {
        return await context.Users
            .Include(u => u.Photos)
            .ProjectTo<MemberDto>(mapper.ConfigurationProvider)
            .ToListAsync();
    }

    public async Task<AppUser?> GetUserByIdAsync(int id)
    {
        return await context.Users.FindAsync(id);
    }

    public async Task<AppUser?> GetUserByNameAsync(string name)
    {
        return await context.Users
            .Include(u => u.Photos)
            .FirstOrDefaultAsync(user => user.UserName == name);
    }

    public async Task<IEnumerable<AppUser>> GetUsersAsync()
    {
        return await context.Users
            .Include(u => u.Photos)
            .ToListAsync();
    }

    public async Task<bool> SaveChangesAsync()
    {
        return await context.SaveChangesAsync() > 0;
    }

    public void UpdateUser(AppUser user)
    {
        context.Entry(user).State = EntityState.Modified;
    }
}
