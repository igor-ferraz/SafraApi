using System.Collections.Generic;
using System.Threading.Tasks;

using Safra.Domain.Models;

namespace Safra.Domain.Repositories
{
    public interface IAccountRepository
    {
        Task<List<Product>> GetProducts(int accountId, bool showInactives);
    }
}
