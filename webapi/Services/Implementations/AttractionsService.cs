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

                var sql = @"SELECT attr.*, park.* FROM Attractions attr INNER JOIN Parks park ON attr.ParkId = park.Id";

                var attractionsData = await connection.QueryAsync<Attractions, Parks, Attractions>(sql,
                    (x, y) => { x.Park = y; return x; });

                attractions = attractionsData.ToList();
            }

            return attractions;
        }

        public async Task<List<AttractionDetails>> GetAllDetailsAsync()
        {
            List<AttractionDetails> attractions = new();

            using (IDbConnection connection = new SqlConnection(ConnectionService.ConnectionString))
            {
                connection.Open();

                var sql = @"SELECT dets.*, att.* FROM AttractionDetails dets RIGHT JOIN Attractions att ON dets.AttractionId = att.Id";

                var attractionsData = await connection.QueryAsync<AttractionDetails, Attractions, AttractionDetails>(sql,
                    (x, y) => { x.Attraction = y; return x; });

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
                _logger.LogError(e, "An error has occured. DTO Park Id: {PARKID} At: {TIME}", dto.ParkId, DateTime.Now.ToString());
                return null;
            }
        }

        public async Task<Attractions?> DeleteByIdAsync(int id)
        {
            List<Attractions> attractions = new();
            using (IDbConnection connection = new SqlConnection(ConnectionService.ConnectionString))
            {
                connection.Open();

                var attractionsData = await connection.QueryAsync<Attractions>("DELETE FROM Attractions WHERE Id = @Id", new { Id = id });

                attractions = attractionsData.ToList();
            }
            return attractions.FirstOrDefault();
        }



    }
}
