using Dapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Safra.Domain.Models;
using Safra.Domain.Repositories;

namespace Safra.Infrastructure.Repositories
{
    public class AccountRepository : BaseRepository, IAccountRepository
    {
        public AccountRepository(string connectionString) : base(connectionString) { }

        public async Task<List<Product>> GetProducts(string accountId, bool showInactives)
        {
            const string sql = "SELECT * FROM Products WHERE AccountId = @AccountId";

            using var connection = CreateConnection();
            var products = await connection.QueryAsync<Product>(
                sql,
                new
                {
                    AccountId = accountId
                });

            return products.ToList();
        }
    }
}
