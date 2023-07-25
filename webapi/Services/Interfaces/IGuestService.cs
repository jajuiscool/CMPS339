using webapi.Models;
using webapi.Services.Implementations;

namespace webapi.Services.Interfaces
{
    public interface IGuestService
    {
        Task<List<Guests>> GetAllAsync();
        Task<Guests?> GetByIdAsync(int id);
        Task<GuestsGetDto?> InsertAsync(GuestsCreateDto dto);
        Task<Guests?> DeleteByIdAsync(int id);
        Task<Guests?> GetByIdAsync(int id);
    }
}
