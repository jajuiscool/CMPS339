﻿using Microsoft.AspNetCore.Mvc;
using webapi.Models;
using webapi.Services.Implementations;
using webapi.Services.Interfaces;

namespace webapi.Controllers
{
    [ApiController]
    [Route("api/amusement-parks")]
    public class AmusementParkController : ControllerBase
    {
       private readonly IAmusementParkService _amusementParkService;

        public AmusementParkController()
        {

            ILoggerFactory factory = new LoggerFactory();

            ILogger<AmusementParkService> logger = new Logger<AmusementParkService>(factory);

            _amusementParkService = new AmusementParkService(logger);

        }

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
    }
}
