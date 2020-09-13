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

        public Task<List<Product>> Get(bool showInactives)
        {
            return _repository.Get(showInactives);
        }

        public Task<Product> Get(int id)
        {
            return _repository.Get(id);
        }

        public Task<int> Add(Product product)
        {
            return _repository.Add(product);
        }

        public Task<bool> Update(Product product)
        {
            return _repository.Update(product);
        }

        public Task<bool> Delete(int id)
        {
            return _repository.Delete(id);
        }
    }
}
