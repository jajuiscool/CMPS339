using Microsoft.AspNetCore.Mvc;
using webapi.Models;
using webapi.Services.Interfaces;

namespace webapi.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly IUsersService _usersService;

        public UserController(IUsersService usersService) 
        {
            _usersService = usersService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            List<Users> users = await _usersService.GetAllAsync();
            return Ok(users);
        }

        [HttpGet]
        [Route("api/users/all-guests")]
        public async Task<ActionResult> GetAllGuests()
        {
            List<Users> users = await _usersService.GetAllGuestsAsync();
            return Ok(users);
        }
    }
}
