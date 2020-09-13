using System.Threading.Tasks;

using Safra.Domain.Models;

namespace Safra.Domain.ApplicationServices
{
    public interface IUserService
    {
        Task<bool> SaveToken(string clientId, string token);
        Task<string> GetCurrentTokenByAccount(string id);
        Task<ClientSecret> Login(UserLogin login);
    }
}
