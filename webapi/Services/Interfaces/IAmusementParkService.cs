using webapi.Models;
using webapi.Services.Implementations;

namespace webapi.Services.Interfaces
{
    public interface IAmusementParkService
    {
        Task<List<Parks>> GetAllAsync();

        Task<Parks?> GetByIdAsync(int id);

        Task<ParksGetDto> InsertAsync(ParksCreateDto dto);
        Task<List<ParkAttraction>> GetByParkId(int parkId);
    }
}
