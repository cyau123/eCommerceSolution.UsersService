using eCommerce.Core.DTO;
using eCommerce.Core.ServiceContracts;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IUsersService _usersService;
    
    public UsersController(IUsersService usersService)
    {
        _usersService = usersService;
    }
    
    //GET /api/Users/{userID}
    [HttpGet("{userID}")]
    public async Task<IActionResult> GetUserByUserID(Guid userID)
    {
        if (userID == Guid.Empty)
        {
            return BadRequest("Invalid User ID");
        }
        
        UserDTO? user = await _usersService.GetUserByUserID(userID);
        if (user == null)
        {
            return NotFound(user);
        }
        
        return Ok(user);
    }
}

