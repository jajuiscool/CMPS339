using webapi.Models;
using webapi.Services.Interfaces;

namespace webapi.Services.Implementations
{
    public class GuestsService : IGuestService
    {
        private readonly ILogger<GuestsService> _logger;

        public GuestsService(ILogger<GuestsService> logger)
        {
            _logger = logger;
        }

        public async Task<List<Guests>> GetAllAsync()
        {

            List<Guests> guests = new();

            throw new NotImplementedException();

        }
    }
}
