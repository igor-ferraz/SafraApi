using RestSharp;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using Safra.Domain.InfrastructureServices;

namespace Safra.Infrastructure.Services
{
    public class HttpService : IHttpService
    {
        public async Task<IRestResponse> ExecuteRequest(string url, Method method, Dictionary<string, string> headers = null)
        {
            var client = new RestClient(url);
            var request = new RestRequest(method);

            if (headers != null)
            {
                foreach (var header in headers)
                {
                    request.AddHeader(header.Key, header.Value);
                }
            }

            using var cancellationTokenSource = new CancellationTokenSource();
            return await client.ExecuteAsync(request, cancellationTokenSource.Token);
        }
    }
}
