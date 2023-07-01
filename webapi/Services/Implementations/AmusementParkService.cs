using Dapper;
using System.Data;
using System.Data.SqlClient;
using webapi.Models;
using webapi.Services.Interfaces;

namespace webapi.Services.Implementations
{
    public class AmusementParkService : IAmusementParkService
    {
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

        public async Task<Parks?> InsertAsync(ParksCreateDto dto)
        {
            using (IDbConnection connection = new SqlConnection(ConnectionService.ConnectionString))

        }
    }
}
