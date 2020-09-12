using Dapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Safra.Domain.Models;
using Safra.Domain.Repositories;

namespace Safra.Infrastructure.Repositories
{
    public class ProductRepository : BaseRepository, IProductRepository
    {
        public ProductRepository(string connectionString): base(connectionString)
        {
        }

        public async Task<List<Product>> Get()
        {
            const string sql = "SELECT * FROM Products";

            using var connection = CreateConnection();

            var products = await connection.QueryAsync<Product>(sql);

            return products.ToList();
        }
    }
}
