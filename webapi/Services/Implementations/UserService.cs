using System.Data.SqlClient;
using System.Data;
using webapi.Models;
using webapi.Services.Interfaces;
using Dapper;

namespace webapi.Services.Implementations
{
    public class UserService : IUsersService
    {
        public async Task<List<Users>> GetAllAsync()
        {
            List<Users> users = new();
            using (IDbConnection connection = new SqlConnection(ConnectionService.ConnectionString))
            {
                connection.Open();

                var userData = await connection.QueryAsync<Users>("SELECT * FROM Users");

                users = userData.ToList();
            }

            return users;
        }

        public async Task<List<Users>> GetAllGuestsAsync()
        {
            List<Users> users = new List<Users>();
            using (IDbConnection connection = new SqlConnection(ConnectionService.ConnectionString))
            {
                connection.Open();

                var userData = await connection.QueryAsync<Users, Guests, Users>("SELECT u.*,g.* " +
                    "FROM Users u INNER JOIN Guests g ON u.Id = g.UserId",
                    (user, guests) =>
                    {
                        if (!users.Any(x => x.Id == user.Id))
                        {
                            user.Guests = new List<Guests>() { guests };
                            users.Add(user);
                        }
                        else
                        {
                            users.Single(x => x.Id == user.Id).Guests.Add(guests);
                        }
                        return user;
                    },"UserName");

            }
            return users;

            
        }
    }
}
