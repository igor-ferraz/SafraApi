using RestSharp;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Text.Json;
using System;

using Safra.Domain.InfrastructureServices;

namespace Safra.Infrastructure.Services
{
    public class HttpService : IHttpService
    {
        public async Task<IRestResponse> ExecuteRequest(string url, Method method, Dictionary<string, string> headers = null, string body = null)
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

            if (body != null)
                request.AddParameter("application/x-www-form-urlencoded", body, ParameterType.RequestBody);

            using var cancellationTokenSource = new CancellationTokenSource();
            return await client.ExecuteAsync(request, cancellationTokenSource.Token);
        }

        public T GetObjectFromJson<T>(string json)
        {
            var generatedType = JsonSerializer.Deserialize<T>(json);
            return (T)Convert.ChangeType(generatedType, typeof(T));
        }
    }
}
