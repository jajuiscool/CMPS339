using Microsoft.AspNetCore.Mvc;
using webapi.Models;
using webapi.Services.Interfaces;

namespace webapi.Controllers
{
    [ApiController]
    [Route("api/amusement-parks")]
    public class AmusementParkController : ControllerBase
    {
        private readonly IAmusementParkService _amusementParkService;

        public AmusementParkController(IAmusementParkService amusementParkService)
        {
            _amusementParkService = amusementParkService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            List<Parks> parks = await _amusementParkService.GetAllAsync();
            return Ok(parks);
        }

        [HttpGet("park-attractions")]
        //[Route("api/amusement-parks/attractions")]
        public async Task<ActionResult> GetAttractionsById(int id)
        {
            Parks? park = await _amusementParkService.GetParkAttractions(id);
            if (park != null)
            {
                return Ok(park);
            }
            return NotFound();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            Parks? park = await _amusementParkService.GetByIdAsync(id);
            if (park != null)
            {
                return Ok(park);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult> Create(ParksCreateDto dto)
        {
            if (ModelState.IsValid)
            {

                ParksGetDto? park = await _amusementParkService.InsertAsync(dto);

                if (park != null)
                {
                    return Ok(park);
                }
                return BadRequest("Unable to insert record.");
            }
            return BadRequest("The model is invalid");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Edit(int id, string newName, ParksUpdateDto dto)
        {
            Parks? park = await _amusementParkService.Edit(id, newName);
            if (park != null)
            {
                return Ok(park);
            }
            return NotFound();
        }

    }
}
