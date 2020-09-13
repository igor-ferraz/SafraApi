using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Safra.Domain.InfrastructureServices;
using Safra.Domain.Models;
using Safra.Domain.Repositories;

namespace Safra.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository userRepository;
        private readonly IHttpService httpService;

        public AuthService(IUserRepository userService, IHttpService httpService)
        {
            this.userRepository = userService;
            this.httpService = httpService;
        }

        public async Task<Token> Authorize(string token)
        {
            const string safraUrl = "https://idcs-902a944ff6854c5fbe94750e48d66be5.identity.oraclecloud.com/oauth2/v1/token";
            const string safraBody = "grant_type=client_credentials&scope=urn:opc:resource:consumer::all";

            var bytes = System.Convert.FromBase64String(token);
            var clientId = System.Text.Encoding.UTF8.GetString(bytes).Split(':').FirstOrDefault();

            var headers = new Dictionary<string, string>
            {
                { "Authorization", $"Basic {token}" },
                { "Content-Type", "application/x-www-form-urlencoded" }
            };

            var result = await httpService.ExecuteRequest(safraUrl, RestSharp.Method.POST, headers, safraBody, "application/x-www-form-urlencoded");

            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var accessToken = httpService.GetObjectFromJson<Token>(result.Content);
                var tokenSaved = await userRepository.SaveToken(clientId, accessToken.AccessToken);

                if (tokenSaved)
                    return accessToken;
            }

            return null;
        }
    }
}
