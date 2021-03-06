﻿using Dapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Safra.Domain.Models;
using Safra.Domain.Repositories;

namespace Safra.Infrastructure.Repositories
{
    public class ProductRepository : BaseRepository, IProductRepository
    {
        public ProductRepository(string connectionString): base(connectionString) { }

        public async Task<List<Product>> Get(bool showInactives)
        {
            const string sql = "SELECT * FROM Products WHERE @ShowInactives = 1 OR Active = 1";

            using var connection = CreateConnection();
            var products = await connection.QueryAsync<Product>(
                sql,
                new
                {
                    ShowInactives = showInactives
                });

            return products.ToList();
        }

        public async Task<Product> Get(int id)
        {
            const string sql = "SELECT * FROM Products WHERE Id = @Id";

            using var connection = CreateConnection();

            return await connection.QueryFirstOrDefaultAsync<Product>(
                sql,
                new {
                    Id = id
                });
        }

        public async Task<int> Add(Product product)
        {
            const string sql = @"
                DECLARE @Ids TABLE (Id INT);

                INSERT INTO Products (Name, Description, Price, AccountId)
                    OUTPUT inserted.Id INTO @Ids
                    VALUES(@Name, @Description, @Price, @AccountId);

                SELECT TOP 1 Id FROM @Ids;";

            using var connection = CreateConnection();
            var productId = await connection.QueryFirstOrDefaultAsync<int>(
                sql,
                new
                {
                    product.Name,
                    product.Description,
                    product.Price,
                    product.AccountId
                });

            return productId;
        }

        public async Task<bool> Update(Product product)
        {
            const string sql = "UPDATE Products SET Name = @Name, Description = @Description, Price = @Price, ChangeDate = GETDATE() WHERE Id = @Id";

            using var connection = CreateConnection();
            var result = await connection.ExecuteAsync(
                sql,
                new
                {
                    product.Id,
                    product.Name,
                    product.Description,
                    product.Price
                });

            return result == 1;
        }

        public async Task<bool> Delete(int id)
        {
            const string sql = "UPDATE Products SET Active = 0, ChangeDate = GETDATE() WHERE Id = @Id";

            using var connection = CreateConnection();
            var result = await connection.ExecuteAsync(
                sql,
                new
                {
                    Id = id
                });

            return result == 1;
        }
    }
}
