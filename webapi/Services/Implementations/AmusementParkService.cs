using Dapper;
using Microsoft.Extensions.Logging;
using System.Data;
using System.Data.SqlClient;
using webapi.Models;
using webapi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System.Data.Common;

namespace webapi.Services.Implementations
{
    public class AmusementParkService : IAmusementParkService
    {
        private readonly ILogger<AmusementParkService> _logger;
        private readonly IMemoryCache _cache;

        public AmusementParkService(ILogger<AmusementParkService> logger, IMemoryCache cache)
        {
            _logger = logger;
            _cache = cache;
        }

        public async Task<List<Parks>> GetAllAsync()
        {
            List<Parks> parks = new();
            const string key = "parks-list";

            if (_cache.TryGetValue(key, out List<Parks> parksList))
            {
                return parksList;
            }

            using (IDbConnection connection = new SqlConnection(ConnectionService.ConnectionString))
            { 
                connection.Open();

                var parkData = await connection.QueryAsync<Parks>("SELECT * FROM Parks WHERE Id = @Id", new { Id = 1 });

                parks = parkData.ToList();
            }

            _cache.Set(key, parks, TimeSpan.FromSeconds(10));
            return parks;
        }

        public async Task<Parks?> GetByIdAsync(int id)
        {
            List<Parks> parks = new();
            using (IDbConnection connection = new SqlConnection(ConnectionService.ConnectionString))
            {
                connection.Open();

                var parkData = await connection.QueryAsync<Parks>("SELECT * FROM Parks WHERE Id = @Id", new {Id = id});

                parks = parkData.ToList();
            }
            return parks.FirstOrDefault();
        }

        public async Task<ParksGetDto?> InsertAsync(ParksCreateDto dto)
        {
            try
            {
                using IDbConnection connection = new SqlConnection(ConnectionService.ConnectionString);
                connection.Open();

                IEnumerable<Parks> newPark = await connection
                    .QueryAsync<Parks>("INSERT INTO Parks VALUES (@Name)", new { Name = dto.Name });

                return newPark
                    .Select(x => new ParksGetDto { Name = dto.Name })
                    .FirstOrDefault();
            } catch (Exception e)
            {
                _logger.LogError(e, "An error has occured. DTO Value Name: {NAME} At: {TIME}", dto.Name, DateTime.Now.ToString());
                return null;
            }
        }

        public async Task<List<ParkAttraction>> GetByParkID(int parkId)
        {

            using IDbConnection connection = new SqlConnection(ConnectionService.ConnectionString);
            connection.Open();

            var parkAttraction = await connection.QueryAsync<ParkAttraction>(
                "SELECT park.Name as ParkName, att.Id AS AttractionId" +
                "FROM Parks AS park " +
                "INNER JOIN Attractions AS att " +
                "ON (att.ParkId = park.Id) " +
                "WHERE park.Id = @ParkId", new { ParkId = parkId }
                );
            var list = parkAttraction.ToList();

            return list;
        }


    }

}