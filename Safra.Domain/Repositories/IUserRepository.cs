using System.Threading.Tasks;

namespace Safra.Domain.Repositories
{
    public interface IUserRepository
    {
        Task<bool> SaveToken(string clientId, string token);
        Task<string> GetCurrentTokenByAccount(string id);
    }
}
