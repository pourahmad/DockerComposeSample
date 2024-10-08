using DockerComposeSample.Entities;
using DockerComposeSample.Services;
using Microsoft.AspNetCore.Mvc;

namespace DockerComposeSample.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController(IUserService userService) : ControllerBase
{
    private readonly IUserService _userService = userService;

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok(await _userService.GetAllAsync());
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> Get(Guid id)
    {
        return Ok(await _userService.GetByIdAsync(id));
    }


    [HttpPost]
    public async Task<IActionResult> Get([FromBody] User user)
    {
        return Ok(await _userService.AddAsync(user));
    }


    [HttpPut]
    public async Task<IActionResult> Put([FromBody] User user)
    {
        return Ok(_userService.UpdateAsync(user));
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id) 
    { 
        return Ok(_userService.DeleteAsync(id));
    }
}
