using API.Data;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

[Authorize]
public class UsersController(IUserRepository repository) : ApiBaseController
{

    [HttpGet]
    public async Task<ActionResult<IEnumerable<MemberDto>>> GetUsers()
    {
        var users = await repository.GetMembersAsync();

        return Ok(users);
    }


    [HttpGet("{id:int}")]
    public async Task<ActionResult<MemberDto>> GetUserById(int id)
    {
        var user = await repository.GetMemberByIdAsync(id);

        if (user == null) return NotFound();

        return Ok(user);
    }


    [HttpGet("{name}")]
    public async Task<ActionResult<AppUser>> GetUserByName(string name)
    {
        var user = await repository.GetMemberByNameAsync(name);

        if (user == null) return NotFound();

        return Ok(user);
    }
}
