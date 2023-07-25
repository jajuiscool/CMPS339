using webapi.Models;

namespace webapi.Services.Interfaces
{
    public interface IGuestsService
    {
        Task<List<Guests>> GetAllAsync();
        Task<GuestsGetDto?> InsertAsync(GuestsCreateDto dto);
    }
}
