using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

using Safra.Domain.InfrastructureServices;

namespace Safra.API.Filters
{
    public class AuthFilter : ActionFilterAttribute
    {
        private readonly IHttpService httpService;

        public AuthFilter(IHttpService httpService)
        {
            this.httpService = httpService;
        }

        public async override Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
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

            var response = await httpService.ExecuteRequest(safraHealthUrl, RestSharp.Method.GET, headers);

            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                var errorResponse = new
                {
                    message = "Unauthorized",
                    code = 401
                };

                context.Result = new UnauthorizedObjectResult(errorResponse);
            }
            else
                await next();
        }
    }
}
