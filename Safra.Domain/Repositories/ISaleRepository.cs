using System.Threading.Tasks;

using Safra.Domain.Models;

namespace Safra.Domain.Repositories
{
    public interface ISaleRepository
    {
        Task<string> Create(Sale sale);
        Task<Sale> Get(string id);
    }
}
