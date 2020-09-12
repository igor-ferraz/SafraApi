using Microsoft.AspNetCore.Mvc.Filters;
using Safra.Domain.InfrastructureServices;
using System.Collections.Generic;
using System.Net;

namespace Safra.API.Filters
{
    public class AuthFilter : ActionFilterAttribute
    {
        private readonly IHttpService _httpService;

        public AuthFilter(IHttpService httpService)
        {
            _httpService = httpService;
        }

        public async override void OnActionExecuting(ActionExecutingContext context)
        {
            const string safraHealthUrl = "https://af3tqle6wgdocsdirzlfrq7w5m.apigateway.sa-saopaulo-1.oci.customer-oci.com/fiap-sandbox/health";

            var mandatoryHeaders = new string[] { "Authorization" };
            var headers = new Dictionary<string, string>();

            foreach (var header in context.HttpContext.Request.Headers)
            {
                foreach (var expectedHeader in mandatoryHeaders)
                {
                    if (expectedHeader == header.Key)
                        headers.Add(header.Key, header.Value);
                }
            }

            var response = await _httpService.ExecuteRequest(safraHealthUrl, RestSharp.Method.GET, headers);
            
            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                
            }
        }
    }
}
