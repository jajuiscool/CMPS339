using Microsoft.AspNetCore.Mvc;
using webapi.Models;
using webapi.Services.Implementations;
using webapi.Services.Interfaces;

namespace webapi.Controllers
{
    [ApiController]
    [Route("api/attractions")]
    public class AttractionsController : ControllerBase
    {
        private readonly IAttractionsService _attractionsService;

        public AttractionsController(IAttractionsService attractionsService)
        {
            _attractionsService = attractionsService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            List<Attractions> attractions = await _attractionsService.GetAllAsync();
            return Ok(attractions);
        }

        [HttpGet("details")]
        public async Task<ActionResult> GetAllDetails()
        {
            List<AttractionDetails> attractions = await _attractionsService.GetAllDetailsAsync();
            return Ok(attractions);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            Attractions? attraction = await _attractionsService.GetByIdAsync(id);
            if (attraction != null)
            {
                return Ok(attraction);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult> Create(AttractionsCreateDto dto)
        {
            if (ModelState.IsValid)
            {

                AttractionsGetDto? attraction = await _attractionsService.InsertAsync(dto);

                if (attraction != null)
                {
                    return Ok(attraction);
                }
                return BadRequest("Unable to insert record.");
            }
            return BadRequest("The model is invalid");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteById(int id)
        {
            Attractions? attraction = await _attractionsService.DeleteByIdAsync(id);
            if (attraction != null)
            {
                return Ok(attraction);
            }
            return NotFound();
        }

    }
}
