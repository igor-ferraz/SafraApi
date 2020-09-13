using Dapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using Safra.Domain.Models;
using Safra.Domain.Repositories;

namespace Safra.Infrastructure.Repositories
{
    public class SaleRepository : BaseRepository, ISaleRepository
    {
        public SaleRepository(string connectionString) : base(connectionString) { }

        public async Task<string> Create(Sale sale)
        {
            const string insertSale = @"
                DECLARE @Ids TABLE(Id VARCHAR(MAX));

                INSERT INTO Sales(AccountId)
                    OUTPUT inserted.Id INTO @Ids
                    VALUES(@AccountId);

                SELECT TOP 1 * FROM @Ids;";

            const string insertSaleProduct = @"
                DECLARE @UnitPrice DECIMAL(7,2) = (SELECT TOP 1 Price FROM Products WHERE Id = @ProductId);

                INSERT INTO SalesProducts(ProductId, SaleId, Quantity, UnitPrice) VALUES(@ProductId, @SaleId, @Quantity, @UnitPrice)";

            var connection = CreateConnection();
            var saleId = await connection.QueryFirstOrDefaultAsync<string>(
                insertSale,
                new
                {
                    sale.AccountId
                });

            if (!String.IsNullOrEmpty(saleId))
            {
                var result = 0;

                foreach (var product in sale.Products)
                {
                    result += await connection.ExecuteAsync(
                        insertSaleProduct,
                        new
                        {
                            product.ProductId,
                            saleId,
                            product.Quantity
                        });
                }

                if (result == sale.Products.Count)
                    return saleId;
            }

            return null;
        }
    }
}
