using System.Collections.Generic;
using System.Threading.Tasks;

using Safra.Domain.Models;

namespace Safra.Domain.Repositories
{
    public interface IProductRepository
    {
        Task<List<Product>> Get();
    }
}
