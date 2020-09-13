using Dapper;
using System.Threading.Tasks;

using Safra.Domain.Repositories;

namespace Safra.Infrastructure.Repositories
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(string connectionString) : base(connectionString)
        {
        }

        public async Task<bool> SaveToken(string clientId, string token)
        {
            const string sql = "UPDATE Users SET Token = @Token WHERE ClientId = @ClientId";

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
