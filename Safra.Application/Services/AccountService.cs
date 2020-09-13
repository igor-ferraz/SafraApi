using System.Collections.Generic;
using System.Threading.Tasks;
using RestSharp;
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

        private async Task<IRestResponse> CallSafraEndpoint(string accountId, string url, Method method)
        {
            var token = await userService.GetCurrentTokenByAccount(accountId);

            var headers = new Dictionary<string, string>()
            {
                { "Authorization", $"Bearer {token}" }
            };

            return await httpService.ExecuteRequest(url, method, headers);
        }

        public async Task<AccountResult> GetBasicData(string id)
        {
            var safraUrl = $"https://af3tqle6wgdocsdirzlfrq7w5m.apigateway.sa-saopaulo-1.oci.customer-oci.com/fiap-sandbox/open-banking/v1/accounts/{id}";

            var result = await CallSafraEndpoint(id, safraUrl, Method.GET);

            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var basicAccount = httpService.GetObjectFromJson<AccountResult>(result.Content);
                return await Task.FromResult(basicAccount);
            }

            return null;
        }

        public async Task<List<Product>> GetProducts(string accountId, bool showInactives)
        {
            return await repository.GetProducts(accountId, showInactives);
        }

        public async Task<BalancesResult> GetBalances(string id)
        {
            var safraUrl = $"https://af3tqle6wgdocsdirzlfrq7w5m.apigateway.sa-saopaulo-1.oci.customer-oci.com/fiap-sandbox/open-banking/v1/accounts/{id}/balances";

            var result = await CallSafraEndpoint(id, safraUrl, Method.GET);

            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var balances = httpService.GetObjectFromJson<BalancesResult>(result.Content);
                return await Task.FromResult(balances);
            }

            return null;
        }

        public async Task<TransactionResult> GetTransactions(string id)
        {
            var safraUrl = $"https://af3tqle6wgdocsdirzlfrq7w5m.apigateway.sa-saopaulo-1.oci.customer-oci.com/fiap-sandbox/open-banking/v1/accounts/{id}/transactions";

            var result = await CallSafraEndpoint(id, safraUrl, Method.GET);

            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var transactions = httpService.GetObjectFromJson<TransactionResult>(result.Content);
                return await Task.FromResult(transactions);
            }

            return null;
        }
    }
}
