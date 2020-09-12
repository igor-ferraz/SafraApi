using System.Collections.Generic;
using System.Threading.Tasks;

using Safra.Domain.Models;

namespace Safra.Domain.ApplicationServices
{
    public interface IAccountService
    {
        Task<List<Product>> GetProducts(int accountId, bool showInactives);
    }
}
