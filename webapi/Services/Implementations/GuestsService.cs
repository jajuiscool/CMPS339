using Dapper;
using System.Data;
using System.Data.SqlClient;
using webapi.Models;
using webapi.Services.Interfaces;

namespace webapi.Services.Implementations
{
    public class GuestsService : IGuestsService
    {
        public async Task<List<Guests>> GetAllAsync()
        {
            List<Guests> guests = new();

            using (IDbConnection connection = new SqlConnection(ConnectionService.ConnectionString))
            {
                connection.Open();

                var guestsData = await connection.QueryAsync<Guests>("SELECT * FROM Guests");

                guests = guestsData.ToList();
            }
            return guests;
        }



            public async Task<GuestsGetDto?> InsertAsync(GuestsCreateDto dto)
        {
                using IDbConnection connection = new SqlConnection(ConnectionService.ConnectionString);
                connection.Open();

                IEnumerable<Guests> newGuest = await connection
                    .QueryAsync<Guests>("INSERT INTO Guests (UserId,FirstName,LastName,MiddleInitial)" +
                    " VALUES (@UserId,@FirstName,@LastName,@MiddleInitial)",
                    new { UserId = dto.UserId, FirstName=dto.FirstName, LastName=dto.LastName, MiddleInitial=dto.MiddleInitial });
                    
                return newGuest.Select(x => new GuestsGetDto { UserId = dto.UserId, FirstName = dto.FirstName, LastName = dto.LastName, MiddleInitial = dto.MiddleInitial}).FirstOrDefault();

            
        }
    }
}
