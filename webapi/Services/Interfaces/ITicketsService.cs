using webapi.Models;

namespace webapi.Services.Interfaces
{
    public interface ITicketsService
    {

        Task<List<Tickets>> GetAllAsync();

        Task<Tickets?> GetByIdAsync(int id);
        Task<Tickets?> GetTicket(int id);
        Task<TicketsGetDto?> InsertAsync(TicketsCreateDto dto);

        Task<TicketsGetDto?> DeleteByIdAsync(int id);

    }
}
