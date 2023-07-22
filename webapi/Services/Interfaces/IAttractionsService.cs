using System.Threading.Tasks;
using webapi.Models;

namespace webapi.Services.Interfaces
{
    public interface IAttractionsService
    {
        Task<List<Attractions>> GetAllAsync();
        Task<Attractions?> GetByIdAsync(int id);
        Task<AttractionsGetDto?> InsertAsync(AttractionsCreateDto dto);
    }
}
