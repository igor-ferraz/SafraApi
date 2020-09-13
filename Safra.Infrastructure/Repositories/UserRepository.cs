using Dapper;
using System.Threading.Tasks;

using Safra.Domain.Repositories;
using Safra.Domain.Models;

namespace Safra.Infrastructure.Repositories
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(string connectionString) : base(connectionString) { }

        public async Task<ClientSecret> Login(UserLogin login)
        {
            const string sql = "SELECT TOP 1 ClientId, Secret FROM Users WHERE Email = @Email AND Password = @Password";

            var connection = CreateConnection();
            var result = await connection.QueryFirstOrDefaultAsync<ClientSecret>(
                sql,
                new
                {
                    login.Email,
                    login.Password
                });

            return result;
        }

        public async Task<bool> SaveToken(string clientId, string token)
        {
            const string sql = "UPDATE Users SET CurrentToken = @Token WHERE ClientId = @ClientId";

            var connection = CreateConnection();
            var result = await connection.ExecuteAsync(
                sql,
                new
                {
                    ClientId = clientId,
                    Token = token
                });

            return result == 1;
        }

        public async Task<string> GetCurrentTokenByAccount(string id)
        {
            const string sql = "SELECT TOP 1 CurrentToken FROM Users WHERE AccountId = @AccountId";

            var connection = CreateConnection();
            var token = await connection.QueryFirstOrDefaultAsync<string>(
                sql,
                new
                {
                    AccountId = id
                });

            return token;
        }
    }
}
