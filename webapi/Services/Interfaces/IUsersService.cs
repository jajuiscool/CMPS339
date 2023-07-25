using webapi.Models;

namespace webapi.Services.Interfaces
{
    public interface IUsersService
    {
        Task<List<Users>> GetAllAsync();
        Task<List<Users>> GetAllGuestsAsync();
    }
}
