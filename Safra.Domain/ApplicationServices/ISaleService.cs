using System.Threading.Tasks;

using Safra.Domain.Models;

namespace Safra.Domain.ApplicationServices
{
    public interface ISaleService
    {
        Task<string> Create(Sale sale);
        Task<Sale> Get(string id);
    }
}
