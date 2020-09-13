using System.Collections.Generic;
using System.Threading.Tasks;

using Safra.Domain.Models;

namespace Safra.Domain.ApplicationServices
{
    public interface IAccountService
    {
        Task<List<Product>> GetProducts(string accountId, bool showInactives);
        Task<BasicAccount> GetBasicData(string id);
    }
}
