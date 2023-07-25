using Microsoft.AspNetCore.Mvc;
using webapi.Models;
using webapi.Services.Implementations;
using webapi.Services.Interfaces;

namespace webapi.Controllers
{
    [ApiController]
    [Route("api/guests")]
    public class GuestsController : ControllerBase
    {
        private readonly IGuestsService _guestsService;

        public GuestsController(IGuestsService guestsService)
        {
            _guestsService = guestsService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            List<Guests> guests = await _guestsService.GetAllAsync();
            return Ok(guests);
        }

        [HttpPost]
        public async Task<ActionResult> Create(GuestsCreateDto dto)
        {
            if (ModelState.IsValid)
            {

                GuestsGetDto? guest = await _guestsService.InsertAsync(dto);

                if (guest != null)
                {
                    return Ok(guest);
                }
                return BadRequest("Unable to insert record.");
            }
            return BadRequest("The model is invalid");
        }
    }
}
