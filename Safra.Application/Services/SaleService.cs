using System.Threading.Tasks;

using Safra.Domain.ApplicationServices;
using Safra.Domain.Models;
using Safra.Domain.Repositories;

namespace Safra.Application.Services
{
    public class SaleService : ISaleService
    {
        private readonly ISaleRepository saleRepository;

        public SaleService(ISaleRepository saleRepository)
        {
            this.saleRepository = saleRepository;
        }

        public async Task<string> Create(Sale sale)
        {
            return await saleRepository.Create(sale);
        }

        public async Task<Sale> Get(string id)
        {
            return await saleRepository.Get(id);
        }
    }
}
