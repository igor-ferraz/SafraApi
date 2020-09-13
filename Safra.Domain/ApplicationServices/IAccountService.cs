using System.Collections.Generic;
using System.Threading.Tasks;

using Safra.Domain.Models;

namespace Safra.Domain.ApplicationServices
{
    public interface IAccountService
    {
        Task<AccountResult> GetBasicData(string id);
        Task<List<Product>> GetProducts(string accountId, bool showInactives);
        Task<BalancesResult> GetBalances(string id);
        Task<TransactionResult> GetTransactions(string id);
    }
}
