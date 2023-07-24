using Microsoft.AspNetCore.Mvc;
using webapi.Models;
using webapi.Services.Interfaces;

namespace webapi.Controllers
{

    [ApiController]
    [Route("api/guests")]
    public class GuestsController : ControllerBase
    {

        private readonly IGuestService _guestsService;

        public GuestsController(IGuestService guestsService)
        {
            _guestsService = guestsService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            List<Guests> guests = await _guestsService.GetAllAsync();
            return Ok(guests);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            Guests? guest = await _guestsService.GetByIdAsync(id);
            if (guest != null)
            { 
                return Ok(guest);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult> Create(UsersCreateDto dto)
        {
            if (ModelState.IsValid)
            {
                UsersGetDto? user = await _guestsService.GetByIdAsync(dto);
            }
        }

    }
}
