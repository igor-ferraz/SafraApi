using System.Collections.Generic;
using System.Threading.Tasks;

using Safra.Domain.Models;
using Safra.Domain.Repositories;
using Safra.Domain.ApplicationServices;

namespace Safra.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        public Task<List<Product>> Get()
        {
            return _repository.Get();
        }
    }
}
