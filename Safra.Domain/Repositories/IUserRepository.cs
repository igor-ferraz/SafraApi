using System.Threading.Tasks;

using Safra.Domain.Models;

namespace Safra.Domain.Repositories
{
    public interface IUserRepository
    {
        Task<bool> SaveToken(string clientId, string token);
        Task<string> GetCurrentTokenByAccount(string id);
        Task<ClientSecret> Login(UserLogin login);
    }
}
