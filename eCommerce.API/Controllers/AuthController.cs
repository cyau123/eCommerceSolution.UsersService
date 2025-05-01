using eCommerce.Core.DTO;
using eCommerce.Core.ServiceContracts;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IUsersService _usersService;
        
    public AuthController(IUsersService usersService)
    {
        _usersService = usersService;
    }
    
    // endpoint to handle user login
    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest loginRequest)
    {
        if (loginRequest == null)
        {
            return BadRequest("Invalid login request");
        }
        
        var response = await _usersService.Login(loginRequest);
        if (response == null || !response.Success)
        {
            return Unauthorized(response);
        }
        return Ok(response);
    }
    
    [HttpPost("register")]
    // endpoint to handle user registration
    public async Task<IActionResult> Register(RegisterRequest registerRequest)
    {
        if (registerRequest == null)
        {
            return BadRequest("Invalid registration request");
        }
        
        var response = await _usersService.Register(registerRequest);
        if (response == null || !response.Success)
        {
            return BadRequest(response);
        }
        return Ok(response);
    }
}