using webapi.Models;

namespace webapi.Services.Interfaces
{
    public interface IAmusementParkService
    {
        Task<List<Parks>> GetAllAsync();

        Task<Parks?> GetByIdAsync(int id);

        Task<ParksGetDto?> InsertAsync(ParksCreateDto dto);
        
        Task<Parks?> GetParkAttractions(int id);
        Task<Parks?> Edit(int id, string newName);
    }
}
