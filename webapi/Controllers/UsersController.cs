using Microsoft.AspNetCore.Mvc;
using webapi.Models;
using webapi.Services.Interfaces;

namespace webapi.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {

        private readonly IUsersService _usersService;

        public UsersController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            List<Users> users = await _usersService.GetAllAsync();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            Users? user = await _usersService.GetByIdAsync(id);
            if (user != null)
            {
                return Ok(user);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult> Create(UsersCreateDto dto)
        {
            if (ModelState.IsValid)
            {
                UsersGetDto? user = await _usersService.InsertAsync(dto);
                if (user != null)
                {
                    return Ok(user);
                }
                return BadRequest("Unable to insert record.");
            }
            return BadRequest("The model is invalid.");
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteById(int id)
        {
            Users? user = await _usersService.DeleteByIdAsync(id);
            if (user != null)
            {
                return Ok(user);
            }
            return NotFound();
        }

    }
}
