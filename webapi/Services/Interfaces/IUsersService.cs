using webapi.Models;

namespace webapi.Services.Interfaces
{
    public interface IUsersService
    {

        Task<List<Users>> GetAllAsync();
        Task<Users?> GetByIdAsync(int id);
        Task<UsersGetDto?> InsertAsync(UsersCreateDto dto);
        Task<Users?> DeleteByIdAsync(int id);
    }
}
