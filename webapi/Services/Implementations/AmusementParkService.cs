using Dapper;
using Microsoft.Extensions.Logging;
using System.Data;
using System.Data.SqlClient;
using webapi.Models;
using webapi.Services.Interfaces;

namespace webapi.Services.Implementations
{
    public class AmusementParkService : IAmusementParkService
    {
        private readonly ILogger<AmusementParkService> _logger; 

        public AmusementParkService(ILogger<AmusementParkService> logger)
        {
            _logger = logger;
        }
        public async Task<List<Parks>> GetAllAsync()
        {
            List<Parks> parks = new();

            using (IDbConnection connection = new SqlConnection(ConnectionService.ConnectionString))
            { 
                connection.Open();

                var parkData = await connection.QueryAsync<Parks>("SELECT * FROM Parks");

                parks = parkData.ToList();
            }

            return parks;
        }

        public async Task<Parks?> GetParkAttractions(int id)
        {
            List<Parks> parks = new();

            using (IDbConnection connection = new SqlConnection(ConnectionService.ConnectionString))
            {
                connection.Open();
                var param = new { Id = id };
                var sql = "SELECT prk.*, attr.*, dets.* " +
                    "FROM Parks prk INNER JOIN Attractions attr ON attr.ParkId = prk.Id " +
                    "INNER JOIN AttractionDetails dets ON dets.AttractionId =" +
                    " attr.Id WHERE prk.Id = @Id";

                var attractionsData = await connection.QueryAsync<Parks, Attractions, AttractionDetails, Parks>(sql,
                    (x, y, z) => { x.Attractions = y; y.Details  = z; return x; }, param);

                parks = attractionsData.ToList();


              //  var parkData = await connection.QueryAsync<Parks>("SELECT * FROM Parks WHERE Id = @Id", new { Id = id });



                //var parkData = await connection.QueryAsync<Parks>(
                //  "SELECT prk.*, attr.*, dets.* " +
                //"FROM Parks prk INNER JOIN Attractions attr ON attr.ParkId = prk.Id " +
                //"INNER JOIN AttractionDetails dets ON dets.AttractionId =" +
                //" attr.IdWHERE prk.Id = @Id", new { Id = id });

                //parks = parkData.ToList();

            }

            return parks.FirstOrDefault(); ;
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
    }
}
