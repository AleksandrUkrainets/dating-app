using API.Data;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace API.Controllers;

public class AccountController(DataContext context, ITokenService tokenService) : ApiBaseController
{
    [HttpPost("signup")]//api/account/signup
    public async Task<ActionResult<UserDto>> SignUp(SignUpDto signUpDto)
    {
        if (await IsUserExist(signUpDto.UserName)) return BadRequest(" User name is exist");

        using var hmac = new HMACSHA512();

        var newUser = new AppUser
        {
            UserName = signUpDto.UserName,
            PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(signUpDto.Password)),
            PasswordSalt = hmac.Key
        };

        context.Add<AppUser>(newUser);
        await context.SaveChangesAsync();

        return new UserDto { UserName = signUpDto.UserName, Token = tokenService.CreateToken(newUser) };
    }


    [HttpPost("signin")]//api/account/signin
    public async Task<ActionResult<UserDto>> SignIn(SignInDto signInDto)
    {
        var user = await context.Users.FirstOrDefaultAsync(u => u.UserName == signInDto.UserName);

        if (user == null) return BadRequest("Invalid user name");

        using var hmac = new HMACSHA512(user.PasswordSalt);

        var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(signInDto.Password));

        for (int i = 0; i < computedHash.Length; i++)
        {
            if (computedHash[i] != user.PasswordHash[i]) return BadRequest("Invalid password");
        }

        return new UserDto { UserName = user.UserName, Token = tokenService.CreateToken(user) };
    }


    private async Task<bool> IsUserExist(String userName)
    {
        return await context.Users.AnyAsync(x => x.UserName == userName);
    }
}
