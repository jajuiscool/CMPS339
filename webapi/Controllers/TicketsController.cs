using Microsoft.AspNetCore.Mvc;
using webapi.Models;
using webapi.Services.Interfaces;

namespace webapi.Controllers
{

    [ApiController]
    [Route("api/tickets")]
    public class TicketsController : ControllerBase
    {

        private readonly ITicketsService _ticketService;

        public TicketsController(ITicketsService ticketsService)
        {
            _ticketService = ticketsService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            List<Tickets> tickets = await _ticketService.GetAllAsync();
            return Ok(tickets);
        }

        [HttpGet("tickets")]
        public async Task<ActionResult> GetTicketsById(int id)
        {
            Tickets? ticket = await _ticketService.GetTicket(id);
            if (ticket != null)
            {
                return Ok(ticket);
            }
            return NotFound();

        }

        [HttpPost]
        public async Task<ActionResult> Create(TicketsCreateDto dto)
        {
            if (ModelState.IsValid)
            {
                TicketsGetDto? ticket = await _ticketService.InsertAsync(dto);
                if (ticket != null)
                {
                    return Ok(ticket);
                }
                return BadRequest("Unable to insert record.");
            }
            return BadRequest("The model is invalid.");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteById(int id)
        {
            Tickets? ticket = await _ticketService.DeleteByIdAsync(id);
            if(ticket != null)
            {
                return Ok(ticket);
            }
            return NotFound();
        }
    }
}
