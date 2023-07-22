using System.Data.SqlClient;
using System.Data;
using webapi.Models;
using webapi.Services.Interfaces;
using Dapper;

namespace webapi.Services.Implementations
{
    public class AttractionsService : IAttractionsService
    {
        private readonly ILogger<AttractionsService> _logger;

        public AttractionsService(ILogger<AttractionsService> logger)
        {
            _logger = logger;
        }
        public async Task<List<Attractions>> GetAllAsync()
        {
            List<Attractions> attractions = new();

            using (IDbConnection connection = new SqlConnection(ConnectionService.ConnectionString))
            {
                connection.Open();

                var attractionsData = await connection.QueryAsync<Attractions>("SELECT * FROM Attractions");

                attractions = attractionsData.ToList();
            }

            return attractions;
        }

        public async Task<Attractions?> GetByIdAsync(int id)
        {
            List<Attractions> attractions = new();
            using (IDbConnection connection = new SqlConnection(ConnectionService.ConnectionString))
            {
                connection.Open();

                var attractionsData = await connection.QueryAsync<Attractions>("SELECT * FROM Attractions WHERE Id = @Id", new { Id = id });

                attractions = attractionsData.ToList();
            }
            return attractions.FirstOrDefault();
        }

        public async Task<AttractionsGetDto?> InsertAsync(AttractionsCreateDto dto)
        {
            try
            {
                using IDbConnection connection = new SqlConnection(ConnectionService.ConnectionString);
                connection.Open();

                IEnumerable<Attractions> newAttraction = await connection
                    .QueryAsync<Attractions>("INSERT INTO Attractions VALUES (@ParkId)", new { ParkId = dto.ParkId });

                return newAttraction
                    .Select(x => new AttractionsGetDto 
                    { ParkId = dto.ParkId
                    })
                    .FirstOrDefault();
            } catch (Exception e)
            {
                _logger.LogError(e, "An error has occured. DTO Value Name: {NAME} At: {TIME}", dto.ParkId, DateTime.Now.ToString());
                return null;
            }
        }
    }
}
