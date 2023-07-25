using System.Threading.Tasks;
using webapi.Models;

namespace webapi.Services.Interfaces
{
    public interface IAttractionsService
    {
        Task<List<Attractions>> GetAllAsync();
        Task<Attractions?> GetByIdAsync(int id);
        Task<AttractionsGetDto?> InsertAsync(AttractionsCreateDto dto);

        Task<Attractions?> DeleteByIdAsync(int id);

        Task<List<AttractionDetails>> GetAllDetailsAsync();
        Task<List<AttractionDetails>> FilterAsync(int filter);
    }
}
