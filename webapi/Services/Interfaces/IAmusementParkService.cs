using webapi.Models;

namespace webapi.Services.Interfaces
{
    public interface IAmusementParkService
    {
        Task<List<Parks>> GetAllAsync();

        Task<Parks> GetByIdAsync(int id);
    }
}
