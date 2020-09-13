using System.Collections.Generic;
using System.Threading.Tasks;

using Safra.Domain.ApplicationServices;
using Safra.Domain.InfrastructureServices;
using Safra.Domain.Models;
using Safra.Domain.Repositories;

namespace Safra.Application.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository repository;
        private readonly IUserService userService;
        private readonly IHttpService httpService;

        public AccountService(IAccountRepository repository, IUserService userService, IHttpService httpService)
        {
            this.repository = repository;
            this.userService = userService;
            this.httpService = httpService;

        }

        public async Task<BasicAccount> GetBasicData(string id)
        {
            var safraUrl = $"https://af3tqle6wgdocsdirzlfrq7w5m.apigateway.sa-saopaulo-1.oci.customer-oci.com/fiap-sandbox/open-banking/v1/accounts/{id}";
            var headers = new Dictionary<string, string>();

            var token = await userService.GetCurrentTokenByAccount(id);

            headers.Add("Authorization", $"Bearer {token}");

            var result = await httpService.ExecuteRequest(safraUrl, RestSharp.Method.GET, headers);

            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var basicAccount = httpService.GetObjectFromJson<BasicAccount>(result.Content);
                return await Task.FromResult(basicAccount);
            }

            return null;
        }

        public async Task<List<Product>> GetProducts(string accountId, bool showInactives)
        {
            return await repository.GetProducts(accountId, showInactives);
        }
    }
}
