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
public class UsersController(IUserRepository repository, IMapper mapper) : ApiBaseController
{

    [HttpGet]
    public async Task<ActionResult<IEnumerable<MemberDto>>> GetUsers()
    {
        var users = await repository.GetUsersAsync();
        var usersToReturn = mapper.Map<IEnumerable<MemberDto>>(users);

        return Ok(usersToReturn);
    }


    [HttpGet("{id:int}")]
    public async Task<ActionResult<MemberDto>> GetUserById(int id)
    {
        var user = await repository.GetUserByIdAsync(id);

        if (user == null) return NotFound();

        var userToReturn = mapper.Map<MemberDto>(user);

        return Ok(userToReturn);
    }


    [HttpGet("{name}")]
    public async Task<ActionResult<AppUser>> GetUserByName(string name)
    {
        var user = await repository.GetUserByNameAsync(name);

        if (user == null) return NotFound();

        var userToReturn = mapper.Map<MemberDto>(user);

        return Ok(userToReturn);
    }
}
