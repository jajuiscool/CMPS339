using Dapper;
using System.Data;
using System.Data.SqlClient;
using webapi.Models;
using webapi.Services.Interfaces;

namespace webapi.Services.Implementations
{
    public class TicketsService : ITicketsService
    {
        private readonly ILogger<TicketsService> _logger;

        public TicketsService(ILogger<TicketsService> logger)
        {
            _logger = logger;
        }

        public Task<TicketsGetDto?> DeleteByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Tickets>> GetAllAsync()
        {
            List<Tickets> tickets = new();

            using (IDbConnection connection = new SqlConnection(ConnectionService.ConnectionString))
            {
                connection.Open();
                // var sql = @"SELECT attr.*, park.* FROM Attractions attr INNER JOIN Parks park ON attr.ParkId = park.Id";
                // var ticketsData = await connection.QueryAsync<Tickets>(sql, (x,y) => { x.Tickets = y; return x; });
                
            }

            return tickets;
        }

        public Task<Tickets?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Tickets?> GetTicket(int id)
        {
            throw new NotImplementedException();
        }

        public Task<TicketsGetDto?> InsertAsync(TicketsCreateDto dto)
        {
            throw new NotImplementedException();
        }

        Task<List<Tickets>> ITicketsService.GetAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}
