using API.Data;
using API.Entities;
using API.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

[Authorize]
public class UsersController(IUserRepository repository) : ApiBaseController
{

    [HttpGet]
    public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
    {
        return Ok(await repository.GetUsersAsync());
    }


    [HttpGet("{id:int}")]
    public async Task<ActionResult<AppUser>> GetUserById(int id)
    {
        var user = await repository.GetUserByIdAsync(id);

        if (user == null) return NotFound();

        return user;
    }


    [HttpGet("{name}")]
    public async Task<ActionResult<AppUser>> GetUserByName(string name)
    {
        var user = await repository.GetUserByNameAsync(name);

        if (user == null) return NotFound();

        return user;
    }
}
