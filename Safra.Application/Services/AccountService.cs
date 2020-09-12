using System.Collections.Generic;
using System.Threading.Tasks;
using Safra.Domain.ApplicationServices;
using Safra.Domain.Models;
using Safra.Domain.Repositories;

namespace Safra.Application.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository repository;

        public AccountService(IAccountRepository repository)
        {
            this.repository = repository;
        }

        public Task<List<Product>> GetProducts(int accountId, bool showInactives)
        {
            return repository.GetProducts(accountId, showInactives);
        }
    }
}
