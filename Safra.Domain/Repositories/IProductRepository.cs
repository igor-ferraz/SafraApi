using System.Collections.Generic;
using System.Threading.Tasks;

using Safra.Domain.Models;

namespace Safra.Domain.Repositories
{
    public interface IProductRepository
    {
        Task<List<Product>> Get(bool showInactives);
        Task<List<Product>> GetByAccount(int accountId);
        Task<Product> Get(int id);
        Task<bool> Add(Product product);
        Task<bool> Update(Product product);
        Task<bool> Delete(int id);
    }
}
